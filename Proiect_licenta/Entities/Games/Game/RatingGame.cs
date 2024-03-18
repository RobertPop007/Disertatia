using System;
using System.ComponentModel.DataAnnotations;

namespace Proiect_licenta.Entities.Games.Game;

public class RatingGame
{
    [Key]
    public Guid RatingGameId { get; set; } = Guid.NewGuid();
    public int Id { get; set; }
    public string Title { get; set; }
    public int Count { get; set; }
    public double Percent { get; set; }
}
