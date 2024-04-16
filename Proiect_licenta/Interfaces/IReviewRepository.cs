using Disertatie_backend.DTO;
using Disertatie_backend.Entities.User;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disertatie_backend.Interfaces
{
    public interface IReviewRepository<T>
    {
        Task AddReviewToItem<T>(AppUser user, ObjectId itemId, ReviewDto reviewDto);
        Task DeleteReviewFromItem<T>(AppUser user, ObjectId itemId, Guid reviewId);
        Task UpdateReviewItem<T>(AppUser user, ObjectId itemId, Review review);
        Task<IEnumerable<ReviewDto>> GetReviewsForItem<T>(ObjectId itemId);
    }
}
