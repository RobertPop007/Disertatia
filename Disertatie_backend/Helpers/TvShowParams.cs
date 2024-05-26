namespace Disertatie_backend.Helpers
{
    public class TvShowParams : PaginationParams
    {
        public string SearchedTvShow { get; set; }
        public string OrderBy { get; set; } = "voteAverage";
    }
}
