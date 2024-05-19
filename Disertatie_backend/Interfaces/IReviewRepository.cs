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
        Task AddReviewToItem<T>(Guid userId, ObjectId itemId, ReviewDto reviewDto);
        Task DeleteReviewFromItem<T>(Guid userId, ObjectId itemId, Guid reviewId);
        Task UpdateReviewItem<T>(Guid userId, ObjectId itemId, Review review);
        Task<IEnumerable<Review>> GetReviewsForItem<T>(ObjectId itemId);
        Task<IEnumerable<Review>> GetReviewsForUserAsync(Guid userId);
        Task LikeReview(ObjectId itemId, Guid reviewId);
        Task DislikeReview(ObjectId itemId, Guid reviewId);
        Task<int> GetLikes(ObjectId itemId, Guid reviewId);
    }
}
