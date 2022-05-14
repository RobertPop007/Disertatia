﻿using Proiect_licenta.Entities.Games.Game;
using Proiect_licenta.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proiect_licenta.Interfaces
{
    public interface IGamesRepository
    {
        Task<List<Game>> GetGamesAsync(GameParams userParams);
        Task<Game> GetGameByIdAsync(int id);
        Task<Game> GetGameByFullTitleAsync(string fullTitle);
        Task<List<Game>> GetUserGames(int userId);
        bool IsGameAlreadyAdded(int userId, int gameId);
        void DeleteGameForUser(int userId, int gameId);
        Task<bool> SaveAllAsync();
    }
}
