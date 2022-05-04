using System;

namespace Proiect_licenta.Entities.Games.Game
{
    public class AddedByStatusGame
    {
        public Guid AddedByStatusGameId { get; set; } = Guid.NewGuid();
        public int Yet { get; set; }
        public int Owned { get; set; }
        public int Beaten { get; set; }
        public int Toplay { get; set; }
        public int Dropped { get; set; }
        public int Playing { get; set; }
    }
}
