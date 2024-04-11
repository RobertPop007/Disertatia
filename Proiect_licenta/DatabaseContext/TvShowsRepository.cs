using Microsoft.EntityFrameworkCore;
using Disertatie_backend.DTO.TvShows;
using Disertatie_backend.Entities.TvShows;
using Disertatie_backend.Helpers;
using Disertatie_backend.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Disertatie_backend.Configurations;
using AutoMapper;
namespace Disertatie_backend.DatabaseContext
{
    public class TvShowsRepository : ITvShowsRepository
    {
        private readonly IMongoCollection<TvShow> _tvshowsCollection;
        private readonly IMongoDBCollectionHelper<TvShow> _tvshowsCollectionHelper;
        private readonly string titleIndex = "Title_index";
        private readonly string titleOriginalIndex = "TitleOriginal_index";
        private readonly string titleFullIndex = "TitleFull_index";
        private readonly DatabaseSettings _databaseSettings;

        private readonly IMapper _mapper;

        public TvShowsRepository(IMapper mapper, 
            IMongoDBCollectionHelper<TvShow> tvshowsCollectionHelper, 
            DatabaseSettings databaseSettings)
        {
            _databaseSettings = databaseSettings;
            _tvshowsCollectionHelper = tvshowsCollectionHelper;
            _tvshowsCollection = _tvshowsCollectionHelper.CreateCollection(_databaseSettings);

            _tvshowsCollectionHelper.CreateIndexAscending(u => u.Title, titleIndex);
            _tvshowsCollectionHelper.CreateIndexAscending(u => u.FullTitle, titleFullIndex);
            _tvshowsCollectionHelper.CreateIndexAscending(u => u.OriginalTitle, titleOriginalIndex);

            _mapper = mapper;
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
            var filterByTitle = Builders<TvShow>.Filter.Empty;
            var filterByFullTitle = Builders<TvShow>.Filter.Empty;
            var filterByOriginalTitle = Builders<TvShow>.Filter.Empty;

            if (!(string.IsNullOrEmpty(tvShowParams.SearchedTvShow) || string.IsNullOrWhiteSpace(tvShowParams.SearchedTvShow)))
            {
                filterByTitle = Builders<TvShow>.Filter.Regex(x => x.Title, new BsonRegularExpression(tvShowParams.SearchedTvShow, "i"));
                filterByFullTitle = Builders<TvShow>.Filter.Regex(x => x.FullTitle, new BsonRegularExpression(tvShowParams.SearchedTvShow, "i"));
                filterByOriginalTitle = Builders<TvShow>.Filter.Regex(x => x.OriginalTitle, new BsonRegularExpression(tvShowParams.SearchedTvShow, "i"));

                filterByTitle = filterByTitle & filterByFullTitle & filterByOriginalTitle;
            }

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
    }
}
