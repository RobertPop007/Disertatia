using System;
using System.ComponentModel.DataAnnotations;

namespace Proiect_licenta.Entities.TvShows
{
    public class TvShowBoxOffice
    {
        [Key]
        public Guid TvShowBoxOfficeId { get; set; } = Guid.NewGuid();
        public string Budget { get; set; }
        public string OpeningWeekendUSA { get; set; }
        public string GrossUSA { get; set; }
        public string CumulativeWorldwideGross { get; set; }
    }
}
