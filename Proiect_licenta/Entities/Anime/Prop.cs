using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace Disertatie_backend.Entities.Anime
{
    public class Prop
    {
#nullable enable
        public From? From { get; set; }
        public To? To { get; set; }
    }
}
