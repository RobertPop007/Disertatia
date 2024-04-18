using Microsoft.EntityFrameworkCore;
using Disertatie_backend.DTO.Manga;
using Disertatie_backend.Entities.Manga;
using Disertatie_backend.Helpers;
using Disertatie_backend.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Disertatie_backend.Entities;
using Disertatie_backend.Configurations;
using AutoMapper;
using System;
using Disertatie_backend.DTO;
using Disertatie_backend.Entities.Anime;
using Disertatie_backend.Entities.Games.Game;
using Disertatie_backend.Entities.User;

namespace Disertatie_backend.Repositories
{
    public class MangaRepository : IMangaRepository
    {
        private readonly IMongoCollection<DatumManga> _mangaCollection;
        private readonly IMongoDBCollectionHelper<DatumManga> _mangaCollectionHelper;
        private readonly string titleIndex = "Title_index";
        private readonly string titleEnglishIndex = "TitleEnglish_index";
        private readonly string titleJapaneseIndex = "TitleJapanese_index";
        private readonly DatabaseSettings _databaseSettings;

        private readonly IMapper _mapper;


        public MangaRepository(IMapper mapper,
            IMongoDBCollectionHelper<DatumManga> mangaCollectionHelper,
            DatabaseSettings databaseSettings)
        {
            _databaseSettings = databaseSettings;
            _mangaCollectionHelper = mangaCollectionHelper;
            _mangaCollection = _mangaCollectionHelper.CreateCollection(_databaseSettings);

            _mangaCollectionHelper.CreateIndexAscending(u => u.Title, titleIndex);
            _mangaCollectionHelper.CreateIndexAscending(u => u.Title_english, titleEnglishIndex);
            _mangaCollectionHelper.CreateIndexAscending(u => u.Title_japanese, titleJapaneseIndex);

            _mapper = mapper;
        }

        public async Task AddReviewAsync(ObjectId id, ReviewDto reviewDto)
        {
            var filter = Builders<DatumManga>.Filter.Eq(x => x.Id, id);
            var update = Builders<DatumManga>.Update.Push(x => x.Reviews, reviewDto);

            await _mangaCollection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteReviewAsync(ObjectId id, ReviewDto reviewDto)
        {
            var filter = Builders<DatumManga>.Filter.Eq(x => x.Id, id);
            var update = Builders<DatumManga>.Update.Pull(x => x.Reviews, reviewDto);

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

        public async Task<IEnumerable<MangaCard>> GetMangasAsync(MangaParams mangaParams)
        {
            var filterByTitle = Builders<DatumManga>.Filter.Empty;
            var filterByTitleEnglish = Builders<DatumManga>.Filter.Empty;
            var filterByTitleJapanese = Builders<DatumManga>.Filter.Empty;

            if (!(string.IsNullOrEmpty(mangaParams.SearchedManga) || string.IsNullOrWhiteSpace(mangaParams.SearchedManga)))
            {
                filterByTitle = Builders<DatumManga>.Filter.Regex(x => x.Title, new BsonRegularExpression(mangaParams.SearchedManga, "i"));
                filterByTitleEnglish = Builders<DatumManga>.Filter.Regex(x => x.Title_english, new BsonRegularExpression(mangaParams.SearchedManga, "i"));
                filterByTitleJapanese = Builders<DatumManga>.Filter.Regex(x => x.Title_japanese, new BsonRegularExpression(mangaParams.SearchedManga, "i"));

                filterByTitle = filterByTitle & filterByTitleEnglish & filterByTitleJapanese;
            }

            var query = await _mangaCollection.Find(filterByTitle).ToListAsync();

            var queryList = new List<MangaCard>();

            foreach (var document in query)
            {
                queryList.Add(_mapper.Map<MangaCard>(document));
            }

            var mappedQuery = queryList.AsEnumerable();

            mappedQuery = mangaParams.OrderBy switch
            {
                "title" => mappedQuery.OrderBy(u => u.Title).OrderByDescending(u => u.Popularity),
                "score" => mappedQuery.OrderByDescending(u => u.Score),
                _ => mappedQuery.OrderByDescending(u => u.Year)

            };

            return mappedQuery;
        }
    }
}
