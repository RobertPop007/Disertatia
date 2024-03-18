using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Entities.TvShows
{
    public class TvShowLanguageList
    {
        [Key]
        public Guid TvShowLanguageListId { get; set; } = Guid.NewGuid();
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
