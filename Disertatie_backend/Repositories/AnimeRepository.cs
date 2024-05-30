using AutoMapper;
using AutoMapper.QueryableExtensions;
using Disertatie_backend.Configurations;
using Disertatie_backend.DTO.Anime;
using Disertatie_backend.Entities.Anime;
using Disertatie_backend.Entities.User;
using Disertatie_backend.Helpers;
using Disertatie_backend.Interfaces;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Disertatie_backend.Repositories
{
    public class AnimeRepository : IAnimeRepository
    {
        private readonly IMongoCollection<Datum> _animeCollection;
        private readonly IMongoDBCollectionHelper<Datum> _animeCollectionHelper;
        private readonly DatabaseSettings _databaseSettings;

        private readonly IMapper _mapper;

        public AnimeRepository(IMapper mapper,
            IMongoDBCollectionHelper<Datum> animeCollectionHelper,
            DatabaseSettings databaseSettings)
        {
            _databaseSettings = databaseSettings;
            _animeCollectionHelper = animeCollectionHelper;
            _animeCollection = _animeCollectionHelper.CreateCollection(_databaseSettings);

            _mapper = mapper;
        }

        public async Task AddReviewAsync(ObjectId id, Review review)
        {
            var filter = Builders<Datum>.Filter.Eq(x => x.Id, id);
            var update = Builders<Datum>.Update.Push(x => x.ReviewsIds, review.ReviewId);

            await _animeCollection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteReviewAsync(ObjectId id, Guid reviewId)
        {
            var filter = Builders<Datum>.Filter.Eq(x => x.Id, id);
            var update = Builders<Datum>.Update.Pull(x => x.ReviewsIds, reviewId);

            await _animeCollection.UpdateOneAsync(filter, update);
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

        public async Task<PagedList<AnimeCard>> GetAnimesAsync(AnimeParams animeParams)
        {
            var query = Enumerable.Empty<Datum>().AsQueryable();
            var filterByTitle = Builders<Datum>.Filter.Empty;
            var filterByTitleEnglish = Builders<Datum>.Filter.Empty;
            var filterByTitleJapanese = Builders<Datum>.Filter.Empty;

            if (!(string.IsNullOrEmpty(animeParams.SearchedAnime) || string.IsNullOrWhiteSpace(animeParams.SearchedAnime)))
            {
                filterByTitle = Builders<Datum>.Filter.Regex(x => x.Title, new BsonRegularExpression(animeParams.SearchedAnime, "i"));
                filterByTitleEnglish = Builders<Datum>.Filter.Regex(x => x.TitleEnglish, new BsonRegularExpression(animeParams.SearchedAnime, "i"));
                filterByTitleJapanese = Builders<Datum>.Filter.Regex(x => x.TitleJapanese, new BsonRegularExpression(animeParams.SearchedAnime, "i"));

                filterByTitle = filterByTitle & filterByTitleEnglish & filterByTitleJapanese;

                query = _animeCollection.Find(filterByTitle).ToList().AsQueryable();
            }
            else
                query = _animeCollection.AsQueryable().AsQueryable();

            query = animeParams.OrderBy switch
            {
                "title" => query.OrderBy(u => u.Title).OrderByDescending(u => u.Popularity),
                "score" => query.OrderByDescending(u => u.Score),
                "newest" => query.Where(u => u.Year <= DateTime.Today.Year).OrderByDescending(u => u.Year),
                _ => query.OrderByDescending(u => u.ScoredBy)
            };

            return await PagedList<AnimeCard>.CreateAsync(query.ProjectTo<AnimeCard>(_mapper.ConfigurationProvider).AsNoTracking(),
                animeParams.PageNumber, animeParams.PageSize);
        }
    }
}
