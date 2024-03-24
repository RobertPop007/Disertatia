using System;

namespace Disertatie_backend.Entities.Anime
{
    public class Pagination
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int LastVisiblePage { get; set; }
        public bool HasNextPage { get; set; }
    }
}
