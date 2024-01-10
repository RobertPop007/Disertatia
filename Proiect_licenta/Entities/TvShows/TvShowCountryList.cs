using System;
using System.ComponentModel.DataAnnotations;

namespace Proiect_licenta.Entities.TvShows
{
    public class TvShowCountryList
    {
        [Key]
        public Guid TvShowCountryListId { get; set; } = Guid.NewGuid();
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
