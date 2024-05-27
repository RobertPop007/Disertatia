using Disertatie_backend.DTO;
using Disertatie_backend.Entities.Books;
using Disertatie_backend.Entities.Games.Game;
using Disertatie_backend.Extensions;
using Disertatie_backend.Helpers;
using Disertatie_backend.Interfaces;
using Disertatie_backend.Repositories;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Disertatie_backend.Controllers
{
    public class BooksController : BaseApiController
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserItemsRepository<Book> _userItemsRepository;
        private readonly IReviewRepository<Book> _reviewRepository;

        public BooksController(IBooksRepository booksRepository,
            IUserRepository userRepository,
            IUserItemsRepository<Book> userItemsRepository,
            IReviewRepository<Book> reviewRepository)
        {
            _booksRepository = booksRepository;
            _userRepository = userRepository;
            _userItemsRepository = userItemsRepository;
            _reviewRepository = reviewRepository;
        }

        [HttpGet("GetBooksFor/{username}")]
        public async Task<IActionResult> GetBooksForUser([FromRoute] string username)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);

            var listOfBooks = await _userItemsRepository.GetItemsForUser<Book>(user.Id);
            return Ok(listOfBooks);
        }

        [HttpGet("GetAllBooks")]
        public async Task<IActionResult> GetBooks([FromQuery] BookParams bookParams)
        {
            var books = await _booksRepository.GetBooksAsync(bookParams);

            Response.AddPaginationHeader(books.CurrentPage, books.PageSize, books.TotalCount, books.TotalPages);

            return Ok(books);
        }

        [HttpGet("{title}", Name = "GetBook")]
        public async Task<ActionResult<Book>> GetBook(string title)
        {
            return await _booksRepository.GetBookByTitleAsync(title);
        }

        [HttpGet("BookAlreadyAdded")]
        public async Task<bool> IsBookAlreadyAdded(ObjectId bookId)
        {
            var userId = User.GetUserId();

            return await _userItemsRepository.IsItemAlreadyAdded(userId, bookId);
        }


        [HttpGet("GetReviewsFor/{bookId}")]
        public async Task<ActionResult<IEnumerable<ReviewDto>>> GetAllReviewForBook(ObjectId bookId)
        {
            return Ok(await _reviewRepository.GetReviewsForItem<Book>(bookId));
        }

        [HttpPost("AddReviewFor/{bookId}")]
        public async Task<IActionResult> AddReviewForBook(ObjectId bookId, ReviewDto reviewDto)
        {
            var userId = User.GetUserId();

            await _reviewRepository.AddReviewToItem<Book>(userId, bookId, reviewDto);

            return Ok(reviewDto);
        }

        [HttpPost("AddBookToUser/{bookId}")]
        public async Task<IActionResult> AddBookForUser(ObjectId bookId)
        {
            var username = User.GetUsername();

            if (username == null) return BadRequest("User does not exist");

            var user = await _userRepository.GetUserByUsernameAsync(username);

            var game = await _booksRepository.GetBookByIdAsync(bookId);
            if (game == null) return NotFound("Book not found");

            if (await _userItemsRepository.IsItemAlreadyAdded(user.Id, bookId)) return BadRequest("You have already added this book to your list");

            await _userItemsRepository.AddItemToUser<Book>(user, bookId);

            return Ok(user);
        }

        [HttpDelete("DeleteBookFromUser/{bookId}")]
        public async Task<IActionResult> DeleteBookForUser(ObjectId bookId)
        {
            var userId = User.GetUserId();
            var user = await _userRepository.GetUserByIdAsync(userId);

            var book = await _booksRepository.GetBookByIdAsync(bookId);
            if (book == null)
            {
                return NotFound();
            }

            await _userItemsRepository.DeleteItemFromUser<Book>(user, bookId);

            return Ok();
        }

        [HttpDelete("DeleteReviewFor/{bookId}")]
        public async Task<IActionResult> DeleteReviewForBook(ObjectId bookId, Guid reviewId)
        {
            var userId = User.GetUserId();

            await _reviewRepository.DeleteReviewFromItem<Book>(userId, bookId, reviewId);

            return Ok();
        }

        [HttpPost("LikeReviewFor/{reviewId}")]
        public async Task<IActionResult> LikeReview(ObjectId bookId, Guid reviewId)
        {
            await _reviewRepository.LikeReview(bookId, reviewId);

            return Ok();
        }

        [HttpPost("DislikeReviewFor/{reviewId}")]
        public async Task<IActionResult> DislikeReview(ObjectId bookId, Guid reviewId)
        {
            await _reviewRepository.DislikeReview(bookId, reviewId);

            return Ok();
        }
    }
}
