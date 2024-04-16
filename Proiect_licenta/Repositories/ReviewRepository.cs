using Disertatie_backend.DatabaseContext;
using Disertatie_backend.DTO;
using Disertatie_backend.Entities.Anime;
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

        public ReviewRepository(DataContext context,
            IAnimeRepository animeRepository,
            IMangaRepository mangaRepository,
            IMoviesRepository moviesRepository,
            ITvShowsRepository tvShowsRepository,
            IGamesRepository gamesRepository)
        {
            _context = context;
            _animeRepository = animeRepository;
            _mangaRepository = mangaRepository;
            _moviesRepository = moviesRepository;
            _tvShowsRepository = tvShowsRepository;
            _gamesRepository = gamesRepository;
        }

        public async Task AddReviewToItem<T>(AppUser user, ObjectId itemId, ReviewDto reviewDto)
        {
            var review = new Review()
            {
                ItemId = itemId.ToString(),
                Main_description = reviewDto.Main_description,
                Short_description = reviewDto.Short_description,
                ReviewDate = DateTime.Now,
                ReviewId = new Guid(),
                Stars = reviewDto.Stars,
                User = user,
                UserId = user.Id
            };

            user.Reviews.Add(review);

            switch (typeof(T))
            {
                case Type t when typeof(Datum).IsAssignableFrom(t):
                    await _animeRepository.AddReviewAsync(itemId, reviewDto);
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
                default:
                    break;
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteReviewFromItem<T>(AppUser user, ObjectId itemId, Guid reviewId)
        {
            var review = _context.Reviews.FirstOrDefault(r => r.ReviewId ==  reviewId);
            var reviewDto = new ReviewDto()
            {
                Main_description = review.Main_description,
                Short_description = review.Short_description,
                Stars = review.Stars,
                Username = review.User.UserName
            };

            user.Reviews.Remove(review);

            switch (typeof(T))
            {
                case Type t when typeof(Datum).IsAssignableFrom(t):
                    await _animeRepository.DeleteReviewAsync(itemId, reviewDto);
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
                default:
                    break;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ReviewDto>> GetReviewsForItem<T>(ObjectId itemId)
        {
            switch (typeof(T))
            {
                case Type t when typeof(Datum).IsAssignableFrom(t):
                    var anime = await _animeRepository.GetAnimeByIdAsync(itemId);
                    return anime.Reviews;

                case Type t when typeof(DatumManga).IsAssignableFrom(t):
                    var manga = await _mangaRepository.GetMangaByIdAsync(itemId);
                    return manga.Reviews;

                case Type t when typeof(Game).IsAssignableFrom(t):
                    var game = await _gamesRepository.GetGameByIdAsync(itemId);
                    return game.Reviews;

                case Type t when typeof(Movie).IsAssignableFrom(t):
                    var movie = await _moviesRepository.GetMovieByIdAsync(itemId);
                    return movie.Reviews;

                case Type t when typeof(TvShow).IsAssignableFrom(t):
                    var tvShow = await _tvShowsRepository.GetTvShowByIdAsync(itemId);
                    return tvShow.Reviews;

                default:
                    break;
            }

            return new List<ReviewDto>();
        }

        public Task UpdateReviewItem<T>(AppUser user, ObjectId itemId, Review review)
        {
            throw new System.NotImplementedException();
        }
    }
}
