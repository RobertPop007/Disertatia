using System;
using System.ComponentModel.DataAnnotations;

namespace Proiect_licenta.Entities.Games.Game;

public class ParentPlatformGame
{
    [Key]
    public Guid ParentPlatformGameId { get; set; } = Guid.NewGuid();
    public PlatformChildGame Platform { get; set; }
}
