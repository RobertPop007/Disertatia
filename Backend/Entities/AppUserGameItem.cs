using Proiect_licenta.Entities.Games.Game;

namespace Proiect_licenta.Entities
{
    public class AppUserGameItem
    {
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int GameId { get; set; }
        public Game GameItem { get; set; }
    }
}
