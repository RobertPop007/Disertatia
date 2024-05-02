using Disertatie_backend.DatabaseContext;
using Disertatie_backend.DTO;
using Disertatie_backend.Entities.Anime;
using Disertatie_backend.Entities.Books;
using Disertatie_backend.Entities.Games.Game;
using Disertatie_backend.Entities.Manga;
using Disertatie_backend.Entities.Movies;
using Disertatie_backend.Entities.TvShows;
using Disertatie_backend.Entities.User;
using Disertatie_backend.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disertatie_backend.Repositories
{
    public class ReviewRepository<T> : IReviewRepository<T> where T : class
    {
        private readonly DataContext _context;
        private readonly IAnimeRepository _animeRepository;
        private readonly IMangaRepository _mangaRepository;
        private readonly IMoviesRepository _moviesRepository;
        private readonly ITvShowsRepository _tvShowsRepository;
        private readonly IGamesRepository _gamesRepository;
        private readonly IBooksRepository _booksRepository;

        public ReviewRepository(DataContext context,
            IAnimeRepository animeRepository,
            IMangaRepository mangaRepository,
            IMoviesRepository moviesRepository,
            ITvShowsRepository tvShowsRepository,
            IGamesRepository gamesRepository,
            IBooksRepository booksRepository)
        {
            _context = context;
            _animeRepository = animeRepository;
            _mangaRepository = mangaRepository;
            _moviesRepository = moviesRepository;
            _tvShowsRepository = tvShowsRepository;
            _gamesRepository = gamesRepository;
            _booksRepository = booksRepository;
        }

        public async Task AddReviewToItem<T>(Guid userId, ObjectId itemId, ReviewDto reviewDto)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);

            var review = new Review()
            {
                ItemId = itemId.ToString(),
                Main_description = reviewDto.Main_description,
                Short_description = reviewDto.Short_description,
                ReviewDate = DateTime.Now,
                ReviewId = Guid.NewGuid(),
                Stars = reviewDto.Stars,
                User = user,
                UserId = user.Id
            };

            _context.Reviews.Add(review);

            switch (typeof(T))
            {
                case Type t when typeof(Datum).IsAssignableFrom(t):
                    await _animeRepository.AddReviewAsync(itemId, review);
                    break;
                case Type t when typeof(DatumManga).IsAssignableFrom(t):
                    await _mangaRepository.AddReviewAsync(itemId, reviewDto);
                    break;
                case Type t when typeof(Game).IsAssignableFrom(t):
                    await _gamesRepository.AddReviewAsync(itemId, reviewDto);
                    break;
                case Type t when typeof(Movie).IsAssignableFrom(t):
                    await _moviesRepository.AddReviewAsync(itemId, reviewDto);
                    break;
                case Type t when typeof(TvShow).IsAssignableFrom(t):
                    await _tvShowsRepository.AddReviewAsync(itemId, reviewDto);
                    break;
                case Type t when typeof(Book).IsAssignableFrom(t):
                    await _booksRepository.AddReviewAsync(itemId, reviewDto);
                    break;
                default:
                    break;
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteReviewFromItem<T>(Guid userId, ObjectId itemId, Guid reviewId)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            var review = _context.Reviews.FirstOrDefault(r => r.ReviewId ==  reviewId);

            if(review != null)
            {
                var reviewDto = new ReviewDto()
                {
                    Main_description = review.Main_description,
                    Short_description = review.Short_description,
                    Stars = review.Stars,
                    Username = review.User.UserName
                };

                _context.Reviews.Remove(review);

                switch (typeof(T))
                {
                    case Type t when typeof(Datum).IsAssignableFrom(t):
                        await _animeRepository.DeleteReviewAsync(itemId, review.ReviewId);
                        break;
                    case Type t when typeof(DatumManga).IsAssignableFrom(t):
                        await _mangaRepository.DeleteReviewAsync(itemId, reviewDto);
                        break;
                    case Type t when typeof(Game).IsAssignableFrom(t):
                        await _gamesRepository.DeleteReviewAsync(itemId, reviewDto);
                        break;
                    case Type t when typeof(Movie).IsAssignableFrom(t):
                        await _moviesRepository.DeleteReviewAsync(itemId, reviewDto);
                        break;
                    case Type t when typeof(TvShow).IsAssignableFrom(t):
                        await _tvShowsRepository.DeleteReviewAsync(itemId, reviewDto);
                        break;
                    case Type t when typeof(Book).IsAssignableFrom(t):
                        await _booksRepository.DeleteReviewAsync(itemId, reviewDto);
                        break;
                    default:
                        break;
                }

                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Review>> GetReviewsForItem<T>(ObjectId itemId)
        {
            switch (typeof(T))
            {
                case Type t when typeof(Datum).IsAssignableFrom(t):
                    var anime = await _animeRepository.GetAnimeByIdAsync(itemId);
                    var animeReviews = anime.ReviewsIds.Select(x => GetReview(x));
                    return animeReviews;

                case Type t when typeof(DatumManga).IsAssignableFrom(t):
                    var manga = await _mangaRepository.GetMangaByIdAsync(itemId);
                    var mangaReviews = manga.ReviewsIds.Select(x => GetReview(x));
                    return mangaReviews;

                case Type t when typeof(Game).IsAssignableFrom(t):
                    var game = await _gamesRepository.GetGameByIdAsync(itemId);
                    var gameReviews = game.ReviewsIds.Select(x => GetReview(x));
                    return gameReviews;

                case Type t when typeof(Movie).IsAssignableFrom(t):
                    var movie = await _moviesRepository.GetMovieByIdAsync(itemId);
                    var movieReviews = movie.ReviewsIds.Select(x => GetReview(x));
                    return movieReviews;

                case Type t when typeof(TvShow).IsAssignableFrom(t):
                    var tvShow = await _tvShowsRepository.GetTvShowByIdAsync(itemId);
                    var tvShowReviews = tvShow.ReviewsIds.Select(x => GetReview(x));
                    return tvShowReviews;

                case Type t when typeof(Book).IsAssignableFrom(t):
                    var book = await _booksRepository.GetBookByIdAsync(itemId);
                    var booksReviews = book.ReviewsIds.Select(x => GetReview(x));
                    return booksReviews;

                default:
                    break;
            }

            return new List<Review>();
        }

        public async Task<IEnumerable<Review>> GetReviewsForUserAsync(Guid userId)
        {
            var reviewsForUser = _context.Reviews.Where(x => x.UserId == userId).ToList();

            if (reviewsForUser == null) return Enumerable.Empty<Review>();

            return reviewsForUser;
        }

        public Task UpdateReviewItem<T>(Guid userId, ObjectId itemId, Review review)
        {
            throw new System.NotImplementedException();
        }

        private Review GetReview(Guid reviewId)
        {
            return _context.Reviews.FirstOrDefault(x => x.ReviewId == reviewId);
        }
    }
}
