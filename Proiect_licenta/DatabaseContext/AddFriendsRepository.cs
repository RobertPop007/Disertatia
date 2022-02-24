using Microsoft.EntityFrameworkCore;
using Proiect_licenta.DTO;
using Proiect_licenta.Entities;
using Proiect_licenta.Extensions;
using Proiect_licenta.Helpers;
using Proiect_licenta.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_licenta.DatabaseContext
{
    public class AddFriendsRepository : IAddFriendsRepository
    {
        private readonly DataContext _context;

        public AddFriendsRepository(DataContext context)
        {
            this._context = context;
        }


        public async Task<UserFriend> GetUserFriend(int addedByUserId, int addedUserId)
        {
            return await _context.Friends.FindAsync(addedByUserId, addedUserId);
        }

        public async Task<PagedList<FriendsDto>> GetUserFriends(AddFriendParams friendsParams)
        {
            var users = _context.Users.OrderBy(u => u.UserName).AsQueryable();
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
                Id = user.Id
            });

            return await PagedList<FriendsDto>.CreateAsync(addedUsers, friendsParams.PageNumber, friendsParams.PageSize);
        }

        public async Task<AppUser> GetUserWithFriends(int userId)
        {
            return await _context.Users
                 .Include(x => x.AddedUsers)
                 .FirstOrDefaultAsync(x => x.Id == userId);
        }
    }
}
