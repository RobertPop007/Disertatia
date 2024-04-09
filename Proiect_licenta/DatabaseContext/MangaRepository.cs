using Microsoft.EntityFrameworkCore;
using Disertatie_backend.DTO.Manga;
using Disertatie_backend.Entities.Manga;
using Disertatie_backend.Helpers;
using Disertatie_backend.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Disertatie_backend.Entities;
using Disertatie_backend.Configurations;
using Microsoft.Extensions.Options;
using AutoMapper;
using System;

namespace Disertatie_backend.DatabaseContext
{
    public class MangaRepository : IMangaRepository
    {
        private readonly IMongoCollection<DatumManga> _mangaCollection;
        private readonly IMongoCollection<AppUser> _userCollection;
        private readonly IUserRepository _userRepository;
        private readonly IMongoDBCollectionHelper<DatumManga> _mangaCollectionHelper;
        private readonly IMongoDBCollectionHelper<AppUser> _userCollectionHelper;
        private readonly string titleIndex = "Title_index";

        private readonly IMapper _mapper;


        public MangaRepository(IMapper mapper, IMongoDBCollectionHelper<DatumManga> mangaCollectionHelper, IMongoDBCollectionHelper<AppUser> userCollectionHelper, IUserRepository userRepository, IOptions<DatabaseSettings> databaseSettings)
        {
            _mangaCollectionHelper = mangaCollectionHelper;
            _userCollectionHelper = userCollectionHelper;
            _mangaCollection = _mangaCollectionHelper.CreateCollection(databaseSettings);
            _userCollection = _userCollectionHelper.CreateCollection(databaseSettings);
            _userRepository = userRepository;

            _mangaCollectionHelper.CreateIndexAscending(u => u.Title, titleIndex);

            _mapper = mapper;
        }

        public async Task DeleteMangaForUser(Guid userId, ObjectId mangaId)
        {
            var filter = Builders<AppUser>.Filter.Eq(x => x.Id, userId);
            var update = Builders<AppUser>.Update.Pull(x => x.AppUserManga, mangaId.ToString());
            await _userCollection.UpdateOneAsync(filter, update);
        }

        public async Task AddMangaToUser(Guid userId, ObjectId mangaId)
        {
            var filter = Builders<AppUser>.Filter.Eq(x => x.Id, userId);
            var update = Builders<AppUser>.Update.Push(x => x.AppUserManga, mangaId.ToString());
            await _userCollection.UpdateOneAsync(filter, update);
        }

        public async Task<DatumManga> GetMangaByFullTitleAsync(string title)
        {
            var filterByTitle = Builders<DatumManga>.Filter.Eq(p => p.Title, title);
            return await _mangaCollection.Find(filterByTitle).FirstOrDefaultAsync();
        }

        public async Task<DatumManga> GetMangaByIdAsync(ObjectId id)
        {
            var filterById = Builders<DatumManga>.Filter.Eq(p => p.Id, id);
            return await _mangaCollection.Find(filterById).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<MangaCard>> GetMangasAsync(MangaParams mangaParams)
        {
            if (string.IsNullOrEmpty(mangaParams.SearchedManga) || string.IsNullOrWhiteSpace(value: mangaParams.SearchedManga)) return null;

            var filterByTitle = Builders<DatumManga>.Filter.Where(x => x.Title.Contains(mangaParams.SearchedManga)) |
                Builders<DatumManga>.Filter.Where(x => x.Title_english.Contains(mangaParams.SearchedManga)) |
                Builders<DatumManga>.Filter.Where(x => x.Title_japanese.Contains(mangaParams.SearchedManga));

            var query = await _mangaCollection.Find(filterByTitle).ToListAsync();

            var queryList = new List<MangaCard>();

            foreach (var document in query)
            {
                queryList.Add(_mapper.Map<MangaCard>(document));
            }

            var mappedQuery = queryList.AsEnumerable();

            mappedQuery = mangaParams.OrderBy switch
            {
                "title" => mappedQuery.OrderBy(u => u.Title).OrderByDescending(u => u.Popularity),
                "score" => mappedQuery.OrderByDescending(u => u.Score),
                _ => mappedQuery.OrderByDescending(u => u.Year)

            };

            return mappedQuery;
        }

        public async Task<IEnumerable<DatumManga>> GetUserMangas(Guid userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);

            var listOfMangasForUser = new List<DatumManga>();

            foreach (var mangaId in user.AppUserManga)
            {
                var manga = await GetMangaByIdAsync(new ObjectId(mangaId));

                if (manga != null) listOfMangasForUser.Add(manga);
            }

            return listOfMangasForUser;
        }

        public async Task<bool> IsMangaAlreadyAdded(Guid userId, ObjectId mangaId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);

            var isMangaAlreadyAdded = user.AppUserManga.Contains(mangaId.ToString());
            if (isMangaAlreadyAdded == true) return true;
            return false;
        }
    }
}
