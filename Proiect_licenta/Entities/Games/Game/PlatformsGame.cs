using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proiect_licenta.Entities.Games.Game
{
    public class PlatformsGame
    {
        [Key]
        public Guid PlatformsGameId { get; set; } = Guid.NewGuid();
        public PlatformGame Platform { get; set; }
        public string Released_at { get; set; }
        public RequirementsGame Requirements { get; set; }
    }
}
