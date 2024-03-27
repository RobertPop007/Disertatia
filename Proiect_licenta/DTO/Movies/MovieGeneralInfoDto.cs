using System.Collections.Generic;

namespace Disertatie_backend.DTO.Movies
{
    public class MovieGeneralInfoDto
    {
        public List<MovieItemDto> Items { get; set; }
        public string ErrorMessage { get; set; }
    }
}
