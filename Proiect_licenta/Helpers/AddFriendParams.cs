namespace Disertatie_backend.Helpers
{
    public class AddFriendParams : PaginationParams
    {
        public int UserId { get; set; }
        public string Predicate { get; set; }
    }
}
