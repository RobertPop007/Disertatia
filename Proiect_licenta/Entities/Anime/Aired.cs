using System;
using System.ComponentModel.DataAnnotations;

namespace Proiect_licenta.Entities.Anime;

public class Aired
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime From { get; set; }
    public DateTime? To { get; set; }
    public Prop Prop { get; set; }
    public string String { get; set; }
}
