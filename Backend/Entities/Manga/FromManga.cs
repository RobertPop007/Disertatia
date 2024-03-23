using System;

namespace Backend.Entities.Manga;

public class FromManga
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public int? Day { get; set; }
    public int? Month { get; set; }
    public int? Year { get; set; }
}
