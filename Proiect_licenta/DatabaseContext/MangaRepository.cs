using Microsoft.EntityFrameworkCore;
using Disertatie_backend.DTO.Manga;
using Disertatie_backend.Entities.Manga;
using Disertatie_backend.Helpers;
using Disertatie_backend.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;
using MongoDB.Bson;
using MongoDB.Driver;
using Disertatie_backend.Entities;
using Disertatie_backend.Configurations;
using Microsoft.Extensions.Options;

namespace Disertatie_backend.DatabaseContext
{
    public class MangaRepository : IMangaRepository
    {
        private readonly DataContext _context;
        private readonly IMongoCollection<DatumManga> _mangaCollection;
        private readonly IMongoCollection<AppUser> _userCollection;
        private readonly IUserRepository _userRepository;
        private readonly IMongoDBCollectionHelper<DatumManga> _mangaCollectionHelper;
        private readonly IMongoDBCollectionHelper<AppUser> _userCollectionHelper;
        private readonly string titleIndex = "Title_index";

        public MangaRepository(DataContext context, IMongoDBCollectionHelper<DatumManga> mangaCollectionHelper, IMongoDBCollectionHelper<AppUser> userCollectionHelper, IUserRepository userRepository, IOptions<DatabaseSettings> databaseSettings)
        {
            _mangaCollectionHelper = mangaCollectionHelper;
            _userCollectionHelper = userCollectionHelper;
            _mangaCollection = _mangaCollectionHelper.CreateCollection(databaseSettings);
            _userCollection = _userCollectionHelper.CreateCollection(databaseSettings);
            _userRepository = userRepository;

            _mangaCollectionHelper.CreateIndexAscending(u => u.Title, titleIndex);
        }

        public async Task DeleteMangaForUser(ObjectId userId, ObjectId mangaId)
        {
            var filter = Builders<AppUser>.Filter.Eq(x => x.Id, userId);
            var update = Builders<AppUser>.Update.Pull(x => x.AppUserManga, mangaId);
            await _userCollection.UpdateOneAsync(filter, update);
        }

        public async Task AddMangaToUser(ObjectId userId, ObjectId mangaId)
        {
            var filter = Builders<AppUser>.Filter.Eq(x => x.Id, userId);
            var update = Builders<AppUser>.Update.Push(x => x.AppUserManga, mangaId);
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

        //aici umblam cand vedem si partea de frontend, să stim ca intoarcem ce trebuie
        public async Task<List<MangaCard>> GetMangasAsync(MangaParams mangaParams)
        {
            var query = _context.Manga
                .Select(manga => new MangaCard
                {
                    Title = manga.Title,
                    Popularity = manga.Popularity.ToString(),
                    Mal_id = manga.Mal_id,
                    Score = manga.Score,
                    Image = manga.Images.Webp.Image_url,
                    Year = manga.Published.From.Value.Year.ToString()
                }).AsQueryable();

            if (!string.IsNullOrWhiteSpace(mangaParams.SearchedManga))
                query = query.Where(u => u.Title.Contains(mangaParams.SearchedManga));

            query = mangaParams.OrderBy switch
            {
                "title" => query.OrderBy(u => u.Title).OrderByDescending(u => u.Popularity),
                "score" => query.OrderByDescending(u => u.Score),
                _ => query.OrderByDescending(u => u.Popularity)

            };

            return await query.ToListAsync();
        }

        public async Task<List<DatumManga>> GetUserMangas(ObjectId userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);

            var listOfMangasForUser = new List<DatumManga>();

            foreach (var mangaId in user.AppUserManga)
            {
                var manga = await GetMangaByIdAsync(mangaId);

                if (manga != null) listOfMangasForUser.Add(manga);
            }

            return listOfMangasForUser;
        }

        public async Task<bool> IsMangaAlreadyAdded(ObjectId userId, ObjectId mangaId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);

            var isMangaAlreadyAdded = user.AppUserManga.Contains(mangaId);
            if (isMangaAlreadyAdded == true) return true;
            return false;
        }
    }
}
