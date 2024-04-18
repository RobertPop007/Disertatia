using Microsoft.AspNetCore.Mvc;
using Disertatie_backend.Entities.TvShows;
using Disertatie_backend.Extensions;
using Disertatie_backend.Helpers;
using Disertatie_backend.Interfaces;
using System.Threading.Tasks;
using MongoDB.Bson;
using Disertatie_backend.Entities.Games.Game;
using Disertatie_backend.Entities.Anime;
using Disertatie_backend.DTO;
using Disertatie_backend.Entities.Movies;
using Disertatie_backend.Repositories;
using System;
using System.Collections.Generic;

namespace Disertatie_backend.Controllers
{
    public class TvShowsController : BaseApiController
    {
        private readonly ITvShowsRepository _tvShowsRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserItemsRepository<TvShow> _userItemsRepository;
        private readonly IReviewRepository<Datum> _reviewRepository;

        public TvShowsController(ITvShowsRepository tvShowsRepository, 
            IUserRepository userRepository,
            IUserItemsRepository<TvShow> userItemsRepository,
            IReviewRepository<Datum> reviewRepository)
        {
            _tvShowsRepository = tvShowsRepository;
            _userRepository = userRepository;
            _userItemsRepository = userItemsRepository;
            _reviewRepository = reviewRepository;
        }

        [HttpPost("AddTvShowToUser/{tvShowId}")]
        public async Task<IActionResult> AddMovieForUser(ObjectId tvShowId)
        {
            var username = User.GetUsername();

            if (username == null) return BadRequest("User does not exist");

            var user = await _userRepository.GetUserByUsernameAsync(username);

            var tvShow = await _tvShowsRepository.GetTvShowByIdAsync(tvShowId);
            if (tvShow == null) return NotFound("TvShow not found");

            if (await _userItemsRepository.IsItemAlreadyAdded(user.Id, tvShowId)) return BadRequest("You have already added this tv show to your list");

            await _userItemsRepository.AddItemToUser<TvShow>(user, tvShowId);

            return Ok(user);
        }

        [HttpGet("GetTvShowsFor/{username}")]
        public async Task<IActionResult> GetTvShowsForUser([FromRoute] string username)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);

            var listOfTvShows = await _userItemsRepository.GetItemsForUser<TvShow>(user.Id);
            return Ok(listOfTvShows);
        }

        [HttpGet("GetAllTvShows")]
        public async Task<IActionResult> GetMovies([FromQuery] TvShowParams tvShowParams)
        {
            var tvShows = await _tvShowsRepository.GetTvShowsAsync(tvShowParams);
            return Ok(tvShows);
        }

        [HttpGet("{title}", Name = "GetTvShow")]
        public async Task<ActionResult<TvShow>> GetTvShow(string title)
        {
            return await _tvShowsRepository.GetTvShowByFullTitleAsync(title);
        }

        [HttpGet("TvShowAlreadyAdded")]
        public async Task<bool> IsTvShowAlreadyAdded(ObjectId tvShowId)
        {
            var userId = User.GetUserId();

            return await _userItemsRepository.IsItemAlreadyAdded(userId, tvShowId);
        }

        [HttpDelete("DeleteTvShowFromUser/{tvShowId}")]
        public async Task<IActionResult> DeleteTvShowForUser(ObjectId tvShowId)
        {
            var userId = User.GetUserId();
            var user = await _userRepository.GetUserByIdAsync(userId);

            var tvShow = await _tvShowsRepository.GetTvShowByIdAsync(tvShowId);
            if (tvShow == null)
            {
                return NotFound();
            }

            await _userItemsRepository.DeleteItemFromUser<TvShow>(user, tvShowId);

            return Ok();
        }

        [HttpPost("AddReviewFor/{tvShowId}")]
        public async Task<IActionResult> AddReviewForTvShow(ObjectId tvShowId, ReviewDto reviewDto)
        {
            var userId = User.GetUserId();
            var user = await _userRepository.GetUserByIdAsync(userId);

            await _reviewRepository.AddReviewToItem<TvShow>(user, tvShowId, reviewDto);

            return Ok(reviewDto);
        }

        [HttpDelete("DeleteReviewFor/{tvShowId}")]
        public async Task<IActionResult> DeleteReviewForTvShow(ObjectId tvShowId, Guid reviewId)
        {
            var userId = User.GetUserId();
            var user = await _userRepository.GetUserByIdAsync(userId);

            await _reviewRepository.DeleteReviewFromItem<TvShow>(user, tvShowId, reviewId);

            return Ok();
        }

        [HttpGet("GetReviewsFor/{tvShowId}")]
        public async Task<ActionResult<IEnumerable<ReviewDto>>> GetAllReviewForTvShow(ObjectId tvShowId)
        {
            return Ok(await _reviewRepository.GetReviewsForItem<TvShow>(tvShowId));
        }
    }
}
