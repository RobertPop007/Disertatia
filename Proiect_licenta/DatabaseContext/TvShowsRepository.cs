using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Disertatie_backend.DTO.TvShows;
using Disertatie_backend.Entities.TvShows;
using Disertatie_backend.Helpers;
using Disertatie_backend.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace Disertatie_backend.DatabaseContext
{
    public class TvShowsRepository : ITvShowsRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public TvShowsRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void DeleteShowForUser(int userId, string tvShowId)
        {
            var appUserTvShowItem = _context.AppUserTvShowItems.FirstOrDefault(o => o.AppUserId == userId && o.TvShowId == tvShowId);
            _context.AppUserTvShowItems.Remove(appUserTvShowItem);
        }

        public async Task<TvShow> GetTvShowByFullTitleAsync(string title)
        {
            return await _context.TrueTvShow
                .Where(t => t.Title == title)
                .IncludeOptimized(o => o.ActorList)
                .IncludeOptimized(o => o.StarList)
                .IncludeOptimized(o => o.GenreList)
                .IncludeOptimized(o => o.CompanyList)
                .IncludeOptimized(o => o.CountryList)
                .IncludeOptimized(o => o.LanguageList)
                .IncludeOptimized(o => o.Ratings)
                .IncludeOptimized(o => o.Wikipedia)
                .IncludeOptimized(o => o.Images)
                .IncludeOptimized(o => o.Trailer)
                .IncludeOptimized(o => o.BoxOffice)
                .IncludeOptimized(o => o.TvSeriesInfo)
                .IncludeOptimized(o => o.Similars)
                .FirstOrDefaultAsync();
        }

        public async Task<TvShow> GetTvShowByIdAsync(string id)
        {
            return await _context.TrueTvShow.FindAsync(id);
        }

        public async Task<List<TvShowCard>> GetTvShowsAsync(TvShowParams tvShowParams)
        {
            var query = _context.TrueTvShow
                .Select(tvShow => new TvShowCard
                {
                    Title = tvShow.Title,
                    FullTitle = tvShow.FullTitle,
                    Id = tvShow.Id,
                    ImDbRating = tvShow.ImDbRating,
                    Image = tvShow.Image,
                    Year = tvShow.Year
                })
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(tvShowParams.SearchedTvShow))
                query = query.Where(u => u.FullTitle.Contains(tvShowParams.SearchedTvShow));

            query = tvShowParams.OrderBy switch
            {
                "fulltitle" => query.OrderBy(u => u.FullTitle).OrderBy(u => u.Year),
                "imdbRating" => query.OrderByDescending(u => u.ImDbRating),
                _ => query.OrderByDescending(u => u.Year)

            };

            return await query.ToListAsync();
        }

        public async Task<List<TvShow>> GetUserTvShows(int userId)
        {
            var listOfTvShowsIdForUser = _context.AppUserTvShowItems.Where(o => o.AppUserId == userId).Select(o => o.TvShowId).AsEnumerable();

            var listOfTvShowsForUser = new List<TvShow>();

            foreach (var tvShowId in listOfTvShowsIdForUser)
            {
                var tvShow = await _context.TrueTvShow.FindAsync(tvShowId);

                if (tvShow != null) listOfTvShowsForUser.Add(tvShow);
            }

            return listOfTvShowsForUser;
        }

        public bool IsTvShowAlreadyAdded(int userId, string tvShowId)
        {
            var listOfTvShowsIdForUser = _context.AppUserTvShowItems.Where(o => o.AppUserId == userId).Select(o => o.TvShowId).AsEnumerable();

            var isTvShowAlreadyAdded = listOfTvShowsIdForUser.Contains(tvShowId);
            if (isTvShowAlreadyAdded == true) return true;
            return false;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
