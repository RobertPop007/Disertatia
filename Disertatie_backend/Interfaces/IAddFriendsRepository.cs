using Disertatie_backend.DTO;
using Disertatie_backend.Entities.User;
using Disertatie_backend.Helpers;
using System;
using System.Threading.Tasks;

namespace Disertatie_backend.Interfaces
{
    public interface IAddFriendsRepository
    {
        Task<Friendships> IsUserFriend(Guid addedByUserId, Guid addedUserId);
        Task<FriendRequest> IsUserInFriendRequests(Guid fromUser, Guid toUser);
        Task<AppUser> GetUserWithFriends(Guid userId);
        Task<PagedList<FriendsDto>> GetUserFriends(AddFriendParams addFriendParams);
        Task<PagedList<FriendsRequestsDto>> GetUserFriendsRequests(AddFriendParams friendsRequestsParams);
        Task RemoveFriendRequest(Guid fromUser, Guid toUser);
    }
}
