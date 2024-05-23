using Disertatie_backend.Extensions;
using System;

namespace Disertatie_backend.Entities.User
{
    public class FriendRequest
    {
        public Guid FromUserId { get; set; }
        public AppUser FromUser { get; set; }
        public Guid ToUserId { get; set; }
        public AppUser ToUser { get; set; }
        public DateTime SinceDate { get; set; }
        public int DaysOfRequestFriendships { get { return Days(); } }
        private int Days()
        {
            return SinceDate.CalculateDaysOfFriendship();
        }
    }
}
