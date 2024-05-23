namespace Disertatie_backend.Helpers
{
    public class MangaParams : PaginationParams
    {
        public string SearchedManga { get; set; }
        public string OrderBy { get; set; } = "Score";
    }
}
