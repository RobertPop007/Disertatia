using System;
using System.ComponentModel.DataAnnotations;

namespace Disertatie_backend.Entities.Games.Game
{
    public class PlatformGame
    {
        [Key]
        public Guid PlatformGameId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Slug { get; set; }
        public int Id { get; set; }
        public string Image { get; set; }
        public int? Year_end { get; set; }
        public int? Year_start { get; set; }
        public int Games_count { get; set; }
        public string Image_background { get; set; }

    }
}
