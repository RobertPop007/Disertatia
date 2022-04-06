using System;

namespace Proiect_licenta.Entities.Anime
{
    public class From
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
}
