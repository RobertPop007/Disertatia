using Disertatie_backend.DTO;
using Disertatie_backend.Entities;
using Disertatie_backend.Helpers;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace Disertatie_backend.Interfaces
{
    public interface IAddFriendsRepository
    {
        Task<UserFriend> GetUserFriend(ObjectId addedByUserId, ObjectId addedUserId);
        Task<AppUser> GetUserWithFriends(ObjectId userId);
        Task<PagedList<FriendsDto>> GetUserFriends(AddFriendParams addFriendParams);
    }
}
