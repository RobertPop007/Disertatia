using Disertatie_backend.Entities.Games.Game;

namespace Disertatie_backend.Entities
{
    public class AppUserGameItem
    {
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int GameId { get; set; }
        public Game GameItem { get; set; }
    }
}
