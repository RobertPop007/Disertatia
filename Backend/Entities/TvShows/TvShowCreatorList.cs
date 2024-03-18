using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Entities.TvShows
{
    public class TvShowCreatorList
    {
        [Key]
        public Guid TvShowCreatorListId { get; set; } = Guid.NewGuid();
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
