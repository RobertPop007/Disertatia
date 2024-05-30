using Disertatie_backend.DTO.Books;
using Disertatie_backend.Entities.Books;
using Disertatie_backend.Entities.User;
using Disertatie_backend.Helpers;
using MongoDB.Bson;
using System;
using System.Threading.Tasks;

namespace Disertatie_backend.Interfaces
{
    public interface IBooksRepository
    {
        Task<PagedList<BookCard>> GetBooksAsync(BookParams bookParams);
        Task<Book> GetBookByIdAsync(ObjectId id);
        Task<Book> GetBookByTitleAsync(string title);
        Task AddReviewAsync(ObjectId id, Review review);
        Task DeleteReviewAsync(ObjectId id, Guid reviewId);
    }
}
