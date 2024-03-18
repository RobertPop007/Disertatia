namespace Proiect_licenta.Entities;

public class UserFriend
{
    public AppUser AddedByUser { get; set; }
    public int AddedByUserId { get; set; }

    public AppUser AddedUser { get; set; }
    public int AddedUserId { get; set; }
}
