using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Disertatie_backend.Entities.User
{
    public class AppUserBookItem
    {
        public Guid AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        public AppUser AppUser { get; set; }

        public string BookId { get; set; }
    }
}
