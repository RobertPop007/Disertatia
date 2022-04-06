using System;

namespace Proiect_licenta.Entities.Anime
{
    public class Pagination
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int LastVisiblePage { get; set; }
        public bool HasNextPage { get; set; }
    }
}
