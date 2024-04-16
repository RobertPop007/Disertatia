﻿using AutoMapper;
using CloudinaryDotNet.Actions;
using Disertatie_backend.Configurations;
using Disertatie_backend.DTO;
using Disertatie_backend.DTO.Anime;
using Disertatie_backend.Entities;
using Disertatie_backend.Entities.Anime;
using Disertatie_backend.Entities.Movies;
using Disertatie_backend.Entities.User;
using Disertatie_backend.Helpers;
using Disertatie_backend.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Disertatie_backend.Repositories
{
    public class AnimeRepository : IAnimeRepository
    {
        private readonly IMongoCollection<Datum> _animeCollection;
        private readonly IMongoDBCollectionHelper<Datum> _animeCollectionHelper;
        private readonly string titleIndex = "Title_index";
        private readonly string titleEnglishIndex = "TitleEnglish_index";
        private readonly string titleJapaneseIndex = "TitleJapanese_index";
        private readonly DatabaseSettings _databaseSettings;

        private readonly IMapper _mapper;

        public AnimeRepository(IMapper mapper,
            IMongoDBCollectionHelper<Datum> animeCollectionHelper,
            DatabaseSettings databaseSettings)
        {
            _databaseSettings = databaseSettings;
            _animeCollectionHelper = animeCollectionHelper;
            _animeCollection = _animeCollectionHelper.CreateCollection(_databaseSettings);

            _animeCollectionHelper.CreateIndexAscending(u => u.Title, titleIndex);
            _animeCollectionHelper.CreateIndexAscending(u => u.Title_english, titleEnglishIndex);
            _animeCollectionHelper.CreateIndexAscending(u => u.Title_japanese, titleJapaneseIndex);

            _mapper = mapper;
        }

        public async Task AddReviewAsync(ObjectId id, ReviewDto reviewDto)
        {
            var filter = Builders<Datum>.Filter.Eq(x => x.Id, id);
            var update = Builders<Datum>.Update.Push(x => x.Reviews, reviewDto);

            await _animeCollection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteReviewAsync(ObjectId id, ReviewDto reviewDto)
        {
            var filter = Builders<Datum>.Filter.Eq(x => x.Id, id);
            var update = Builders<Datum>.Update.Pull(x => x.Reviews, reviewDto);

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

        public async Task<IEnumerable<AnimeCard>> GetAnimesAsync(AnimeParams animeParams)
        {
            var filterByTitle = Builders<Datum>.Filter.Empty;
            var filterByTitleEnglish = Builders<Datum>.Filter.Empty;
            var filterByTitleJapanese = Builders<Datum>.Filter.Empty;

            if (!(string.IsNullOrEmpty(animeParams.SearchedAnime) || string.IsNullOrWhiteSpace(animeParams.SearchedAnime)))
            {
                filterByTitle = Builders<Datum>.Filter.Regex(x => x.Title, new BsonRegularExpression(animeParams.SearchedAnime, "i"));
                filterByTitleEnglish = Builders<Datum>.Filter.Regex(x => x.Title_english, new BsonRegularExpression(animeParams.SearchedAnime, "i"));
                filterByTitleJapanese = Builders<Datum>.Filter.Regex(x => x.Title_japanese, new BsonRegularExpression(animeParams.SearchedAnime, "i"));

                filterByTitle = filterByTitle & filterByTitleEnglish & filterByTitleJapanese;
            }

            var query = await _animeCollection.Find(filterByTitle).ToListAsync();

            var queryList = new List<AnimeCard>();

            foreach (var document in query)
            {
                queryList.Add(_mapper.Map<AnimeCard>(document));
            }

            var mappedQuery = queryList.AsEnumerable();

            mappedQuery = animeParams.OrderBy switch
            {
                "title" => mappedQuery.OrderBy(u => u.Title).OrderByDescending(u => u.Popularity),
                "score" => mappedQuery.OrderByDescending(u => u.Score),
                _ => mappedQuery.OrderByDescending(u => u.Year)

            };

            return mappedQuery;
        }
    }
}
