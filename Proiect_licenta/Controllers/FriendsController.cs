using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proiect_licenta.DTO;
using Proiect_licenta.Entities;
using Proiect_licenta.Extensions;
using Proiect_licenta.Helpers;
using Proiect_licenta.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proiect_licenta.Controllers
{
    [Authorize]
    public class FriendsController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IAddFriendsRepository _addFriendsRepository;

        public FriendsController(IUserRepository userRepository, IAddFriendsRepository addFriendsRepository)
        {
            this._userRepository = userRepository;
            this._addFriendsRepository = addFriendsRepository;
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

            addedByUser.AddedUsers.Add(userFriend);

            if (await _userRepository.SaveAllAsync()) return Ok();

            return BadRequest("Failed to like user");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FriendsDto>>> GetUserFriends([FromQuery] AddFriendParams addFriendParams)
        {
            addFriendParams.UserId = User.GetUserId();
            var users =  await _addFriendsRepository.GetUserFriends(addFriendParams);

            Response.AddPaginationHeader(users.CurrentPage, users.PageSize, users.TotalCount, users.TotalPages);

            return Ok(users);
        }
    }
}
