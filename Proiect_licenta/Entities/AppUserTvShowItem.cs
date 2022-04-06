using Proiect_licenta.Entities.TvShows;
using System.ComponentModel.DataAnnotations;

namespace Proiect_licenta.Entities
{
    public class AppUserTvShowItem
    {
        [Key]
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public string TvShowItemId { get; set; }
        public TvShowItem TvShowItem { get; set; }
    }
}
