﻿using System;

namespace Disertatie_backend.DTO
{
    public class ReviewDto
    {
        public Guid ReviewId { get; set; }
        public string Username { get; set; }
        public string Short_description { get; set; }
        public string Main_description { get; set; }
        public byte Stars { get; set; }
    }
}
