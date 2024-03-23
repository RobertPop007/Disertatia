using System.Collections.Generic;

namespace Backend.DTO.Movies
{
    public class MovieGeneralInfoDto
    {
        public List<MovieItemDto> Items { get; set; }
        public string ErrorMessage { get; set; }
    }
}
