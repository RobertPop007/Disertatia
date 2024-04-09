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

        public async Task<bool> IsUserFriend(Guid addedByUserId, Guid addedUserId)
        {
            var user = await _context.Users.Where(x => x.Id == addedByUserId).FirstOrDefaultAsync();

            return user.Friends.Contains(addedUserId);
        }

        public async Task<PagedList<FriendsDto>> GetUserFriends(AddFriendParams friendsParams)
        {
            var user = await _userManager.Users.Where(u => u.Id == friendsParams.UserId).FirstOrDefaultAsync();
            var friends = user.Friends.AsQueryable();

            var userFriends = new List<FriendsDto>();
            foreach(var friend in friends)
            {
                var userFriend = _context.Users.Where(u => u.Id == friend).FirstOrDefault();
                userFriends.Add(_mapper.Map<FriendsDto>(userFriend));
            }

            //var addedUsers = friends.Select(user => new FriendsDto
            //{
            //    Username = user.UserName,
            //    KnownAs = user.KnownAs,
            //    Age = user.DateOfBirth.CalculateAge(),
            //    PhotoUrl = user.ProfilePicture.Url,
            //    City = user.City,
            //    Id = Convert.ToInt32(user.Id)
            //});

            return await PagedList<FriendsDto>.CreateAsync(userFriends.AsQueryable(), friendsParams.PageNumber, friendsParams.PageSize);
        }

        public async Task<AppUser> GetUserWithFriends(Guid userId)
        {
            return await _userManager.FindByIdAsync(userId.ToString());
        }
    }
}
