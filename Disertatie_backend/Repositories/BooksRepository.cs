using AutoMapper;
using AutoMapper.QueryableExtensions;
using Disertatie_backend.Configurations;
using Disertatie_backend.DTO.Books;
using Disertatie_backend.Entities.Books;
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
    public class BooksRepository : IBooksRepository
    {
        private readonly IMongoCollection<Book> _booksCollection;
        private readonly IMongoDBCollectionHelper<Book> _booksCollectionHelper;
        private readonly DatabaseSettings _databaseSettings;

        private readonly IMapper _mapper;

        public BooksRepository(IMapper mapper,
            IMongoDBCollectionHelper<Book> booksCollectionHelper,
            DatabaseSettings databaseSettings)
        {
            _databaseSettings = databaseSettings;
            _booksCollectionHelper = booksCollectionHelper;
            _booksCollection = _booksCollectionHelper.CreateCollection(_databaseSettings);

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

        public async Task<PagedList<BookCard>> GetBooksAsync(BookParams bookParams)
        {
            var query = Enumerable.Empty<Book>().AsQueryable();
            var filterByName = Builders<Book>.Filter.Empty;

            if (!(string.IsNullOrEmpty(bookParams.SearchedBook) || string.IsNullOrWhiteSpace(bookParams.SearchedBook)))
            {
                filterByName = Builders<Book>.Filter.Regex(x => x.Title, new BsonRegularExpression(bookParams.SearchedBook, "i"));

                query = _booksCollection.Find(filterByName).ToList().AsQueryable();
            }
            else
                query = _booksCollection.AsQueryable().AsQueryable();

            query = bookParams.OrderBy switch
            {
                "title" => query.OrderBy(u => u.Title).OrderByDescending(u => u.AverageRating),
                "averageRating" => query.OrderByDescending(u => u.AverageRating),
                _ => query.OrderByDescending(u => u.RatingsCount)

            };

            query = query.OrderBy(x => x.CoverUrl);

            return await PagedList<BookCard>.CreateAsync(query.ProjectTo<BookCard>(_mapper.ConfigurationProvider).AsNoTracking(),
                 bookParams.PageNumber, bookParams.PageSize);
        }
    }
}
