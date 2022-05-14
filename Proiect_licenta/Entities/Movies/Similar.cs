using System;
using System.ComponentModel.DataAnnotations;

namespace Proiect_licenta.Entities.Movies
{
    public class Similar
    {
        [Key]
        public Guid SimilarId { get; set; } = Guid.NewGuid();
        public string Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string ImDbRating { get; set; }
        public string Year { get; set; }
    }
}
