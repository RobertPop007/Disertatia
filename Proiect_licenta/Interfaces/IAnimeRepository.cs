using Disertatie_backend.DTO.Anime;
using Disertatie_backend.Entities;
using Disertatie_backend.Entities.Anime;
using Disertatie_backend.Helpers;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disertatie_backend.Interfaces
{
    public interface IAnimeRepository
    {
        Task<IEnumerable<AnimeCard>> GetAnimesAsync(AnimeParams userParams);
        Task<Datum> GetAnimeByIdAsync(ObjectId id);
        Task<Datum> GetAnimeByFullTitleAsync(string title);
    }
}
