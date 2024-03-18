namespace Backend.Helpers;

public class MovieParams : PaginationParams
{
    public string SearchedMovie { get; set; }
    public string OrderBy { get; set; } = "ImDbRating";
}
