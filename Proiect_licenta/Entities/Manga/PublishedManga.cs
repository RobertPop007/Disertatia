using System;

namespace Disertatie_backend.Entities.Manga
{
    public class PublishedManga
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public PropManga Prop { get; set; }
        public string String { get; set; }
    }
}
