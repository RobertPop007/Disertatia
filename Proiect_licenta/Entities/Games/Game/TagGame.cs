using System;
using System.ComponentModel.DataAnnotations;

namespace Proiect_licenta.Entities.Games.Game
{
    public class TagGame
    {
        [Key]
        public Guid TagGameId { get; set; } = Guid.NewGuid();
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Language { get; set; }
        public int Games_count { get; set; }
        public string Image_background { get; set; }
    }
}
