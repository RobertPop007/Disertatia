using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Proiect_licenta.Entities.Games.Game;
using Proiect_licenta.Helpers;
using Proiect_licenta.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace Proiect_licenta.DatabaseContext
{
    public class GameRepository : IGamesRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GameRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void DeleteGameForUser(int userId, int gameId)
        {
            var appUserGameItem = _context.AppUserGameItems.FirstOrDefault(o => o.AppUserId == userId && o.GameId == gameId);
            _context.AppUserGameItems.Remove(appUserGameItem);
        }

        public async Task<Game> GetGameByFullTitleAsync(string fullTitle)
        {
            return await _context.Games
                .Where(t => t.Name == fullTitle)
                .IncludeOptimized(o => o.Ratings)
                .IncludeOptimized(o => o.Added_by_status)
                .IncludeOptimized(o => o.Parent_platforms)
                .IncludeOptimized(o => o.Platforms)
                .IncludeOptimized(o => o.Stores)
                .IncludeOptimized(o => o.Developers)
                .IncludeOptimized(o => o.Genres)
                .IncludeOptimized(o => o.Tags)
                .IncludeOptimized(o => o.Publishers)
                .IncludeOptimized(o => o.Esrb_rating)
                .FirstOrDefaultAsync();
        }

        public async Task<Game> GetGameByIdAsync(int id)
        {
            return await _context.Games.FindAsync(id);
        }

        public async Task<List<Game>> GetGamesAsync(GameParams gameParams)
        {
            var query = _context.Games.AsQueryable();

            if (!string.IsNullOrWhiteSpace(gameParams.SearchedGame))
                query = query.Where(u => u.Name.Contains(gameParams.SearchedGame));

            query = gameParams.OrderBy switch
            {
                "name" => query.OrderBy(u => u.Name).OrderBy(u => u.Released),
                "rating" => query.OrderByDescending(u => u.Rating),
                _ => query.OrderByDescending(u => u.Released)

            };

            return await query.ToListAsync();
        }

        public async Task<List<Game>> GetUserGames(int userId)
        {
            var listOfGamesIdForUser = _context.AppUserGameItems.Where(o => o.AppUserId == userId).Select(o => o.GameId).AsEnumerable();

            var listOfGamesForUser = new List<Game>();

            foreach (var movieId in listOfGamesIdForUser)
            {
                var movie = await _context.Games.FindAsync(userId);

                if (movie != null) listOfGamesForUser.Add(movie);
            }

            return listOfGamesForUser;
        }

        public bool IsGameAlreadyAdded(int userId, int gameId)
        {
            var listOfGamesIdForUser = _context.AppUserGameItems.Where(o => o.AppUserId == userId).Select(o => o.GameId).AsEnumerable();

            var isGameAlreadyAdded = listOfGamesIdForUser.Contains(gameId);
            if (isGameAlreadyAdded == true) return true;
            return false;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
