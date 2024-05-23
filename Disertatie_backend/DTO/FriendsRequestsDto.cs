using System;

namespace Disertatie_backend.DTO
{
    public class FriendsRequestsDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string KnownAs { get; set; }
        public string PhotoUrl { get; set; }
    }
}
