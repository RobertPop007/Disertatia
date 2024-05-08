using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Disertatie_backend.Entities.User;
using Disertatie_backend.DTO;

namespace Disertatie_backend.Entities.Games.Game
{
    public class Game
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

#nullable enable
        //[JsonProperty("id")]
        public int Game_Id { get; set; }
        public string? Slug { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Metacritic { get; set; }
        public string? Released { get; set; }
        public bool? Tba { get; set; }
        public DateTime? Updated { get; set; }
        public string? Background_image { get; set; }
        public string? Background_image_additional { get; set; }
        public string? Website { get; set; }
        public double? Rating { get; set; }
        public int? Rating_top { get; set; }
        public List<RatingGame>? Ratings { get; set; }
        public int? Added { get; set; }
        public AddedByStatusGame? Added_by_status { get; set; }
        public int? Movies_count { get; set; }
        public int? Creators_count { get; set; }
        public int? Achievements_count { get; set; }
        public int? Parent_achievements_count { get; set; }
        public int? Twitch_count { get; set; }
        public int? Youtube_count { get; set; }
        public int? Reviews_text_count { get; set; }
        public int? Ratings_count { get; set; }
        public int? Suggestions_count { get; set; }
        public string? Metacritic_url { get; set; }
        public int? Game_series_count { get; set; }
        public int? Reviews_count { get; set; }
        public List<PlatformsGame>? Platforms { get; set; }
        public List<StoresGame>? Stores { get; set; }
        public List<DeveloperGame>? Developers { get; set; }
        public List<GenreGame>? Genres { get; set; }
        public List<TagGame>? Tags { get; set; }
        public List<PublisherGame>? Publishers { get; set; }
        public EsrbRatingGame? Esrb_rating { get; set; }
        public string? Description_raw { get; set; }
        public HashSet<Guid>? ReviewsIds { get; set; } = new HashSet<Guid>();
    }
}
