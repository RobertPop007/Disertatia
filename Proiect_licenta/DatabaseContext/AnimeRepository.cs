using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Disertatie_backend.DTO.Anime;
using Disertatie_backend.Entities.Anime;
using Disertatie_backend.Helpers;
using Disertatie_backend.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;
using MongoDB.Driver;
using Disertatie_backend.Configurations;
using Microsoft.Extensions.Options;

namespace Disertatie_backend.DatabaseContext
{
    public class AnimeRepository : IAnimeRepository
    {
        private readonly DataContext _context;
        private static IMongoCollection<Datum> _animeCollection;

        public AnimeRepository(DataContext context, IOptions<DatabaseSettings> databaseSettings)
        {
            _context = context;

            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var mongoDb = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _animeCollection = mongoDb.GetCollection<Datum>("Anime");

            var indexModel = Builders<Datum>.IndexKeys.Ascending(u => u.Title);
            _animeCollection.Indexes.CreateOne(new CreateIndexModel<Datum>(indexModel));
        }

        public void DeleteAnimeForUser(int userId, int animeId)
        {
            var appUserAnimeItem = _context.AppUserAnimeItems.FirstOrDefault(o => o.AppUserId == userId && o.AnimeId == animeId);
            _context.AppUserAnimeItems.Remove(appUserAnimeItem);
        }

        public async Task<Datum> GetAnimeByFullTitleAsync(string title) => await _animeCollection.Find(x => x.Title == title).FirstOrDefaultAsync();

        public async Task<Datum> GetAnimeByIdAsync(int id)
        {
            return await _context.Anime.FindAsync(id);
        }

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

        public async Task<List<Datum>> GetUserAnimes(int userId)
        {
            var listOfAnimesIdForUser = _context.AppUserAnimeItems.Where(o => o.AppUserId == userId).Select(o => o.AnimeId).AsEnumerable();

            var listOfAnimesForUser = new List<Datum>();

            foreach (var animeId in listOfAnimesIdForUser)
            {
                var anime = await _context.Anime.Where(o => o.Mal_id == animeId)
                    .IncludeOptimized(o => o.Images)
                    .IncludeOptimized(o => o.Images.Jpg)
                    .IncludeOptimized(o => o.Images.Webp)
                    .FirstOrDefaultAsync();

                if (anime != null) listOfAnimesForUser.Add(anime);
            }

            return listOfAnimesForUser;
        }

        public bool IsAnimeAlreadyAdded(int userId, int animeId)
        {
            var listOfAnimesIdForUser = _context.AppUserAnimeItems.Where(o => o.AppUserId == userId).Select(o => o.AnimeId).AsEnumerable();

            var isAnimeAlreadyAdded = listOfAnimesIdForUser.Contains(animeId);
            if (isAnimeAlreadyAdded == true) return true;
            return false;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
