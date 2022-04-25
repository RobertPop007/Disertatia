using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proiect_licenta.Entities.TvShows
{
    public class TvSeriesInfo
    {
        [Key]
        public Guid TvShowInfoId { get; set; } = Guid.NewGuid();
        public string YearEnd { get; set; }
        public string Creators { get; set; }
        public List<TvShowCreatorList> CreatorList { get; set; }
        public string[] Seasons { get; set; }
    }
}
