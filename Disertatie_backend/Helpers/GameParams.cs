namespace Disertatie_backend.Helpers
{
    public class GameParams : PaginationParams
    {
        public string SearchedGame { get; set; }
        public string OrderBy { get; set; } = "Rating";
    }
}
