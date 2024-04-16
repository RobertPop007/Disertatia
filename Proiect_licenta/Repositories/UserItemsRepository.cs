﻿using Disertatie_backend.Entities.Anime;
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
using System.Linq;

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
                    user.AppUserAnime.Add(new AppUserAnimeItem() { AppUserId = user.Id, AnimeId = itemId.ToString() });
                    break;
                case Type t when typeof(DatumManga).IsAssignableFrom(t):
                    user.AppUserManga.Add(new AppUserMangaItem() { AppUserId = user.Id, MangaId = itemId.ToString() });
                    break;
                case Type t when typeof(Game).IsAssignableFrom(t):
                    user.AppUserGame.Add(new AppUserGameItem() { AppUserId = user.Id, GameId = itemId.ToString() });
                    break;
                case Type t when typeof(Movie).IsAssignableFrom(t):
                    user.AppUserMovie.Add(new AppUserMovieItem() { AppUserId = user.Id, MovieId = itemId.ToString() });
                    break;
                case Type t when typeof(TvShow).IsAssignableFrom(t):
                    user.AppUserTvShow.Add(new AppUserTvShowItem() { AppUserId = user.Id, TvShowId = itemId.ToString() });
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
                    user.AppUserAnime.Remove(new AppUserAnimeItem() { AppUserId = user.Id, AnimeId = itemId.ToString() });
                    break;
                case Type t when typeof(DatumManga).IsAssignableFrom(t):
                    user.AppUserManga.Remove(new AppUserMangaItem() { AppUserId = user.Id, MangaId = itemId.ToString() });
                    break;
                case Type t when typeof(Game).IsAssignableFrom(t):
                    user.AppUserGame.Remove(new AppUserGameItem() { AppUserId = user.Id, GameId = itemId.ToString() });
                    break;
                case Type t when typeof(Movie).IsAssignableFrom(t):
                    user.AppUserMovie.Remove(new AppUserMovieItem() { AppUserId = user.Id, MovieId = itemId.ToString() });
                    break;
                case Type t when typeof(TvShow).IsAssignableFrom(t):
                    user.AppUserTvShow.Remove(new AppUserTvShowItem() { AppUserId = user.Id, TvShowId = itemId.ToString() });
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
                    isItemAlreadyAdded = user.AppUserAnime.Any(u => u.AnimeId == itemId.ToString());
                    break;
                case Type t when typeof(DatumManga).IsAssignableFrom(t):
                    isItemAlreadyAdded = user.AppUserManga.Any(u => u.MangaId == itemId.ToString());
                    break;
                case Type t when typeof(Game).IsAssignableFrom(t):
                    isItemAlreadyAdded = user.AppUserGame.Any(u => u.GameId == itemId.ToString());
                    break;
                case Type t when typeof(Movie).IsAssignableFrom(t):
                    isItemAlreadyAdded = user.AppUserMovie.Any(u => u.MovieId == itemId.ToString());
                    break;
                case Type t when typeof(TvShow).IsAssignableFrom(t):
                    isItemAlreadyAdded = user.AppUserTvShow.Any(u => u.TvShowId == itemId.ToString());
                    break;
                default:
                    break;
            }

            return isItemAlreadyAdded;
        }
    }
}
