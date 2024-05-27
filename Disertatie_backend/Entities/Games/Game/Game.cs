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
        public int GameId { get; set; }
        public string Trailer { get; set; }
        public string? Slug { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Metacritic { get; set; }
        public string? Released { get; set; }
        public bool? Tba { get; set; }
        public DateTime? Updated { get; set; }
        public string? BackgroundImage { get; set; }
        public string? BackgroundImageAdditional { get; set; }
        public string? Website { get; set; }
        public double? Rating { get; set; }
        public int? RatingTop { get; set; }
        public List<RatingGame>? Ratings { get; set; }
        public int? Added { get; set; }
        public AddedByStatusGame? AddedByStatus { get; set; }
        public int? MoviesCount { get; set; }
        public int? CreatorsCount { get; set; }
        public int? AchievementsCount { get; set; }
        public int? ParentAchievementsCount { get; set; }
        public int? TwitchCount { get; set; }
        public int? YoutubeCount { get; set; }
        public int? ReviewsTextCount { get; set; }
        public int? RatingsCount { get; set; }
        public int? SuggestionsCount { get; set; }
        public string? MetacriticUrl { get; set; }
        public int? GameSeriesCount { get; set; }
        public int? ReviewsCount { get; set; }
        public List<PlatformsGame>? Platforms { get; set; }
        public List<StoresGame>? Stores { get; set; }
        public List<DeveloperGame>? Developers { get; set; }
        public List<GenreGame>? Genres { get; set; }
        public List<TagGame>? Tags { get; set; }
        public List<PublisherGame>? Publishers { get; set; }
        public EsrbRatingGame? EsrbRating { get; set; }
        public string? DescriptionRaw { get; set; }
        public HashSet<Guid>? ReviewsIds { get; set; } = new HashSet<Guid>();
    }
}
