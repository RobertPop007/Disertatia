using System.Collections.Generic;

namespace Disertatie_backend.Entities.Movies
{
    public class MoviesImages
    {
        public string ImDbId { get; set; }
        public string Title { get; set; }
        public string FullTitle { get; set; }
        public string Type { get; set; }
        public string Year { get; set; }
        public List<Item> Items { get; set; }
        public string ErrorMessage { get; set; }
    }
}
