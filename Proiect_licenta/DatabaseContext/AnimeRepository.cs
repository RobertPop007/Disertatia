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
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace Disertatie_backend.DatabaseContext
{
    public class AnimeRepository : IAnimeRepository
    {
        private readonly DataContext _context;
        private readonly IMongoCollection<Datum> _animeCollection;
        private readonly IMongoCollection<AppUser> _userCollection;
        private readonly IUserRepository _userRepository;
        private readonly IMongoDBCollectionHelper<Datum> _animeCollectionHelper;
        private readonly IMongoDBCollectionHelper<AppUser> _userCollectionHelper;
        private readonly string titleIndex = "Title_index";

        public AnimeRepository(DataContext context, IMongoDBCollectionHelper<Datum> animeCollectionHelper, IMongoDBCollectionHelper<AppUser> userCollectionHelper, IUserRepository userRepository, IOptions<DatabaseSettings> databaseSettings)
        {
            _animeCollectionHelper = animeCollectionHelper;
            _userCollectionHelper = userCollectionHelper;
            _animeCollection = _animeCollectionHelper.CreateCollection(databaseSettings);
            _userCollection = _userCollectionHelper.CreateCollection(databaseSettings);
            _userRepository = userRepository;

            _animeCollectionHelper.CreateIndexAscending(u => u.Title, titleIndex);
        }

        public async Task DeleteAnimeForUser(ObjectId userId, ObjectId animeId)
        {
            var filter = Builders<AppUser>.Filter.Eq(x => x.Id, userId);
            var update = Builders<AppUser>.Update.Pull(x => x.AppUserAnime, animeId);
            await _userCollection.UpdateOneAsync(filter, update);
        }

        public async Task AddAnimeToUser(ObjectId userId, ObjectId animeId)
        {
            var filter = Builders<AppUser>.Filter.Eq(x => x.Id, userId);
            var update = Builders<AppUser>.Update.Push(x => x.AppUserAnime, animeId);
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

        //aici umblam cand vedem si partea de frontend, să stim ca intoarcem ce trebuie
        public async Task<List<AnimeCard>> GetAnimesAsync(AnimeParams animeParams)
        {
            var query = _context.Anime
                .Select(anime => new AnimeCard
                {
                    Title = anime.Title,
                    Popularity = anime.Popularity.ToString(),
                    Mal_id = anime.Mal_id,
                    Score = anime.Score,
                    Image = anime.Images.Webp.Image_url,
                    Year = anime.Year.ToString()
                }).AsQueryable();

            if (!string.IsNullOrWhiteSpace(animeParams.SearchedAnime))
                query = query.Where(u => u.Title.Contains(animeParams.SearchedAnime));

            query = animeParams.OrderBy switch
            {
                "title" => query.OrderBy(u => u.Title).OrderByDescending(u => u.Popularity),
                "score" => query.OrderByDescending(u => u.Score),
                _ => query.OrderByDescending(u => u.Year)

            };

            return await query.ToListAsync();
        }

        public async Task<List<Datum>> GetUserAnimes(ObjectId userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);

            var listOfAnimesForUser = new List<Datum>();

            foreach (var animeId in user.AppUserAnime)
            {
                var anime = await GetAnimeByIdAsync(animeId);

                if (anime != null) listOfAnimesForUser.Add(anime);
            }

            return listOfAnimesForUser;
        }

        public async Task<bool> IsAnimeAlreadyAdded(ObjectId userId, ObjectId animeId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);

            var isAnimeAlreadyAdded = user.AppUserAnime.Contains(animeId);
            if (isAnimeAlreadyAdded == true) return true;
            return false;
        }
    }
}
