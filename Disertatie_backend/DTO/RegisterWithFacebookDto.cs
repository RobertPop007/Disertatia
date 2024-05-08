using System.ComponentModel.DataAnnotations;
using System;
using Newtonsoft.Json;

namespace Disertatie_backend.DTO
{
    public class RegisterWithFacebookDto
    {
        [Required]
        [JsonProperty("name")]
        public string Username { get; set; }

        [Required]
        [JsonProperty("email")]
        public string Email { get; set; }

        [Required]
        public string KnownAs { get; set; }

        [Required]
        [JsonProperty("gender")]
        public string Gender { get; set; }

        [Required]
        [JsonProperty("birthday")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
