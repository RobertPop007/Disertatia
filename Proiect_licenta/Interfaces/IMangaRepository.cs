using Disertatie_backend.DTO.Manga;
using Disertatie_backend.Entities.Manga;
using Disertatie_backend.Helpers;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disertatie_backend.Interfaces
{
    public interface IMangaRepository
    {
        Task<IEnumerable<MangaCard>> GetMangasAsync(MangaParams userParams);
        Task<DatumManga> GetMangaByIdAsync(ObjectId id);
        Task<DatumManga> GetMangaByFullTitleAsync(string title);
    }
}
