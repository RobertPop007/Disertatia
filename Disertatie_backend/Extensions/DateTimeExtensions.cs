using System;

namespace Disertatie_backend.Extensions
{
    public static class DateTimeExtensions
    {
        public static int CalculateAge(this DateTime dob)
        {
            var today = DateTime.Today;
            var age = today.Year - dob.Year;

            if (dob.Date > today.AddYears(-age)) age--;

            return age;
        }

        public static int CalculateDaysOfFriendship(this DateTime sinceDate)
        {
            TimeSpan days = DateTime.Today - sinceDate;

            return days.Days;
        }
    }
}
