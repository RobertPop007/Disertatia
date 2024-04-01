using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace Disertatie_backend.Entities.Anime
{
    public class Jpg
    {
#nullable enable
        public string? Image_url { get; set; }
        public string? Small_image_url { get; set; }
        public string? Large_image_url { get; set; }
    }
}
