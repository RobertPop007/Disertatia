using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Proiect_licenta.DTO.Manga;
using Proiect_licenta.Entities.Manga;
using Proiect_licenta.Helpers;
using Proiect_licenta.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace Proiect_licenta.DatabaseContext
{
    public class MangaRepository : IMangaRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public MangaRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void DeleteMangaForUser(int userId, int mangaId)
        {
            var appUserMangaItem = _context.AppUserMangaItems.FirstOrDefault(o => o.AppUserId == userId && o.MangaId == mangaId);
            _context.AppUserMangaItems.Remove(appUserMangaItem);
        }

        public async Task<DatumManga> GetMangaByFullTitleAsync(string title)
        {
            return await _context.Manga
                .Where(t => t.Title == title)
                .IncludeOptimized(o => o.Images)
                .IncludeOptimized(o => o.Published)
                .IncludeOptimized(o => o.Authors)
                .IncludeOptimized(o => o.Serializations)
                .IncludeOptimized(o => o.Genres)
                .IncludeOptimized(o => o.Themes)
                .IncludeOptimized(o => o.Demographics)
                .FirstOrDefaultAsync();
        }

        public async Task<DatumManga> GetMangaByIdAsync(int id)
        {
            return await _context.Manga.FindAsync(id);
        }

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

        public async Task<List<DatumManga>> GetUserMangas(int userId)
        {
            var listOfMangasIdForUser = _context.AppUserMangaItems.Where(o => o.AppUserId == userId).Select(o => o.MangaId).AsEnumerable();

            var listOfMangasForUser = new List<DatumManga>();

            foreach (var mangaId in listOfMangasIdForUser)
            {
                var manga = await _context.Manga.FindAsync(mangaId);

                if (manga != null) listOfMangasForUser.Add(manga);
            }

            return listOfMangasForUser;
        }

        public bool IsMangaAlreadyAdded(int userId, int mangaId)
        {
            var listOfMangasIdForUser = _context.AppUserMangaItems.Where(o => o.AppUserId == userId).Select(o => o.MangaId).AsEnumerable();

            var isMangaAlreadyAdded = listOfMangasIdForUser.Contains(mangaId);
            if (isMangaAlreadyAdded == true) return true;
            return false;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
