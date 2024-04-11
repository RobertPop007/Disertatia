using Disertatie_backend.DTO;
using Disertatie_backend.Entities;
using Disertatie_backend.Helpers;
using MongoDB.Bson;
using System;
using System.Threading.Tasks;

namespace Disertatie_backend.Interfaces
{
    public interface IAddFriendsRepository
    {
        Task<Friendships> IsUserFriend(Guid addedByUserId, Guid addedUserId);
        Task<AppUser> GetUserWithFriends(Guid userId);
        Task<PagedList<FriendsDto>> GetUserFriends(AddFriendParams addFriendParams);
    }
}
