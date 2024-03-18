using System;

namespace Backend.Entities.Manga;

public class PropManga
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public FromManga From { get; set; }
    public ToManga To { get; set; }
}
