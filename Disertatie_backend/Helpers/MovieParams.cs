namespace Disertatie_backend.Helpers
{
    public class MovieParams : PaginationParams
    {
        public string SearchedMovie { get; set; }
        public string OrderBy { get; set; } = "popularity";
    }
}
