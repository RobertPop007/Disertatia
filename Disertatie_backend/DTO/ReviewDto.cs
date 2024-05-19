using System;
using System.ComponentModel.DataAnnotations;

namespace Disertatie_backend.DTO
{
    public class ReviewDto
    {
        public Guid ReviewId { get; set; }
        public string Username { get; set; }
        public string User_photo { get; set; }

        [Required]
        public string Short_description { get; set; }

        [Required]
        public string Main_description { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "Value must be between 1 and 10")]
        public byte Stars { get; set; }
    }
}
