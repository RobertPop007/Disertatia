using Disertatie_backend.Extensions;
using System;

namespace Disertatie_backend.Entities
{
    public class Friendships
    {
        public Guid UserID1 { get; set; }
        public AppUser User1 { get; set; }
        public Guid UserID2 { get; set; }
        public AppUser User2 { get; set; }
        public DateTime SinceDate { get; set; }
        public int DaysOfFriendships { get { return Days(); } }
        private int Days()
        {
            return SinceDate.CalculateDaysOfFriendship();
        }
    }
}
