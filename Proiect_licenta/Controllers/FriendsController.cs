using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proiect_licenta.DatabaseContext;
using Proiect_licenta.DTO;
using Proiect_licenta.Entities;
using Proiect_licenta.Extensions;
using Proiect_licenta.Helpers;
using Proiect_licenta.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_licenta.Controllers
{
    [Authorize]
    public class FriendsController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly DataContext _context;
        private readonly IAddFriendsRepository _addFriendsRepository;

        public FriendsController(IUserRepository userRepository, DataContext context, IAddFriendsRepository addFriendsRepository)
        {
            this._userRepository = userRepository;
            this._addFriendsRepository = addFriendsRepository;
            _context = context;
        }

        [HttpPost("{username}")]
        public async Task<ActionResult> AddFriend(string username)
        {
            var addedByUserId = User.GetUserId();
            var addedUser = await _userRepository.GetUserByUsernameAsync(username);
            var addedByUser = await _addFriendsRepository.GetUserWithFriends(addedByUserId);

            if (addedUser == null) return NotFound();

            if (addedByUser.UserName == username) return BadRequest("You cannot like yourself");

            var userFriend = await _addFriendsRepository.GetUserFriend(addedByUserId, addedUser.Id);

            if (userFriend != null) return BadRequest("You are already friend with this user");

            userFriend = new UserFriend
            {
                AddedByUserId = addedByUserId,
                AddedUserId = addedUser.Id
            };

            var userAddedby = new UserFriend
            {
                AddedByUserId = addedUser.Id,
                AddedUserId = addedByUserId
            };

            addedByUser.AddedUsers.Add(userFriend);
            addedUser.AddedUsers.Add(userAddedby);

            if (await _userRepository.SaveAllAsync()) return Ok();

            return BadRequest("Failed to like user");
        }

        [HttpDelete("{username}")]
        public async Task<ActionResult> RemoveFriend(string username)
        {
            var removedByUserId = User.GetUserId();
            var removedUser = await _userRepository.GetUserByUsernameAsync(username);
            var removedByUser = await _addFriendsRepository.GetUserWithFriends(removedByUserId);

            if (removedUser == null) return NotFound();

            if (removedByUser.UserName == username) return BadRequest("You cannot remove yourself");

            var userFriend = await _addFriendsRepository.GetUserFriend(removedByUserId, removedUser.Id);

            if (userFriend == null) return BadRequest("You are not friend with this user");

            userFriend = new UserFriend
            {
                AddedByUserId = removedByUserId,
                AddedUserId = removedUser.Id
            };

            var connection = _context.Friends.Where(o => o.AddedUserId == removedUser.Id && o.AddedByUserId == removedByUserId).FirstOrDefault();
            _context.Friends.Remove(connection);

            if (await _userRepository.SaveAllAsync()) return Ok();

            return BadRequest("Failed to remove user");
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

            var friend = _context.Users.Where(o => o.UserName == username).FirstOrDefault();

            if(friend == null) return false;

            foreach (var addedUser in currentUser.AddedUsers)
            {
                if (friend.Id == addedUser.AddedUserId)
                    return true;
            }
            foreach (var addedUser in currentUser.AddedByUsers)
            {
                if (friend.Id == addedUser.AddedByUserId)
                    return true;
            }


            return false;
        }
    }
}
