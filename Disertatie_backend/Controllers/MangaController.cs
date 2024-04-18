﻿using Microsoft.AspNetCore.Mvc;
using Disertatie_backend.Entities.Manga;
using Disertatie_backend.Extensions;
using Disertatie_backend.Helpers;
using Disertatie_backend.Interfaces;
using System.Threading.Tasks;
using MongoDB.Bson;
using Disertatie_backend.Entities.Anime;
using Disertatie_backend.Entities.Games.Game;
using Disertatie_backend.DTO;
using Disertatie_backend.Repositories;
using System;
using System.Collections.Generic;

namespace Disertatie_backend.Controllers
{
    public class MangaController : BaseApiController
    {
        private readonly IMangaRepository _mangasRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserItemsRepository<DatumManga> _userItemsRepository;
        private readonly IReviewRepository<Datum> _reviewRepository;

        public MangaController(IMangaRepository mangasRepository, 
            IUserRepository userRepository,
            IUserItemsRepository<DatumManga> userItemsRepository,
            IReviewRepository<Datum> reviewRepository)
        {
            _mangasRepository = mangasRepository;
            _userRepository = userRepository;
            _userItemsRepository = userItemsRepository;
            _reviewRepository = reviewRepository;
        }

        [HttpPost("AddMangaToUser/{mangaId}")]
        public async Task<IActionResult> AddMangaForUser(ObjectId mangaId)
        {
            var username = User.GetUsername();

            if (username == null) return BadRequest("User does not exist");

            var user = await _userRepository.GetUserByUsernameAsync(username);

            var manga = await _mangasRepository.GetMangaByIdAsync(mangaId);
            if (manga == null) return NotFound("Manga not found");

            if (await _userItemsRepository.IsItemAlreadyAdded(user.Id, mangaId)) return BadRequest("You have already added this anime to your list");

            await _userItemsRepository.AddItemToUser<DatumManga>(user, mangaId);

            return Ok(user);
        }

        [HttpGet("GetMangasFor/{username}")]
        public async Task<IActionResult> GetMangasForUser([FromRoute] string username)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);

            var listOfMangas = await _userItemsRepository.GetItemsForUser<DatumManga>(user.Id);
            return Ok(listOfMangas);
        }

        [HttpGet("GetAllMangas")]
        public async Task<IActionResult> GetMangas([FromQuery] MangaParams mangaParams)
        {
            var mangas = await _mangasRepository.GetMangasAsync(mangaParams);

            return Ok(mangas);
        }

        [HttpGet("{title}", Name = "GetManga")]
        public async Task<ActionResult<DatumManga>> GetManga(string title)
        {
            return await _mangasRepository.GetMangaByFullTitleAsync(title);
        }

        [HttpGet("MangaAlreadyAdded")]
        public async Task<bool> IsMangaAlreadyAdded(ObjectId mangaId)
        {
            var userId = User.GetUserId();

            return await _userItemsRepository.IsItemAlreadyAdded(userId, mangaId);
        }

        [HttpDelete("DeleteMangaFrom/{mangaId}")]
        public async Task<IActionResult> DeleteMangaForUser(ObjectId mangaId)
        {
            var userId = User.GetUserId();
            var user = await _userRepository.GetUserByIdAsync(userId);

            var manga = await _mangasRepository.GetMangaByIdAsync(mangaId);
            if (manga == null)
            {
                return NotFound();
            }

            await _userItemsRepository.DeleteItemFromUser<Datum>(user, mangaId);

            return Ok();
        }

        [HttpPost("AddReviewFor/{mangaId}")]
        public async Task<IActionResult> AddReviewForManga(ObjectId mangaId, ReviewDto reviewDto)
        {
            var userId = User.GetUserId();
            var user = await _userRepository.GetUserByIdAsync(userId);

            await _reviewRepository.AddReviewToItem<DatumManga>(user, mangaId, reviewDto);

            return Ok(reviewDto);
        }

        [HttpDelete("DeleteReviewFor/{mangaId}")]
        public async Task<IActionResult> DeleteReviewForManga(ObjectId mangaId, Guid reviewId)
        {
            var userId = User.GetUserId();
            var user = await _userRepository.GetUserByIdAsync(userId);

            await _reviewRepository.DeleteReviewFromItem<DatumManga>(user, mangaId, reviewId);

            return Ok();
        }

        [HttpGet("GetReviewsFor/{mangaId}")]
        public async Task<ActionResult<IEnumerable<ReviewDto>>> GetAllReviewForManga(ObjectId mangaId)
        {
            return Ok(await _reviewRepository.GetReviewsForItem<DatumManga>(mangaId));
        }
    }
}