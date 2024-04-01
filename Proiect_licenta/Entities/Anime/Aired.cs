using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace Disertatie_backend.Entities.Anime
{
    public class Aired
    {
#nullable enable
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public Prop? Prop { get; set; }
        public string? String { get; set; }
    }
}
