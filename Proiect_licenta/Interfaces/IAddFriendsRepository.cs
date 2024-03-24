using Disertatie_backend.DTO;
using Disertatie_backend.Entities;
using Disertatie_backend.Helpers;
using System.Threading.Tasks;

namespace Disertatie_backend.Interfaces
{
    public interface IAddFriendsRepository
    {
        Task<UserFriend> GetUserFriend(int addedByUserId, int addedUserId);
        Task<AppUser> GetUserWithFriends(int userId);
        Task<PagedList<FriendsDto>> GetUserFriends(AddFriendParams addFriendParams);
    }
}
