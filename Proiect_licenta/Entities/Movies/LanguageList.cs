using System;
using System.ComponentModel.DataAnnotations;

namespace Proiect_licenta.Entities.Movies;

public class LanguageList
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Key { get; set; }
    public string Value { get; set; }
}
