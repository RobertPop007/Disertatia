using Proiect_licenta.DTO;
using Proiect_licenta.Entities;
using Proiect_licenta.Helpers;
using System.Threading.Tasks;

namespace Proiect_licenta.Interfaces;

public interface IAddFriendsRepository
{
    Task<UserFriend> GetUserFriend(int addedByUserId, int addedUserId);
    Task<AppUser> GetUserWithFriends(int userId);
    Task<PagedList<FriendsDto>> GetUserFriends(AddFriendParams addFriendParams);
}
