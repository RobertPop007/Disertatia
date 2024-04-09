using Microsoft.EntityFrameworkCore;
using Disertatie_backend.DTO.TvShows;
using Disertatie_backend.Entities.TvShows;
using Disertatie_backend.Helpers;
using Disertatie_backend.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using Disertatie_backend.Entities;
using MongoDB.Driver;
using Disertatie_backend.Configurations;
using Microsoft.Extensions.Options;
using AutoMapper;
using System;

namespace Disertatie_backend.DatabaseContext
{
    public class TvShowsRepository : ITvShowsRepository
    {
        private readonly IMongoCollection<TvShow> _tvshowsCollection;
        private readonly IMongoCollection<AppUser> _userCollection;
        private readonly IUserRepository _userRepository;
        private readonly IMongoDBCollectionHelper<TvShow> _tvshowsCollectionHelper;
        private readonly IMongoDBCollectionHelper<AppUser> _userCollectionHelper;
        private readonly string titleIndex = "Title_index";

        private readonly IMapper _mapper;

        public TvShowsRepository(IMapper mapper, IMongoDBCollectionHelper<TvShow> tvshowsCollectionHelper, IMongoDBCollectionHelper<AppUser> userCollectionHelper, IUserRepository userRepository, IOptions<DatabaseSettings> databaseSettings)
        {
            _tvshowsCollectionHelper = tvshowsCollectionHelper;
            _userCollectionHelper = userCollectionHelper;
            _tvshowsCollection = _tvshowsCollectionHelper.CreateCollection(databaseSettings);
            _userCollection = _userCollectionHelper.CreateCollection(databaseSettings);
            _userRepository = userRepository;

            _tvshowsCollectionHelper.CreateIndexAscending(u => u.Title, titleIndex);

            _mapper = mapper;
        }

        public async Task DeleteShowForUser(Guid userId, ObjectId tvShowId)
        {
            var filter = Builders<AppUser>.Filter.Eq(x => x.Id, userId);
            var update = Builders<AppUser>.Update.Pull(x => x.AppUserTvShow, tvShowId.ToString());
            await _userCollection.UpdateOneAsync(filter, update);
        }

        public async Task AddTvShowToUser(Guid userId, ObjectId tvShowId)
        {
            var filter = Builders<AppUser>.Filter.Eq(x => x.Id, userId);
            var update = Builders<AppUser>.Update.Push(x => x.AppUserTvShow, tvShowId.ToString());
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

        public async Task<IEnumerable<TvShowCard>> GetTvShowsAsync(TvShowParams tvShowParams)
        {
            if (string.IsNullOrEmpty(tvShowParams.SearchedTvShow) || string.IsNullOrWhiteSpace(tvShowParams.SearchedTvShow)) return null;

            var filterByTitle = Builders<TvShow>.Filter.Where(x => x.Title.Contains(tvShowParams.SearchedTvShow)) |
                Builders<TvShow>.Filter.Where(x => x.FullTitle.Contains(tvShowParams.SearchedTvShow)) |
                Builders<TvShow>.Filter.Where(x => x.OriginalTitle.Contains(tvShowParams.SearchedTvShow));

            var query = await _tvshowsCollection.Find(filterByTitle).ToListAsync();

            var queryList = new List<TvShowCard>();

            foreach (var document in query)
            {
                queryList.Add(_mapper.Map<TvShowCard>(document));
            }

            var mappedQuery = queryList.AsEnumerable();

            mappedQuery = tvShowParams.OrderBy switch
            {
                "fulltitle" => mappedQuery.OrderBy(u => u.FullTitle).OrderByDescending(u => u.Year),
                "imdbRating" => mappedQuery.OrderByDescending(u => u.ImDbRating),
                _ => mappedQuery.OrderByDescending(u => u.Year)

            };

            return mappedQuery;
        }

        public async Task<IEnumerable<TvShow>> GetUserTvShows(Guid userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);

            var listOfTVShowsForUser = new List<TvShow>();

            foreach (var tvShowId in user.AppUserTvShow)
            {
                var tvShow = await GetTvShowByIdAsync(new ObjectId(tvShowId));

                if (tvShow != null) listOfTVShowsForUser.Add(tvShow);
            }

            return listOfTVShowsForUser;
        }

        public async Task<bool> IsTvShowAlreadyAdded(Guid userId, ObjectId tvShowId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);

            var isMovieAlreadyAdded = user.AppUserTvShow.Contains(tvShowId.ToString());
            if (isMovieAlreadyAdded == true) return true;
            return false;
        }
    }
}
