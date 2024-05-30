using System.Collections.Generic;

namespace Disertatie_backend.Entities.Movies
{
    public class Similar
    {
        public int Page { get; set; }
        public List<Result> Results { get; set; }
        public int TotalPages { get; set; }
        public int TotalResults { get; set; }
    }
}
