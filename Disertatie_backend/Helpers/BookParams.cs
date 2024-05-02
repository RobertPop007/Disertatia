namespace Disertatie_backend.Helpers
{
    public class BookParams : PaginationParams
    {
        public string SearchedBook { get; set; }
        public string OrderBy { get; set; } = "AverageRating";
    }
}
