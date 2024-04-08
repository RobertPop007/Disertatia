using Disertatie_backend.DTO;
using Disertatie_backend.Entities;
using Disertatie_backend.Extensions;
using Disertatie_backend.Helpers;
using Disertatie_backend.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;
using Microsoft.AspNetCore.Identity;
using System;
using MongoDB.Bson;

namespace Disertatie_backend.DatabaseContext
{
    public class AddFriendsRepository : IAddFriendsRepository
    {
        private readonly DataContext _context;
        private readonly UserManager<AppUser> _userManager;

        public AddFriendsRepository(DataContext context, UserManager<AppUser> userManager)
        {
            this._context = context;
            this._userManager = userManager;
        }

        public async Task<UserFriend> GetUserFriend(ObjectId addedByUserId, ObjectId addedUserId)
        {
            return await _context.Friends.FindAsync(addedByUserId, addedUserId);
        }

        public async Task<PagedList<FriendsDto>> GetUserFriends(AddFriendParams friendsParams)
        {
            var users = _userManager.Users.OrderBy(u => u.UserName).AsQueryable();
            var friends = _context.Friends.AsQueryable();

            if(friendsParams.Predicate == "added")
            {
                friends = friends.Where(friend => friend.AddedByUserId == friendsParams.UserId);
                users = friends.Select(friend => friend.AddedUser);
            }

            if(friendsParams.Predicate == "addedBy")
            {
                friends = friends.Where(friend => friend.AddedUserId == friendsParams.UserId);
                users = friends.Select(friend => friend.AddedByUser);
            }

            var addedUsers = users.Select(user => new FriendsDto
            {
                Username = user.UserName,
                KnownAs = user.KnownAs,
                Age = user.DateOfBirth.CalculateAge(),
                PhotoUrl = user.ProfilePicture.Url,
                City = user.City,
                Id = Convert.ToInt32(user.Id)
            });

            return await PagedList<FriendsDto>.CreateAsync(addedUsers, friendsParams.PageNumber, friendsParams.PageSize);
        }

        public async Task<AppUser> GetUserWithFriends(ObjectId userId)
        {
            return await _userManager.FindByIdAsync(userId.ToString());
        }
    }
}
