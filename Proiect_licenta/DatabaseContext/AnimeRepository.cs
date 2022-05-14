using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Proiect_licenta.Entities.Anime;
using Proiect_licenta.Helpers;
using Proiect_licenta.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace Proiect_licenta.DatabaseContext
{
    public class AnimeRepository : IAnimeRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public AnimeRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void DeleteAnimeForUser(int userId, int animeId)
        {
            var appUserAnimeItem = _context.AppUserAnimeItems.FirstOrDefault(o => o.AppUserId == userId && o.AnimeId == animeId);
            _context.AppUserAnimeItems.Remove(appUserAnimeItem);
        }

        public async Task<Datum> GetAnimeByFullTitleAsync(string fullTitle)
        {
            return await _context.Anime
                .Where(t => t.Title_english == fullTitle)
                .IncludeOptimized(o => o.Images)
                .IncludeOptimized(o => o.Trailer)
                .IncludeOptimized(o => o.Aired)
                .IncludeOptimized(o => o.Broadcast)
                .IncludeOptimized(o => o.Producers)
                .IncludeOptimized(o => o.Licensors)
                .IncludeOptimized(o => o.Studios)
                .IncludeOptimized(o => o.Genres)
                .IncludeOptimized(o => o.Themes)
                .IncludeOptimized(o => o.Demographics)
                .FirstOrDefaultAsync();
        }

        public async Task<Datum> GetAnimeByIdAsync(int id)
        {
            return await _context.Anime.FindAsync(id);
        }

        public async Task<List<Datum>> GetAnimesAsync(AnimeParams animeParams)
        {
            var query = _context.Anime.AsQueryable();

            if (!string.IsNullOrWhiteSpace(animeParams.SearchedAnime))
                query = query.Where(u => u.Title_english.Contains(animeParams.SearchedAnime));

            query = animeParams.OrderBy switch
            {
                "title_english" => query.OrderBy(u => u.Title_english).OrderBy(u => u.Year),
                "rating" => query.OrderByDescending(u => u.Rating),
                _ => query.OrderByDescending(u => u.Year)

            };

            return await query.ToListAsync();
        }

        public async Task<List<Datum>> GetUserAnimes(int userId)
        {
            var listOAnimesIdForUser = _context.AppUserAnimeItems.Where(o => o.AppUserId == userId).Select(o => o.AnimeId).AsEnumerable();

            var listOfAnimesForUser = new List<Datum>();

            foreach (var animeId in listOAnimesIdForUser)
            {
                var anime = await _context.Anime.FindAsync(animeId);

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
