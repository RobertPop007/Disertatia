using System;
using System.ComponentModel.DataAnnotations;

namespace Disertatie_backend.Entities.Games.Game
{
    public class PlatformChildGame
    {
        [Key]
        public Guid PlatformChildGameId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Slug { get; set; }
        public int Id { get; set; }
    }
}
