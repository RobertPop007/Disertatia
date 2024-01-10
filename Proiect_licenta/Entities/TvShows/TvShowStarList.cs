using System;
using System.ComponentModel.DataAnnotations;

namespace Proiect_licenta.Entities.TvShows
{
    public class TvShowStarList
    {
        [Key]
        public Guid TvShowStarListId { get; set; } = Guid.NewGuid();
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
