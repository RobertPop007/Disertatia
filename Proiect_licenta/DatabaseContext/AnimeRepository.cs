using AutoMapper;
using Disertatie_backend.Configurations;
using Disertatie_backend.DTO.Anime;
using Disertatie_backend.Entities;
using Disertatie_backend.Entities.Anime;
using Disertatie_backend.Helpers;
using Disertatie_backend.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disertatie_backend.DatabaseContext
{
    public class AnimeRepository : IAnimeRepository
    {
        private readonly IMongoCollection<Datum> _animeCollection;
        private readonly IMongoCollection<AppUser> _userCollection;
        private readonly IUserRepository _userRepository;
        private readonly IMongoDBCollectionHelper<Datum> _animeCollectionHelper;
        private readonly IMongoDBCollectionHelper<AppUser> _userCollectionHelper;
        private readonly string titleIndex = "Title_index";

        private readonly IMapper _mapper;

        public AnimeRepository(IMapper mapper, IMongoDBCollectionHelper<Datum> animeCollectionHelper, IMongoDBCollectionHelper<AppUser> userCollectionHelper, IUserRepository userRepository, IOptions<DatabaseSettings> databaseSettings)
        {
            _animeCollectionHelper = animeCollectionHelper;
            _userCollectionHelper = userCollectionHelper;
            _animeCollection = _animeCollectionHelper.CreateCollection(databaseSettings);
            _userCollection = _userCollectionHelper.CreateCollection(databaseSettings);
            _userRepository = userRepository;

            _animeCollectionHelper.CreateIndexAscending(u => u.Title, titleIndex);

            _mapper = mapper;
        }

        public async Task DeleteAnimeForUser(Guid userId, ObjectId animeId)
        {
            var filter = Builders<AppUser>.Filter.Eq(x => x.Id, userId);
            var update = Builders<AppUser>.Update.Pull(x => x.AppUserAnime, animeId.ToString());
            await _userCollection.UpdateOneAsync(filter, update);
        }

        public async Task AddAnimeToUser(Guid userId, ObjectId animeId)
        {
            var filter = Builders<AppUser>.Filter.Eq(x => x.Id, userId);
            var update = Builders<AppUser>.Update.Push(x => x.AppUserAnime, animeId.ToString());
            await _userCollection.UpdateOneAsync(filter, update);
        }

        public async Task<Datum> GetAnimeByFullTitleAsync(string title)
        {
            var filterByTitle = Builders<Datum>.Filter.Eq(p => p.Title, title);
            return await _animeCollection.Find(filterByTitle).FirstOrDefaultAsync();
        }

        public async Task<Datum> GetAnimeByIdAsync(ObjectId id)
        {
            var filterById = Builders<Datum>.Filter.Eq(p => p.Id, id);
            return await _animeCollection.Find(filterById).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<AnimeCard>> GetAnimesAsync(AnimeParams animeParams)
        {
            if (string.IsNullOrEmpty(animeParams.SearchedAnime) || string.IsNullOrWhiteSpace(animeParams.SearchedAnime)) return null;

            var filterByTitle = Builders<Datum>.Filter.Where(x => x.Title.Contains(animeParams.SearchedAnime)) |
                Builders<Datum>.Filter.Where(x => x.Title_english.Contains(animeParams.SearchedAnime)) |
                Builders<Datum>.Filter.Where(x => x.Title_japanese.Contains(animeParams.SearchedAnime));

            var query = await _animeCollection.Find(filterByTitle).ToListAsync();

            var queryList = new List<AnimeCard>();

            foreach (var document in query)
            {
                queryList.Add(_mapper.Map<AnimeCard>(document));
            }

            var mappedQuery = queryList.AsEnumerable();

            mappedQuery = animeParams.OrderBy switch
            {
                "title" => mappedQuery.OrderBy(u => u.Title).OrderByDescending(u => u.Popularity),
                "score" => mappedQuery.OrderByDescending(u => u.Score),
                _ => mappedQuery.OrderByDescending(u => u.Year)

            };

            return mappedQuery;
        }

        public async Task<IEnumerable<Datum>> GetUserAnimes(Guid userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);

            var listOfAnimesForUser = new List<Datum>();

            foreach (var animeId in user.AppUserAnime)
            {
                var anime = await GetAnimeByIdAsync(new ObjectId(animeId));

                if (anime != null) listOfAnimesForUser.Add(anime);
            }

            return listOfAnimesForUser;
        }

        public async Task<bool> IsAnimeAlreadyAdded(Guid userId, ObjectId animeId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);

            var isAnimeAlreadyAdded = user.AppUserAnime.Contains(animeId.ToString());
            if (isAnimeAlreadyAdded == true) return true;
            return false;
        }
    }
}
