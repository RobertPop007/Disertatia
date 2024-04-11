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
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Disertatie_backend.DatabaseContext
{
    public class AddFriendsRepository : IAddFriendsRepository
    {
        private readonly DataContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AddFriendsRepository(DataContext context, UserManager<AppUser> userManager, IMapper mapper)
        {
            this._context = context;
            this._userManager = userManager;
            this._mapper = mapper;
        }

        public async Task<Friendships> IsUserFriend(Guid addedByUserId, Guid addedUserId)
        {
            return await _context.Friends.FindAsync(addedByUserId, addedUserId);
        }

        public async Task<PagedList<FriendsDto>> GetUserFriends(AddFriendParams friendsParams)
        {
            var users = _context.Users.OrderBy(u => u.LastActive).AsQueryable();
            var friends = _context.Friends.AsQueryable();

            friends = friends.Where(friend => friend.UserID1 == friendsParams.UserId || friend.UserID2 == friendsParams.UserId);
            
            return await PagedList<FriendsDto>.CreateAsync(friends.ProjectTo<FriendsDto>(_mapper.ConfigurationProvider).AsNoTracking(), friendsParams.PageNumber, friendsParams.PageSize);
        }

        public async Task<AppUser> GetUserWithFriends(Guid userId)
        {
            return await _userManager.FindByIdAsync(userId.ToString());
        }
    }
}
