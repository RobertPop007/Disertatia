namespace Backend.Helpers;

public class AddMovieParams : PaginationParams
{
    public int UserId { get; set; }
    public string Predicate { get; set; }
}
