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
using AutoMapper;
using System.Collections.Generic;
using Disertatie_backend.DatabaseContext;
using Disertatie_backend.Entities.User;

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

        public UserItemsRepository(DataContext context,
            IUserRepository userRepository,
            IAnimeRepository animeRepository,
            IMangaRepository mangaRepository,
            IMoviesRepository moviesRepository,
            ITvShowsRepository tvShowsRepository,
            IGamesRepository gamesRepository)
        {
            _context = context;
            _userRepository = userRepository;
            _animeRepository = animeRepository;
            _mangaRepository = mangaRepository;
            _moviesRepository = moviesRepository;
            _tvShowsRepository = tvShowsRepository;
            _gamesRepository = gamesRepository;
        }

        public async Task AddItemToUser<T>(AppUser user, ObjectId itemId)
        {
            switch (typeof(T))
            {
                case Type t when typeof(Datum).IsAssignableFrom(t):
                    user.AppUserAnime.Add(itemId.ToString());
                    break;
                case Type t when typeof(DatumManga).IsAssignableFrom(t):
                    user.AppUserManga.Add(itemId.ToString());
                    break;
                case Type t when typeof(Game).IsAssignableFrom(t):
                    user.AppUserGame.Add(itemId.ToString());
                    break;
                case Type t when typeof(Movie).IsAssignableFrom(t):
                    user.AppUserMovie.Add(itemId.ToString());
                    break;
                case Type t when typeof(TvShow).IsAssignableFrom(t):
                    user.AppUserTvShow.Add(itemId.ToString());
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
                    user.AppUserAnime.Remove(itemId.ToString());
                    break;
                case Type t when typeof(DatumManga).IsAssignableFrom(t):
                    user.AppUserManga.Remove(itemId.ToString());
                    break;
                case Type t when typeof(Game).IsAssignableFrom(t):
                    user.AppUserGame.Remove(itemId.ToString());
                    break;
                case Type t when typeof(Movie).IsAssignableFrom(t):
                    user.AppUserMovie.Remove(itemId.ToString());
                    break;
                case Type t when typeof(TvShow).IsAssignableFrom(t):
                    user.AppUserTvShow.Remove(itemId.ToString());
                    break;
                default:
                    break;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetItemForUser<T>(Guid userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);

            var listOfItemsForUser = new List<T>();

            switch (typeof(T))
            {
                case Type t when typeof(Datum).IsAssignableFrom(t):
                    foreach (var animeId in user.AppUserAnime)
                    {
                        var anime = await _animeRepository.GetAnimeByIdAsync(new ObjectId(animeId));

                        if (anime != null) listOfItemsForUser.Add((T)Convert.ChangeType(anime, typeof(T)));
                    }
                    break;

                case Type t when typeof(DatumManga).IsAssignableFrom(t):
                    foreach (var mangaId in user.AppUserManga)
                    {
                        var manga = await _mangaRepository.GetMangaByIdAsync(new ObjectId(mangaId));

                        if (manga != null) listOfItemsForUser.Add((T)Convert.ChangeType(manga, typeof(T)));
                    }
                    break;

                case Type t when typeof(Game).IsAssignableFrom(t):
                    foreach (var gameId in user.AppUserGame)
                    {
                        var game = await _gamesRepository.GetGameByIdAsync(new ObjectId(gameId));

                        if (game != null) listOfItemsForUser.Add((T)Convert.ChangeType(game, typeof(T)));
                    }
                    break;

                case Type t when typeof(Movie).IsAssignableFrom(t):
                    foreach (var movieId in user.AppUserMovie)
                    {
                        var movie = await _moviesRepository.GetMovieByIdAsync(new ObjectId(movieId));

                        if (movie != null) listOfItemsForUser.Add((T)Convert.ChangeType(movie, typeof(T)));
                    }
                    break;

                case Type t when typeof(TvShow).IsAssignableFrom(t):
                    foreach (var tvShowId in user.AppUserTvShow)
                    {
                        var tvShow = await _tvShowsRepository.GetTvShowByIdAsync(new ObjectId(tvShowId));

                        if (tvShow != null) listOfItemsForUser.Add((T)Convert.ChangeType(tvShow, typeof(T)));
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
                    isItemAlreadyAdded = user.AppUserAnime.Contains(itemId.ToString());
                    break;
                case Type t when typeof(DatumManga).IsAssignableFrom(t):
                    isItemAlreadyAdded = user.AppUserManga.Contains(itemId.ToString());
                    break;
                case Type t when typeof(Game).IsAssignableFrom(t):
                    isItemAlreadyAdded = user.AppUserGame.Contains(itemId.ToString());
                    break;
                case Type t when typeof(Movie).IsAssignableFrom(t):
                    isItemAlreadyAdded = user.AppUserMovie.Contains(itemId.ToString());
                    break;
                case Type t when typeof(TvShow).IsAssignableFrom(t):
                    isItemAlreadyAdded = user.AppUserTvShow.Contains(itemId.ToString());
                    break;
                default:
                    break;
            }

            return isItemAlreadyAdded;
        }
    }
}
