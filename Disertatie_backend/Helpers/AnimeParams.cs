namespace Disertatie_backend.Helpers
{
    public class AnimeParams : PaginationParams
    {
        public string SearchedAnime { get; set; }
        public string OrderBy { get; set; } = "Score";
    }
}
