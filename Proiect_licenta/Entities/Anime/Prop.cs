using System;

namespace Disertatie_backend.Entities.Anime
{
    public class Prop
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public From From { get; set; }
        public To To { get; set; }
    }
}
