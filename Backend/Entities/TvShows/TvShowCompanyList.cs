﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Entities.TvShows
{
    public class TvShowCompanyList
    {
        [Key]
        public Guid TvShowCompanyListId { get; set; } = Guid.NewGuid();
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
