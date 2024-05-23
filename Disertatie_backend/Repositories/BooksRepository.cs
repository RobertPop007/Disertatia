using AutoMapper;
using CloudinaryDotNet.Actions;
using Disertatie_backend.Configurations;
using Disertatie_backend.DTO;
using Disertatie_backend.DTO.Books;
using Disertatie_backend.DTO.Game;
using Disertatie_backend.Entities.Books;
using Disertatie_backend.Entities.Games.Game;
using Disertatie_backend.Entities.User;
using Disertatie_backend.Helpers;
using Disertatie_backend.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disertatie_backend.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly IMongoCollection<Book> _booksCollection;
        private readonly IMongoDBCollectionHelper<Book> _booksCollectionHelper;
        private readonly string titleIndex = "Title_index";
        private readonly DatabaseSettings _databaseSettings;

        private readonly IMapper _mapper;

        public BooksRepository(IMapper mapper,
            IMongoDBCollectionHelper<Book> booksCollectionHelper,
            DatabaseSettings databaseSettings)
        {
            _databaseSettings = databaseSettings;
            _booksCollectionHelper = booksCollectionHelper;
            _booksCollection = _booksCollectionHelper.CreateCollection(_databaseSettings);

            //_booksCollectionHelper.CreateIndexAscending(u => u.Title, titleIndex);

            _mapper = mapper;
        }

        public async Task AddReviewAsync(ObjectId id, Review review)
        {
            var filter = Builders<Book>.Filter.Eq(x => x.Id, id);
            var update = Builders<Book>.Update.Push(x => x.ReviewsIds, review.ReviewId);

            await _booksCollection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteReviewAsync(ObjectId id, Guid reviewId)
        {
            var filter = Builders<Book>.Filter.Eq(x => x.Id, id);
            var update = Builders<Book>.Update.Pull(x => x.ReviewsIds, reviewId);

            await _booksCollection.UpdateOneAsync(filter, update);
        }

        public async Task<Book> GetBookByIdAsync(ObjectId id)
        {
            var filterById = Builders<Book>.Filter.Eq(p => p.Id, id);
            return await _booksCollection.Find(filterById).FirstOrDefaultAsync();
        }

        public async Task<Book> GetBookByTitleAsync(string title)
        {
            var filterByName = Builders<Book>.Filter.Eq(p => p.Title, title);
            return await _booksCollection.Find(filterByName).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<BookCard>> GetBooksAsync(BookParams bookParams)
        {
            var filterByName = Builders<Book>.Filter.Empty;

            if (!(string.IsNullOrEmpty(bookParams.SearchedBook) || string.IsNullOrWhiteSpace(bookParams.SearchedBook)))
            {
                filterByName = Builders<Book>.Filter.Regex(x => x.Title, new BsonRegularExpression(bookParams.SearchedBook, "i"));
            }

            var query = await _booksCollection.Find(filterByName).ToListAsync();

            var queryList = new List<BookCard>();

            foreach (var document in query)
            {
                queryList.Add(_mapper.Map<BookCard>(document));
            }

            var mappedQuery = queryList.AsEnumerable();

            mappedQuery = bookParams.OrderBy switch
            {
                "title" => mappedQuery.OrderBy(u => u.Title).OrderByDescending(u => u.AverageRating),
                "averageRating" => mappedQuery.OrderByDescending(u => u.AverageRating),
                _ => mappedQuery.OrderByDescending(u => u.BookID)

            };

            return mappedQuery;
        }
    }
}
