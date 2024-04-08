using Microsoft.EntityFrameworkCore;
using Disertatie_backend.DTO.TvShows;
using Disertatie_backend.Entities.TvShows;
using Disertatie_backend.Helpers;
using Disertatie_backend.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;
using MongoDB.Bson;
using Disertatie_backend.Entities;
using MongoDB.Driver;
using Disertatie_backend.Configurations;
using Microsoft.Extensions.Options;

namespace Disertatie_backend.DatabaseContext
{
    public class TvShowsRepository : ITvShowsRepository
    {
        private readonly DataContext _context;
        private readonly IMongoCollection<TvShow> _tvshowsCollection;
        private readonly IMongoCollection<AppUser> _userCollection;
        private readonly IUserRepository _userRepository;
        private readonly IMongoDBCollectionHelper<TvShow> _tvshowsCollectionHelper;
        private readonly IMongoDBCollectionHelper<AppUser> _userCollectionHelper;
        private readonly string titleIndex = "Title_index";

        public TvShowsRepository(DataContext context, IMongoDBCollectionHelper<TvShow> tvshowsCollectionHelper, IMongoDBCollectionHelper<AppUser> userCollectionHelper, IUserRepository userRepository, IOptions<DatabaseSettings> databaseSettings)
        {
            _tvshowsCollectionHelper = tvshowsCollectionHelper;
            _userCollectionHelper = userCollectionHelper;
            _tvshowsCollection = tvshowsCollectionHelper.CreateCollection(databaseSettings);
            _userCollection = _userCollectionHelper.CreateCollection(databaseSettings);
            _userRepository = userRepository;

            tvshowsCollectionHelper.CreateIndexAscending(u => u.Title, titleIndex);
        }

        public async Task DeleteShowForUser(ObjectId userId, ObjectId tvShowId)
        {
            var filter = Builders<AppUser>.Filter.Eq(x => x.Id, userId);
            var update = Builders<AppUser>.Update.Pull(x => x.AppUserTvShow, tvShowId);
            await _userCollection.UpdateOneAsync(filter, update);
        }

        public async Task AddTvShowToUser(ObjectId userId, ObjectId tvShowId)
        {
            var filter = Builders<AppUser>.Filter.Eq(x => x.Id, userId);
            var update = Builders<AppUser>.Update.Push(x => x.AppUserTvShow, tvShowId);
            await _userCollection.UpdateOneAsync(filter, update);
        }

        public async Task<TvShow> GetTvShowByFullTitleAsync(string title)
        {
            var filterByName = Builders<TvShow>.Filter.Eq(p => p.Title, title);
            return await _tvshowsCollection.Find(filterByName).FirstOrDefaultAsync();
        }

        public async Task<TvShow> GetTvShowByIdAsync(ObjectId id)
        {
            var filterById = Builders<TvShow>.Filter.Eq(p => p.Id, id);
            return await _tvshowsCollection.Find(filterById).FirstOrDefaultAsync();
        }

        //aici umblam cand vedem si partea de frontend, să stim ca intoarcem ce trebuie
        public async Task<List<TvShowCard>> GetTvShowsAsync(TvShowParams tvShowParams)
        {
            var query = _context.TrueTvShow
                .Select(tvShow => new TvShowCard
                {
                    Title = tvShow.Title,
                    FullTitle = tvShow.FullTitle,
                    Id = tvShow.TvShow_Id,
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

        public async Task<List<TvShow>> GetUserTvShows(ObjectId userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);

            var listOfTVShowsForUser = new List<TvShow>();

            foreach (var tvShowId in user.AppUserTvShow)
            {
                var tvShow = await GetTvShowByIdAsync(tvShowId);

                if (tvShow != null) listOfTVShowsForUser.Add(tvShow);
            }

            return listOfTVShowsForUser;
        }

        public async Task<bool> IsTvShowAlreadyAdded(ObjectId userId, ObjectId tvShowId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);

            var isMovieAlreadyAdded = user.AppUserTvShow.Contains(tvShowId);
            if (isMovieAlreadyAdded == true) return true;
            return false;
        }
    }
}
