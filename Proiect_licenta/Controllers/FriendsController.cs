using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Disertatie_backend.DatabaseContext;
using Disertatie_backend.DTO;
using Disertatie_backend.Entities;
using Disertatie_backend.Extensions;
using Disertatie_backend.Helpers;
using Disertatie_backend.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MongoDB.Bson;

namespace Disertatie_backend.Controllers
{
    [Authorize]
    public class FriendsController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly DataContext _context;
        private readonly IAddFriendsRepository _addFriendsRepository;
        private readonly UserManager<AppUser> _userManager;

        public FriendsController(IUserRepository userRepository, DataContext context, IAddFriendsRepository addFriendsRepository, UserManager<AppUser> userManager)
        {
            this._userRepository = userRepository;
            this._addFriendsRepository = addFriendsRepository;
            _context = context;
            _userManager = userManager;
        }

        [HttpPost("{username}")]
        public async Task<ActionResult> AddFriend(string username)
        {
            var addedByUserId = User.GetUserId();
            var addedUser = await _userRepository.GetUserByUsernameAsync(username);
            var addedByUser = await _addFriendsRepository.GetUserWithFriends(addedByUserId);

            if (addedUser == null) return NotFound();

            if (addedByUser.UserName == username) return BadRequest("You cannot like yourself");

            var userFriend = await _addFriendsRepository.GetUserFriend(addedUser.Id);

            if (userFriend != null) return BadRequest("You are already friend with this user");

            addedByUser.Friends.Add(addedUser.Id);

            return Ok();
        }

        [HttpDelete("{username}")]
        public async Task<ActionResult> RemoveFriend(string username)
        {
            var removedByUserId = User.GetUserId();
            var removedUser = await _userRepository.GetUserByUsernameAsync(username);
            var removedByUser = await _addFriendsRepository.GetUserWithFriends(removedByUserId);

            if (removedUser == null) return NotFound();

            if (removedByUser.UserName == username) return BadRequest("You cannot remove yourself");

            var userFriend = await _addFriendsRepository.GetUserFriend(removedUser.Id);

            if (userFriend == null) return BadRequest("You are not friend with this user");

            var connection = _context.Users.Where(o => o.Friends.Contains( removedUser.Id)).FirstOrDefault();
            _context.Users.Remove(connection);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FriendsDto>>> GetUserFriends([FromQuery] AddFriendParams addFriendParams)
        {
            addFriendParams.UserId = User.GetUserId();
            var users =  await _addFriendsRepository.GetUserFriends(addFriendParams);

            Response.AddPaginationHeader(users.CurrentPage, users.PageSize, users.TotalCount, users.TotalPages);

            return Ok(users);
        }

        [HttpGet("CheckFriendship/{username}")]
        public async Task<bool> CheckFriendship([FromRoute] string username)
        {
            var userId = User.GetUserId();
            var currentUser = await _addFriendsRepository.GetUserWithFriends(userId);

            var friend = await _userManager.FindByNameAsync(username);

            if(friend == null) return false;

            if(currentUser.Friends.Contains(friend.Id)) return true;

            return false;
        }
    }
}
