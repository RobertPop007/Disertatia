using System;

namespace Disertatie_backend.Entities.Manga
{
    public class PublishedManga
    {
#nullable enable
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public PropManga? Prop { get; set; }
        public string? String { get; set; }
    }
}
