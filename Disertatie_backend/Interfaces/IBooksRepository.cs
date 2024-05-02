using Disertatie_backend.DTO;
using Disertatie_backend.DTO.Books;
using Disertatie_backend.Entities.Books;
using Disertatie_backend.Helpers;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disertatie_backend.Interfaces
{
    public interface IBooksRepository
    {
        Task<IEnumerable<BookCard>> GetBooksAsync(BookParams bookParams);
        Task<Book> GetBookByIdAsync(ObjectId id);
        Task<Book> GetBookByTitleAsync(string title);
        Task AddReviewAsync(ObjectId id, ReviewDto reviewDto);
        Task DeleteReviewAsync(ObjectId id, ReviewDto reviewDto);
    }
}
