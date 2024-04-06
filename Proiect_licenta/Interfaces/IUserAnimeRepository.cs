using Disertatie_backend.Entities;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace Disertatie_backend.Interfaces
{
    public interface IUserAnimeRepository
    {
        Task<AppUserAnimeItem> GetItemById(ObjectId userId, ObjectId animeId);
        Task AddItem(AppUserAnimeItem appUserAnimeItem);
    }
}