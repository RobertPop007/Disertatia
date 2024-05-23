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
using System;
using Microsoft.EntityFrameworkCore;
using Disertatie_backend.Entities.User;

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
            _userRepository = userRepository;
            _addFriendsRepository = addFriendsRepository;
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FriendsDto>>> GetUserFriends([FromQuery] AddFriendParams addFriendParams)
        {
            addFriendParams.UserId = User.GetUserId();
            var users = await _addFriendsRepository.GetUserFriends(addFriendParams);

            Response.AddPaginationHeader(users.CurrentPage, users.PageSize, users.TotalCount, users.TotalPages);

            return Ok(users);
        }

        [HttpGet("CheckFriendship/{username}")]
        public async Task<bool> CheckFriendship([FromRoute] string username)
        {
            var userId = User.GetUserId();
            var currentUser = await _addFriendsRepository.GetUserWithFriends(userId);

            var friend = await _userManager.FindByNameAsync(username);

            if (friend == null) return false;

            var isUserFriend = await _context.Friends.FirstOrDefaultAsync(x => (x.UserID1 == userId && x.UserID2 == friend.Id) ||
                                                                                                           (x.UserID1 == friend.Id && x.UserID2 == userId));
            if (isUserFriend != null) return true;

            return false;
        }

        [HttpGet("GetUserFriendRequests")]
        public async Task<ActionResult<IEnumerable<FriendsRequestsDto>>> GetUserFriendsRequests([FromQuery] AddFriendParams addFriendRequestsParams)
        {
            addFriendRequestsParams.UserId = User.GetUserId();
            var users = await _addFriendsRepository.GetUserFriendsRequests(addFriendRequestsParams);

            Response.AddPaginationHeader(users.CurrentPage, users.PageSize, users.TotalCount, users.TotalPages);

            return Ok(users);
        }

        [HttpPost("AcceptFriendRequest/{username}")]
        public async Task<ActionResult> AddFriend(string username)
        {
            var addedByUserId = User.GetUserId();
            var addedUser = await _userRepository.GetUserByUsernameAsync(username);
            var addedByUser = await _addFriendsRepository.GetUserWithFriends(addedByUserId);

            if (addedUser == null) return NotFound();

            if (addedByUser.UserName == username) return BadRequest("You cannot add yourself");

            var isUserFriend = await _addFriendsRepository.IsUserFriend(addedByUserId, addedUser.Id);

            if (isUserFriend != null) return BadRequest("You are already friend with this user");

            var isUserInFriendRequestList = await _addFriendsRepository.IsUserInFriendRequests(addedUser.Id, addedByUserId);

            if (isUserInFriendRequestList == null) return BadRequest("This user is not in your friend request list");

            await _addFriendsRepository.RemoveFriendRequest(addedUser.Id, addedByUserId);

            _context.Friends.Add(new Friendships()
            {
                SinceDate = DateTime.Now,
                UserID1 = addedUser.Id,
                UserID2 = addedByUser.Id,
            });

            _context.SaveChanges();

            return Ok(addedUser);
        }

        [HttpPost("SendFriendRequest/{username}")]
        public async Task<ActionResult> SendFriendRequest(string username)
        {
            var addedByUserId = User.GetUserId();
            var addedUser = await _userRepository.GetUserByUsernameAsync(username);
            var addedByUser = await _addFriendsRepository.GetUserWithFriends(addedByUserId);

            if (addedUser == null) return NotFound();

            if (addedByUser.UserName == username) return BadRequest("You cannot request yourself");

            var isUserAlreadyInFriendRequestList = await _addFriendsRepository.IsUserInFriendRequests(addedUser.Id, addedByUserId);
            if (isUserAlreadyInFriendRequestList != null) return BadRequest("You already sent an friend request to this user");

            var isUserFriend = await _addFriendsRepository.IsUserFriend(addedByUserId, addedUser.Id);
            if (isUserFriend != null) return BadRequest("You are already friend with this user");
            
            _context.FriendsRequests.Add(new FriendRequest()
            {
                SinceDate= DateTime.Now,
                FromUserId = addedByUserId,
                ToUserId = addedUser.Id,
            });

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("DeleteFriend/{username}")]
        public async Task<ActionResult> RemoveFriend(string username)
        {
            var removedByUserId = User.GetUserId();
            var removedUser = await _userRepository.GetUserByUsernameAsync(username);
            var removedByUser = await _addFriendsRepository.GetUserWithFriends(removedByUserId);

            if (removedUser == null) return NotFound();

            if (removedByUser.UserName == username) return BadRequest("You cannot remove yourself");

            var friendship = await _context.Friends.SingleOrDefaultAsync(x => (x.UserID1 == removedUser.Id && x.UserID2 == removedByUserId) || 
                                                                                            (x.UserID1 == removedByUserId && x.UserID2 == removedUser.Id));

            if(friendship == null) return BadRequest("You are not friend with this user");

            _context.Friends.Remove(friendship);

            removedUser.Friends.Remove(friendship);
            removedByUser.Friends.Remove(friendship);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("CancelFriendRequest/{username}")]
        public async Task<ActionResult> CancelFriendRequest(string username)
        {
            var currentUserId = User.GetUserId();
            var userWithFriendRequest = await _userRepository.GetUserByUsernameAsync(username);
            var currentUser = await _addFriendsRepository.GetUserWithFriends(currentUserId);

            if (userWithFriendRequest == null) return NotFound();

            if (currentUser.UserName == username) return BadRequest("You cannot remove yourself");

            var sendRequestToUser = await _addFriendsRepository.IsUserInFriendRequests(currentUserId, userWithFriendRequest.Id);

            if (sendRequestToUser == null) return BadRequest("You are not in this user friend requests");

            userWithFriendRequest.FriendRequests.Remove(sendRequestToUser);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("RefuseFriendRequest/{username}")]
        public async Task<ActionResult> RefuseFriendRequest(string username)
        {
            var currentUserId = User.GetUserId();
            var userInFriendRequestList = await _userRepository.GetUserByUsernameAsync(username);
            var currentUser = await _addFriendsRepository.GetUserWithFriends(currentUserId);

            if (userInFriendRequestList == null) return NotFound();

            if (currentUser.UserName == username) return BadRequest("You cannot remove yourself");

            var friendRequest = await _addFriendsRepository.IsUserInFriendRequests(userInFriendRequestList.Id, currentUserId);

            if (friendRequest == null) return BadRequest("This user is not in your friend request list");

            currentUser.FriendRequests.Remove(friendRequest);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
