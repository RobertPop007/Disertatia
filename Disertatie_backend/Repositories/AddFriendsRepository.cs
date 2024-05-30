using Disertatie_backend.DTO;
using Disertatie_backend.Extensions;
using Disertatie_backend.Helpers;
using Disertatie_backend.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;
using Microsoft.AspNetCore.Identity;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using AutoMapper;
using Disertatie_backend.DatabaseContext;
using Disertatie_backend.Entities.User;

namespace Disertatie_backend.Repositories
{
    public class AddFriendsRepository : IAddFriendsRepository
    {
        private readonly DataContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AddFriendsRepository(DataContext context, UserManager<AppUser> userManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<Friendships> IsUserFriend(Guid addedByUserId, Guid addedUserId)
        {
            return await _context.Friends.FindAsync(addedByUserId, addedUserId);
        }

        public async Task<FriendRequest> IsUserInFriendRequests(Guid fromUser, Guid toUser)
        {
            return await _context.FriendsRequests.FindAsync(fromUser, toUser);
        }

        public async Task<PagedList<FriendsDto>> GetUserFriends(AddFriendParams friendsParams)
        {
            var users = _context.Users.Where(u => u.Id != friendsParams.UserId).OrderBy(u => u.LastActive).AsQueryable();
            var friends = _context.Friends.AsQueryable();

            friends = friends.Where(friend => friend.UserID1 == friendsParams.UserId || friend.UserID2 == friendsParams.UserId);

            var friendsList = new List<FriendsDto>();
            foreach (var friend in friends)
            {
                var user = await _context.Users.Where(u => (u.Id == friend.UserID1 || u.Id == friend.UserID2) && u.Id != friendsParams.UserId).Include(u => u.Photos).FirstOrDefaultAsync();

                var friendToAdd = new FriendsDto()
                {
                    Age = user.DateOfBirth.CalculateAge(),
                    City = user.City,
                    Id = user.Id,
                    KnownAs = user.KnownAs,
                    PhotoUrl = user.Photos.Url,
                    UserName = user.UserName
                };

                friendsList.Add(friendToAdd);
            }

            return await PagedList<FriendsDto>.CreateAsync(friendsList.AsQueryable(), friendsParams.PageNumber, friendsParams.PageSize);
        }

        public async Task<PagedList<FriendsRequestsDto>> GetUserFriendsRequests(AddFriendParams friendsRequestsParams)
        {
            var users = _context.Users.OrderBy(u => u.LastActive).AsQueryable();
            var friendsRequests = _context.FriendsRequests.AsQueryable();

            friendsRequests = friendsRequests.Where(friend => friend.ToUserId == friendsRequestsParams.UserId);

            var friendsRequestList = new List<FriendsRequestsDto>();
            foreach (var friendRequest in friendsRequests)
            {
                var user = await _context.Users.Where(u => u.Id == friendRequest.FromUserId).Include(u => u.Photos).FirstOrDefaultAsync();

                var friendRequestToAdd = new FriendsRequestsDto()
                {
                    Id = user.Id,
                    KnownAs = user.KnownAs,
                    PhotoUrl = user.Photos.Url,
                    UserName = user.UserName
                };

                friendsRequestList.Add(friendRequestToAdd);
            }

            return await PagedList<FriendsRequestsDto>.CreateAsync(friendsRequestList.AsQueryable(), friendsRequestsParams.PageNumber, friendsRequestsParams.PageSize);
        }

        public async Task<AppUser> GetUserWithFriends(Guid userId)
        {
            return await _userManager.FindByIdAsync(userId.ToString());
        }

        public async Task RemoveFriendRequest(Guid fromUser, Guid toUser)
        {
            var friendRequest = await _context.FriendsRequests.FindAsync(fromUser, toUser);
            _context.FriendsRequests.Remove(friendRequest);

            await _context.SaveChangesAsync();
        }
    }
}
