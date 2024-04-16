using Disertatie_backend.Entities.User;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disertatie_backend.Interfaces
{
    public interface IUserItemsRepository<T>
    {
        Task AddItemToUser<T>(AppUser user, ObjectId itemId);
        Task DeleteItemFromUser<T>(AppUser user, ObjectId itemId);
        Task<IEnumerable<T>> GetItemsForUser<T>(Guid userId);
        Task<bool> IsItemAlreadyAdded(Guid userId, ObjectId itemId);
    }
}
