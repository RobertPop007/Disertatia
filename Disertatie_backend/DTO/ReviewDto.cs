using System;
using System.ComponentModel.DataAnnotations;

namespace Disertatie_backend.DTO
{
    public class ReviewDto
    {
        public Guid ReviewId { get; set; }
        public string Username { get; set; }
        public string UserPhoto { get; set; }

        [Required]
        public string ShortDescription { get; set; }

        [Required]
        public string MainDescription { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "Value must be between 1 and 10")]
        public byte Stars { get; set; }
        public int Score { get; set; }
    }
}
