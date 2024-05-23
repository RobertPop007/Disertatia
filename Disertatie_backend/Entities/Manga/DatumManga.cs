using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.EntityFrameworkCore;
using Disertatie_backend.Entities.User;
using Disertatie_backend.DTO;
using System;

namespace Disertatie_backend.Entities.Manga
{
    [Collection("Manga")]
    public class DatumManga
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
#nullable enable
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Mal_id { get; set; }
        public string? Url { get; set; }
        public ImagesManga? Images { get; set; }
        public string? Title { get; set; }
        public string? TitleEnglish { get; set; }
        public string? TitleJapanese { get; set; }
        public string? Type { get; set; }
        public int? Chapters { get; set; }
        public int? Volumes { get; set; }
        public string? Status { get; set; }
        public bool? Publishing { get; set; }
        public PublishedManga? Published { get; set; }
        public double? Score { get; set; }
        public double? Scored { get; set; }
        public int? ScoredBy { get; set; }
        public int? Rank { get; set; }
        public int? Popularity { get; set; }
        public int? Members { get; set; }
        public int? Favorites { get; set; }
        public string? Synopsis { get; set; }
        public string? Background { get; set; }
        public IList<AuthorManga>? Authors { get; set; }
        public IList<SerializationManga>? Serializations { get; set; }
        public IList<GenreManga>? Genres { get; set; }
        public IList<ThemeManga>? Themes { get; set; }
        public IList<DemographicManga>? Demographics { get; set; }
        public HashSet<Guid>? ReviewsIds { get; set; } = new HashSet<Guid>();
    }
}
