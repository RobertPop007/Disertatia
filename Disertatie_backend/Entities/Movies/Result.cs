﻿using System.Collections.Generic;
using System;
using Newtonsoft.Json;

namespace Disertatie_backend.Entities.Movies
{
    public class Result
    {
        public string Iso6391 { get; set; }

        public string Iso31661 { get; set; }
        public string Name { get; set; }

        public string Key { get; set; }

        public string Site { get; set; }

        public int Size { get; set; }

        public string Type { get; set; }

        public bool Official { get; set; }

        public DateTime PublishedAt { get; set; }

        public string Id { get; set; }

        public bool Adult { get; set; }

        public string BackdropPath { get; set; }

        public List<int> GenreIds { get; set; }

        public string OriginalLanguage { get; set; }

        public string OriginalTitle { get; set; }

        public string Overview { get; set; }

        public double Popularity { get; set; }

        public string PosterPath { get; set; }

        public string ReleaseDate { get; set; }
        public string Title { get; set; }

        public bool Video { get; set; }

        public double VoteAverage { get; set; }

        public int VoteCount { get; set; }
    }
}
