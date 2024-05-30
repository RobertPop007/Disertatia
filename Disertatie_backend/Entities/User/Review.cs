using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Disertatie_backend.Entities.User
{
    public class Review
    {
        [Key]
        public Guid ReviewId { get; set; }
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string? UserPhoto { get; set; } = null;

        [ForeignKey("UserId")]
        public AppUser User { get; set; }

        public string ItemId { get; set; }
        public string ShortDescription { get; set; }
        public string MainDescription { get; set; }

        [Range(1, 10, ErrorMessage = "Value must be between 1 and 10")]
        public byte Stars { get; set; }
        public DateTime ReviewDate { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
    }
}