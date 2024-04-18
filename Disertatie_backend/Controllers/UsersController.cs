using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Disertatie_backend.DTO;
using Disertatie_backend.Entities;
using Disertatie_backend.Extensions;
using Disertatie_backend.Helpers;
using Disertatie_backend.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Disertatie_backend.Entities.User;

namespace Disertatie_backend.Controllers
{
    //[Authorize]
    public class UsersController : BaseApiController //BaseApiController e un controller parinte, are el proprietatile necesare
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;
        private readonly IReviewRepository<AppUser> _reviewRepository;

        public UsersController(IUserRepository userRepository, 
            IMapper mapper, 
            IPhotoService photoService,
            IReviewRepository<AppUser> reviewRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _photoService = photoService;
            _reviewRepository = reviewRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers([FromQuery] UserParams userParams)
        {
            userParams.CurrentUsername = User.GetUsername();

            var users = await _userRepository.GetMembersAsync(userParams);

            Response.AddPaginationHeader(users.CurrentPage, users.PageSize, users.TotalCount, users.TotalPages);

            return Ok(users);
        }

        //api/users/3
        [HttpGet("{username}", Name = "GetUser")]
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            return await _userRepository.GetMemberAsync(username);
        }

        [HttpGet("GetReviewsForCurrentUser")]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviewsForUser()
        {
            var userId = new System.Guid("1C7E8AC6-3371-4C90-2A43-08DC5AE01C57"); //User.GetUserId();

            return Ok(await _reviewRepository.GetReviewsForUserAsync(userId));
        }

        [HttpPost("add-photo")]
        public async Task<ActionResult<PhotoDto>> AddPhoto(IFormFile file)
        {
            var user = await _userRepository.GetUserByUsernameAsync(User.GetUsername());

            var result = await _photoService.AddPhotoAsync(file);

            if (result.Error != null) return BadRequest(result.Error.Message);

            var photo = new Photo
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };

            user.ProfilePicture = photo;

            if (await _userRepository.SaveAllAsync())
            {
                return CreatedAtRoute("GetUser", new { username = user.UserName }, _mapper.Map<PhotoDto>(photo));
            }


            return BadRequest("Problem adding photo");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(MemberUpdateDto memberUpdateDto)
        {
            var user = await _userRepository.GetUserByUsernameAsync(User.GetUsername());

            _mapper.Map(memberUpdateDto, user);

            _userRepository.Update(user);

            if (await _userRepository.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to update user");
        }

        [HttpDelete("delete-photo")]
        public async Task<ActionResult> DeletePhoto()
        {
            var user = await _userRepository.GetUserByUsernameAsync(User.GetUsername());

            var photo = user.ProfilePicture;

            if (photo == null) return NotFound();

            if (photo.PublicId != null)
            {
                var result = await _photoService.DeletePhotoAsync(photo.PublicId);

                if (result.Error != null) return BadRequest(result.Error.Message);
            }

            user.ProfilePicture = null;

            if (await _userRepository.SaveAllAsync()) return Ok();

            return BadRequest("Failed to delete this photo");
        }
    }
}
