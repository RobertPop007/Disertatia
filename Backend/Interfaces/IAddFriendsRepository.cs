using Backend.DTO;
using Backend.Entities;
using Backend.Helpers;
using System.Threading.Tasks;

namespace Backend.Interfaces;

public interface IAddFriendsRepository
{
    Task<UserFriend> GetUserFriend(int addedByUserId, int addedUserId);
    Task<AppUser> GetUserWithFriends(int userId);
    Task<PagedList<FriendsDto>> GetUserFriends(AddFriendParams addFriendParams);
}
