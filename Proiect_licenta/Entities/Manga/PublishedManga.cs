using System;

namespace Proiect_licenta.Entities.Manga;

public class PublishedManga
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime? From { get; set; }
    public DateTime? To { get; set; }
    public PropManga Prop { get; set; }
    public string String { get; set; }
}
