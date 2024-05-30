using Microsoft.EntityFrameworkCore;
using Disertatie_backend.DTO.Manga;
using Disertatie_backend.Entities.Manga;
using Disertatie_backend.Helpers;
using Disertatie_backend.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Disertatie_backend.Configurations;
using AutoMapper;
using System;
using Disertatie_backend.Entities.User;
using AutoMapper.QueryableExtensions;

namespace Disertatie_backend.Repositories
{
    public class MangaRepository : IMangaRepository
    {
        private readonly IMongoCollection<DatumManga> _mangaCollection;
        private readonly IMongoDBCollectionHelper<DatumManga> _mangaCollectionHelper;
        private readonly DatabaseSettings _databaseSettings;

        private readonly IMapper _mapper;


        public MangaRepository(IMapper mapper,
            IMongoDBCollectionHelper<DatumManga> mangaCollectionHelper,
            DatabaseSettings databaseSettings)
        {
            _databaseSettings = databaseSettings;
            _mangaCollectionHelper = mangaCollectionHelper;
            _mangaCollection = _mangaCollectionHelper.CreateCollection(_databaseSettings);

            _mapper = mapper;
        }

        public async Task AddReviewAsync(ObjectId id, Review review)
        {
            var filter = Builders<DatumManga>.Filter.Eq(x => x.Id, id);
            var update = Builders<DatumManga>.Update.Push(x => x.ReviewsIds, review.ReviewId);

            await _mangaCollection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteReviewAsync(ObjectId id, Guid reviewId)
        {
            var filter = Builders<DatumManga>.Filter.Eq(x => x.Id, id);
            var update = Builders<DatumManga>.Update.Pull(x => x.ReviewsIds, reviewId);

            await _mangaCollection.UpdateOneAsync(filter, update);
        }

        public async Task<DatumManga> GetMangaByFullTitleAsync(string title)
        {
            var filterByTitle = Builders<DatumManga>.Filter.Eq(p => p.Title, title);
            return await _mangaCollection.Find(filterByTitle).FirstOrDefaultAsync();
        }

        public async Task<DatumManga> GetMangaByIdAsync(ObjectId id)
        {
            var filterById = Builders<DatumManga>.Filter.Eq(p => p.Id, id);
            return await _mangaCollection.Find(filterById).FirstOrDefaultAsync();
        }

        public async Task<PagedList<MangaCard>> GetMangasAsync(MangaParams mangaParams)
        {
            var query = Enumerable.Empty<DatumManga>().AsQueryable();
            var filterByTitle = Builders<DatumManga>.Filter.Empty;
            var filterByTitleEnglish = Builders<DatumManga>.Filter.Empty;
            var filterByTitleJapanese = Builders<DatumManga>.Filter.Empty;

            if (!(string.IsNullOrEmpty(mangaParams.SearchedManga) || string.IsNullOrWhiteSpace(mangaParams.SearchedManga)))
            {
                filterByTitle = Builders<DatumManga>.Filter.Regex(x => x.Title, new BsonRegularExpression(mangaParams.SearchedManga, "i"));
                filterByTitleEnglish = Builders<DatumManga>.Filter.Regex(x => x.TitleEnglish, new BsonRegularExpression(mangaParams.SearchedManga, "i"));
                filterByTitleJapanese = Builders<DatumManga>.Filter.Regex(x => x.TitleJapanese, new BsonRegularExpression(mangaParams.SearchedManga, "i"));

                filterByTitle = filterByTitle & filterByTitleEnglish & filterByTitleJapanese;

                query = _mangaCollection.Find(filterByTitle).ToList().AsQueryable();
            }
            else
                query = _mangaCollection.AsQueryable().AsQueryable();

            query = mangaParams.OrderBy switch
            {
                "title" => query.OrderBy(u => u.Title).OrderByDescending(u => u.Popularity),
                "score" => query.OrderByDescending(u => u.Score),
                "newest" => query.OrderByDescending(u => u.Published.Prop.From.Year),
                _ => query.OrderByDescending(u => u.ScoredBy)

            };

            return await PagedList<MangaCard>.CreateAsync(query.ProjectTo<MangaCard>(_mapper.ConfigurationProvider).AsNoTracking(),
                mangaParams.PageNumber, mangaParams.PageSize);
        }
    }
}
