using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disertatie_backend.DTO.Movies
{
    public class MovieGeneralInfoDto
    {
        public List<MovieItemDto> Items { get; set; }
        public string ErrorMessage { get; set; }
    }
}
