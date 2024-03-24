using System;
using System.ComponentModel.DataAnnotations;

namespace Disertatie_backend.Entities.Games.Game
{
    public class StoresGame
    {
        [Key]
        public Guid StoresGameId { get; set; } = Guid.NewGuid();
        public int Id { get; set; }
        public string Url { get; set; }
        public StoreGame Store { get; set; }
    }
}
