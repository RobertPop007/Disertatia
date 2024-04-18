﻿namespace Disertatie_backend.Entities.Movies
{
    public class MoviesTrailer
    {
        public string ImDbId { get; set; }
        public string Title { get; set; }
        public string FullTitle { get; set; }
        public string Type { get; set; }
        public string Year { get; set; }
        public string VideoId { get; set; }
        public string VideoTitle { get; set; }
        public string VideoDescription { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Link { get; set; }
        public string LinkEmbed { get; set; }
        public string ErrorMessage { get; set; }
    }
}