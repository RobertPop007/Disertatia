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
    //[Authorize]
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

        [HttpPost("/AcceptFriendRequest/{username}")]
        public async Task<ActionResult> AddFriend(string username)
        {
            var addedByUserId = new Guid("0A5AAA80-3373-49C2-1D57-08DC58ADDFE4");
            var addedUser = await _userRepository.GetUserByUsernameAsync(username);
            var addedByUser = await _addFriendsRepository.GetUserWithFriends(addedByUserId);

            if (addedUser == null) return NotFound();

            if (addedByUser.UserName == username) return BadRequest("You cannot add yourself");

            var isUserFriend = await _addFriendsRepository.IsUserFriend(addedByUserId, addedUser.Id);

            if (isUserFriend != null) return BadRequest("You are already friend with this user");

            var isUserInFriendRequestList = addedByUser.FriendRequests.FirstOrDefault(x => x == addedUser.Id);

            if (isUserInFriendRequestList == Guid.Empty) return BadRequest("This user is not in your friend request list");

            addedByUser.FriendRequests.Remove(addedUser.Id);

            _context.Friends.Add(new Friendships()
            {
                SinceDate = DateTime.Now,
                UserID1 = addedUser.Id,
                UserID2 = addedByUser.Id,
            });

            await _context.SaveChangesAsync();

            return Ok($"Successfully added {username} as a friend");
        }

        [HttpPost("/SendFriendRequest/{username}")]
        public async Task<ActionResult> SendFriendRequest(string username)
        {
            var addedByUserId = new Guid("DFF8FFF1-EF29-4C60-1D51-08DC58ADDFE4"); //User.GetUserId();
            var addedUser = await _userRepository.GetUserByUsernameAsync(username);
            var addedByUser = await _addFriendsRepository.GetUserWithFriends(addedByUserId);

            if (addedUser == null) return NotFound();

            if (addedByUser.UserName == username) return BadRequest("You cannot request yourself");

            var isUserAlreadyInFriendRequestList = addedUser.FriendRequests.FirstOrDefault(x => x == addedByUserId);
            if (isUserAlreadyInFriendRequestList != Guid.Empty) return BadRequest("You aready sent an friend request to this user");

            var isUserFriend = await _addFriendsRepository.IsUserFriend(addedByUserId, addedUser.Id);
            if (isUserFriend != null) return BadRequest("You are already friend with this user");

            addedUser.FriendRequests.Add(addedByUserId);

            await _context.SaveChangesAsync();

            return Ok(@$"A friend request has been sent to {username}");
        }

        [HttpDelete("/DeleteFriend/{username}")]
        public async Task<ActionResult> RemoveFriend(string username)
        {
            var removedByUserId = new Guid("DFF8FFF1-EF29-4C60-1D51-08DC58ADDFE4"); //User.GetUserId();
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

            await _context.SaveChangesAsync();

            return Ok($"Successfully removed friend request to {username}");
        }

        [HttpDelete("/CancelFriendRequest/{username}")]
        public async Task<ActionResult> CancelFriendRequest(string username)
        {
            var currentUserId = new Guid("DFF8FFF1-EF29-4C60-1D51-08DC58ADDFE4");  //User.GetUserId();
            var userWithFriendRequest = await _userRepository.GetUserByUsernameAsync(username);
            var currentUser = await _addFriendsRepository.GetUserWithFriends(currentUserId);

            if (userWithFriendRequest == null) return NotFound();

            if (currentUser.UserName == username) return BadRequest("You cannot remove yourself");

            var sendRequestToUser = userWithFriendRequest.FriendRequests.FirstOrDefault(x => x == currentUserId);

            if (sendRequestToUser == Guid.Empty) return BadRequest("You are not in this user friend requests");

            userWithFriendRequest.FriendRequests.Remove(sendRequestToUser);

            await _context.SaveChangesAsync();

            return Ok("Successfully cancelled friend request");
        }

        [HttpDelete("/RefuseFriendRequest/{username}")]
        public async Task<ActionResult> RefuseFriendRequest(string username)
        {
            var currentUserId = new Guid("0A5AAA80-3373-49C2-1D57-08DC58ADDFE4"); //User.GetUserId();
            var userInFriendRequestList = await _userRepository.GetUserByUsernameAsync(username);
            var currentUser = await _addFriendsRepository.GetUserWithFriends(currentUserId);

            if (userInFriendRequestList == null) return NotFound();

            if (currentUser.UserName == username) return BadRequest("You cannot remove yourself");

            var friendRequest = currentUser.FriendRequests.FirstOrDefault(x => x == userInFriendRequestList.Id);

            if (friendRequest == Guid.Empty) return BadRequest("This user is not in your friend request list");

            currentUser.FriendRequests.Remove(friendRequest);

            await _context.SaveChangesAsync();

            return Ok();
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<FriendsDto>>> GetUserFriends([FromQuery] AddFriendParams addFriendParams)
        {
            addFriendParams.UserId = new Guid("DFF8FFF1-EF29-4C60-1D51-08DC58ADDFE4"); //User.GetUserId();
            var users =  await _addFriendsRepository.GetUserFriends(addFriendParams);

            Response.AddPaginationHeader(users.CurrentPage, users.PageSize, users.TotalCount, users.TotalPages);

            return Ok(users);
        }

        [HttpGet("CheckFriendship/{username}")]
        public async Task<bool> CheckFriendship([FromRoute] string username)
        {
            var userId = new Guid("DFF8FFF1-EF29-4C60-1D51-08DC58ADDFE4");
            var currentUser = await _addFriendsRepository.GetUserWithFriends(userId);

            var friend = await _userManager.FindByNameAsync(username);

            if(friend == null) return false;

            var isUserFriend = await _context.Friends.FirstOrDefaultAsync(x => (x.UserID1 == userId && x.UserID2 == friend.Id) ||
                                                                                                           (x.UserID1 == friend.Id && x.UserID2 == userId));
            if(isUserFriend != null) return true;

            return false;
        }
    }
}
