using MongoDB.Bson;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Disertatie_backend.Entities
{
    public class Review
    {
        [Key]
        public Guid ReviewId { get; set; }

        public Guid UserId { get; set; }
        public AppUser User { get; set; }

        public ObjectId ItemId { get; set; }
        public ItemType ItemType { get; set; }
        public string Short_description { get; set; }
        public string Main_description { get; set; }

        [Range(1, 10, ErrorMessage = "Value must be between 1 and 10")]
        public byte Stars { get; set; }
        public DateTime ReviewDate { get; set; } = DateTime.Now;

    }

    public enum ItemType
    {
        Movie,
        TvShow,
        Anime,
        Manga,
        Game
    }
}