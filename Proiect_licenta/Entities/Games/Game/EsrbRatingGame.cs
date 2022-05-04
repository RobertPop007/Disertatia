using System;
using System.ComponentModel.DataAnnotations;

namespace Proiect_licenta.Entities.Games.Game
{
    public class EsrbRatingGame
    {
        [Key]
        public Guid EsrbRatingGameId { get; set; } = Guid.NewGuid();
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}
