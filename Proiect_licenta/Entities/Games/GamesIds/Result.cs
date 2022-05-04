using System;
using System.ComponentModel.DataAnnotations;

namespace Proiect_licenta.Entities.Games.GamesIds
{
    public class Result
    {
        [Key]
        public Guid ResultId { get; set; } = new Guid();
        public int Id { get; set; }
    }
}
