using Disertatie_backend.Entities.Anime;
using Disertatie_backend.Entities.Games.Game;
using Disertatie_backend.Entities.Manga;
using Disertatie_backend.Entities.Movies;
using Disertatie_backend.Entities.TvShows;
using Disertatie_backend.Interfaces;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Disertatie_backend.DatabaseContext;
using Disertatie_backend.Entities.User;
using System.Linq;
using Disertatie_backend.Entities.Books;

namespace Disertatie_backend.Repositories
{
    public class UserItemsRepository<T> : IUserItemsRepository<T> where T : class
    {
        private readonly DataContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IAnimeRepository _animeRepository;
        private readonly IMangaRepository _mangaRepository;
        private readonly IMoviesRepository _moviesRepository;
        private readonly ITvShowsRepository _tvShowsRepository;
        private readonly IGamesRepository _gamesRepository;
        private readonly IBooksRepository _booksRepository;

        public UserItemsRepository(DataContext context,
            IUserRepository userRepository,
            IAnimeRepository animeRepository,
            IMangaRepository mangaRepository,
            IMoviesRepository moviesRepository,
            ITvShowsRepository tvShowsRepository,
            IGamesRepository gamesRepository,
            IBooksRepository booksRepository)
        {
            _context = context;
            _userRepository = userRepository;
            _animeRepository = animeRepository;
            _mangaRepository = mangaRepository;
            _moviesRepository = moviesRepository;
            _tvShowsRepository = tvShowsRepository;
            _gamesRepository = gamesRepository;
            _booksRepository = booksRepository;
        }

        public async Task AddItemToUser<T>(AppUser user, ObjectId itemId)
        {
            switch (typeof(T))
            {
                case Type t when typeof(Datum).IsAssignableFrom(t):
                    var animeItem = new AppUserAnimeItem()
                    {
                        AnimeId = itemId.ToString(),
                        AppUserId = user.Id
                    };

                    _context.UserAnimes.Add(animeItem);
                    user.AppUserAnime.Add(animeItem);
                    break;
                case Type t when typeof(DatumManga).IsAssignableFrom(t):
                    var mangaItem = new AppUserMangaItem()
                    {
                        MangaId = itemId.ToString(),
                        AppUser = user,
                        AppUserId = user.Id
                    };

                    _context.UserMangas.Add(mangaItem);
                    user.AppUserManga.Add(mangaItem);
                    break;
                case Type t when typeof(Game).IsAssignableFrom(t):
                    var gameItem = new AppUserGameItem()
                    {
                        GameId = itemId.ToString(),
                        AppUser = user,
                        AppUserId = user.Id
                    };

                    _context.UserGames.Add(gameItem);
                    user.AppUserGame.Add(gameItem);
                    break;
                case Type t when typeof(Movie).IsAssignableFrom(t):
                    var movieItem = new AppUserMovieItem()
                    {
                        MovieId = itemId.ToString(),
                        AppUser = user,
                        AppUserId = user.Id
                    };

                    _context.UserMovies.Add(movieItem);
                    user.AppUserMovie.Add(movieItem);
                    break;
                case Type t when typeof(TvShow).IsAssignableFrom(t):
                    var tvShowItem = new AppUserTvShowItem()
                    {
                        TvShowId = itemId.ToString(),
                        AppUser = user,
                        AppUserId = user.Id
                    };

                    _context.UserTvShows.Add(tvShowItem);
                    user.AppUserTvShow.Add(tvShowItem);
                    break;
                case Type t when typeof(Book).IsAssignableFrom(t):
                    var bookItem = new AppUserBookItem()
                    {
                        BookId = itemId.ToString(),
                        AppUser = user,
                        AppUserId = user.Id
                    };

                    _context.UserBooks.Add(bookItem);
                    user.AppUserBook.Add(bookItem);
                    break;
                default:
                    break;
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteItemFromUser<T>(AppUser user, ObjectId itemId)
        {
            switch (typeof(T))
            {
                case Type t when typeof(Datum).IsAssignableFrom(t):
                    var animeItem = _context.UserAnimes.FirstOrDefault(u => u.AnimeId == itemId.ToString() && u.AppUserId == user.Id);
                    _context.UserAnimes.Remove(animeItem);
                    user.AppUserAnime.Remove(animeItem);
                    break;
                case Type t when typeof(DatumManga).IsAssignableFrom(t):
                    var mangaItem = _context.UserMangas.FirstOrDefault(u => u.MangaId == itemId.ToString() && u.AppUserId == user.Id);
                    _context.UserMangas.Remove(mangaItem);
                    user.AppUserManga.Remove(mangaItem);
                    break;
                case Type t when typeof(Game).IsAssignableFrom(t):
                    var gameItem = _context.UserGames.FirstOrDefault(u => u.GameId == itemId.ToString() && u.AppUserId == user.Id);
                    _context.UserGames.Remove(gameItem);
                    user.AppUserGame.Remove(gameItem);
                    break;
                case Type t when typeof(Movie).IsAssignableFrom(t):
                    var movieItem = _context.UserMovies.FirstOrDefault(u => u.MovieId == itemId.ToString() && u.AppUserId == user.Id);
                    _context.UserMovies.Remove(movieItem);
                    user.AppUserMovie.Remove(movieItem);
                    break;
                case Type t when typeof(TvShow).IsAssignableFrom(t):
                    var tvShowItem = _context.UserTvShows.FirstOrDefault(u => u.TvShowId == itemId.ToString() && u.AppUserId == user.Id);
                    _context.UserTvShows.Remove(tvShowItem);
                    user.AppUserTvShow.Remove(tvShowItem);
                    break;
                case Type t when typeof(Book).IsAssignableFrom(t):
                    var bookItem = _context.UserBooks.FirstOrDefault(u => u.BookId == itemId.ToString() && u.AppUserId == user.Id);
                    _context.UserBooks.Remove(bookItem);
                    user.AppUserBook.Remove(bookItem);
                    break;
                default:
                    break;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetItemsForUser<T>(Guid userId)
        {
            var listOfItemsForUser = new List<T>();

            switch (typeof(T))
            {
                case Type t when typeof(Datum).IsAssignableFrom(t):
                    var userAnime = await _context.Users.Include(u => u.AppUserAnime).SingleOrDefaultAsync(u => u.Id == userId);
                    foreach (var animeId in userAnime.AppUserAnime.Select(a => a.AnimeId))
                    {
                        var anime = await _animeRepository.GetAnimeByIdAsync(new ObjectId(animeId));

                        if (anime != null) listOfItemsForUser.Add((T)Convert.ChangeType(anime, typeof(T)));
                    }
                    break;

                case Type t when typeof(DatumManga).IsAssignableFrom(t):
                    var userManga = await _context.Users.Include(u => u.AppUserManga).SingleOrDefaultAsync(u => u.Id == userId);
                    foreach (var mangaId in userManga.AppUserManga.Select(m => m.MangaId))
                    {
                        var manga = await _mangaRepository.GetMangaByIdAsync(new ObjectId(mangaId));

                        if (manga != null) listOfItemsForUser.Add((T)Convert.ChangeType(manga, typeof(T)));
                    }
                    break;

                case Type t when typeof(Game).IsAssignableFrom(t):
                    var userGame = await _context.Users.Include(u => u.AppUserGame).SingleOrDefaultAsync(u => u.Id == userId);
                    foreach (var gameId in userGame.AppUserGame.Select(g => g.GameId))
                    {
                        var game = await _gamesRepository.GetGameByIdAsync(new ObjectId(gameId));

                        if (game != null) listOfItemsForUser.Add((T)Convert.ChangeType(game, typeof(T)));
                    }
                    break;

                case Type t when typeof(Movie).IsAssignableFrom(t):
                    var userMovie = await _context.Users.Include(u => u.AppUserMovie).SingleOrDefaultAsync(u => u.Id == userId);
                    foreach (var movieId in userMovie.AppUserMovie.Select(m => m.MovieId))
                    {
                        var movie = await _moviesRepository.GetMovieByIdAsync(new ObjectId(movieId));

                        if (movie != null) listOfItemsForUser.Add((T)Convert.ChangeType(movie, typeof(T)));
                    }
                    break;

                case Type t when typeof(TvShow).IsAssignableFrom(t):
                    var userTvShow = await _context.Users.Include(u => u.AppUserTvShow).SingleOrDefaultAsync(u => u.Id == userId);
                    foreach (var tvShowId in userTvShow.AppUserTvShow.Select(t => t.TvShowId))
                    {
                        var tvShow = await _tvShowsRepository.GetTvShowByIdAsync(new ObjectId(tvShowId));

                        if (tvShow != null) listOfItemsForUser.Add((T)Convert.ChangeType(tvShow, typeof(T)));
                    }
                    break;

                case Type t when typeof(Book).IsAssignableFrom(t):
                    var userBook = await _context.Users.Include(u => u.AppUserBook).SingleOrDefaultAsync(u => u.Id == userId);
                    foreach (var bookId in userBook.AppUserBook.Select(t => t.BookId))
                    {
                        var book = await _tvShowsRepository.GetTvShowByIdAsync(new ObjectId(bookId));

                        if (book != null) listOfItemsForUser.Add((T)Convert.ChangeType(book, typeof(T)));
                    }
                    break;

                default:
                    break;
            }

            return listOfItemsForUser;
        }

        public async Task<bool> IsItemAlreadyAdded(Guid userId, ObjectId itemId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            var isItemAlreadyAdded = false;

            switch (typeof(T))
            {
                case Type t when typeof(Datum).IsAssignableFrom(t):
                    isItemAlreadyAdded = _context.UserAnimes.Any(u => u.AnimeId == itemId.ToString() && u.AppUserId == userId);
                    break;
                case Type t when typeof(DatumManga).IsAssignableFrom(t):
                    isItemAlreadyAdded = _context.UserMangas.Any(u => u.MangaId == itemId.ToString() && u.AppUserId == userId);
                    break;
                case Type t when typeof(Game).IsAssignableFrom(t):
                    isItemAlreadyAdded = _context.UserGames.Any(u => u.GameId == itemId.ToString() && u.AppUserId == userId);
                    break;
                case Type t when typeof(Movie).IsAssignableFrom(t):
                    isItemAlreadyAdded = _context.UserMovies.Any(u => u.MovieId == itemId.ToString() && u.AppUserId == userId);
                    break;
                case Type t when typeof(TvShow).IsAssignableFrom(t):
                    isItemAlreadyAdded = _context.UserTvShows.Any(u => u.TvShowId == itemId.ToString() && u.AppUserId == userId);
                    break;
                case Type t when typeof(Book).IsAssignableFrom(t):
                    isItemAlreadyAdded = _context.UserBooks.Any(u => u.BookId == itemId.ToString() && u.AppUserId == userId);
                    break;
                default:
                    break;
            }

            return isItemAlreadyAdded;
        }
    }
}
