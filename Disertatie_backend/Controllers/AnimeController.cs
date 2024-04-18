﻿using Microsoft.AspNetCore.Mvc;
using Disertatie_backend.Entities.Anime;
using Disertatie_backend.Extensions;
using Disertatie_backend.Helpers;
using Disertatie_backend.Interfaces;
using System.Threading.Tasks;
using MongoDB.Bson;
using Disertatie_backend.Entities.User;
using Disertatie_backend.DTO;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Disertatie_backend.Controllers
{
    public class AnimeController : BaseApiController
    {
        private readonly IAnimeRepository _animesRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserItemsRepository<Datum> _userItemsRepository;
        private readonly IReviewRepository<Datum> _reviewRepository;

        public AnimeController(IAnimeRepository animesRepository, 
            IUserRepository userRepository,
            IUserItemsRepository<Datum> userItemsRepository,
            IReviewRepository<Datum> reviewRepository)
        {
            _animesRepository = animesRepository;
            _userRepository = userRepository;
            _userItemsRepository = userItemsRepository;
            _reviewRepository = reviewRepository;
        }

        [HttpPost("AddAnimeToUser/{animeId}")]
        public async Task<IActionResult> AddAnimeForUser(ObjectId animeId)
        {
            var username = "rae";

            if (username == null) return BadRequest("User does not exist");

            var user = await _userRepository.GetUserByUsernameAsync(username);

            var anime = await _animesRepository.GetAnimeByIdAsync(animeId);
            if (anime == null) return NotFound("Anime not found");

            if (await _userItemsRepository.IsItemAlreadyAdded(user.Id, animeId)) return BadRequest("You have already added this anime to your list");

            await _userItemsRepository.AddItemToUser<Datum>(user, animeId);

            return Ok(user);
        }

        [HttpGet("GetAnimesFor/{username}")]
        public async Task<IActionResult> GetAnimesForUser([FromRoute] string username)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);

            var listOfAnimes = await _userItemsRepository.GetItemsForUser<Datum>(user.Id);
            return Ok(listOfAnimes);
        }

        [HttpGet("GetAllAnimes")]
        public async Task<IActionResult> GetAnimes([FromQuery] AnimeParams animeParams)
        {
            var animes = await _animesRepository.GetAnimesAsync(animeParams);
            return Ok(animes);
        }

        [HttpGet("{title}", Name = "GetAnime")]
        public async Task<ActionResult<Datum>> GetAnime(string title)
        {
            return await _animesRepository.GetAnimeByFullTitleAsync(title);
        }

        [HttpGet("AnimeAlreadyAdded")]
        public async Task<bool> IsAnimeAlreadyAdded(ObjectId animeId)
        {
            var userId = new System.Guid("1C7E8AC6-3371-4C90-2A43-08DC5AE01C57");// User.GetUserId();

            return await _userItemsRepository.IsItemAlreadyAdded(userId, animeId);
        }

        [HttpDelete("DeleteAnimeFromUser/{animeId}")]
        public async Task<IActionResult> DeleteAnimeForUser(ObjectId animeId)
        {
            var userId = new System.Guid("1C7E8AC6-3371-4C90-2A43-08DC5AE01C57"); //User.GetUserId();
            var user = await _userRepository.GetUserByIdAsync(userId);

            var anime = await _animesRepository.GetAnimeByIdAsync(animeId);
            if (anime == null)
            {
                return NotFound();
            }

            await _userItemsRepository.DeleteItemFromUser<Datum>(user, animeId);

            return Ok();
        }

        [HttpPost("AddReviewFor/{animeId}")]
        public async Task<IActionResult> AddReviewForAnime(ObjectId animeId, ReviewDto reviewDto)
        {
            var userId = new System.Guid("1C7E8AC6-3371-4C90-2A43-08DC5AE01C57"); //User.GetUserId();
            var user = await _userRepository.GetUserByIdAsync(userId);

            await _reviewRepository.AddReviewToItem<Datum>(user, animeId, reviewDto);

            return Ok(reviewDto);
        }

        [HttpDelete("DeleteReviewFor/{animeId}")]
        public async Task<IActionResult> DeleteReviewForAnime(ObjectId animeId, Guid reviewId)
        {
            var userId = new System.Guid("1C7E8AC6-3371-4C90-2A43-08DC5AE01C57"); //User.GetUserId();
            var user = await _userRepository.GetUserByIdAsync(userId);

            await _reviewRepository.DeleteReviewFromItem<Datum>(user, animeId, reviewId);

            return Ok();
        }

        [HttpGet("GetReviewsFor/{animeId}")]
        public async Task<ActionResult<IEnumerable<ReviewDto>>> GetAllReviewForAnime(ObjectId animeId)
        {
            return Ok(await _reviewRepository.GetReviewsForItem<Datum>(animeId));
        }
    }
}