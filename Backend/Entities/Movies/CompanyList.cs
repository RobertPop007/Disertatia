using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Entities.Movies;

public class CompanyList
{
    [Key]
    public Guid CompanyId { get; set; } = Guid.NewGuid();
    public string Id { get; set; }
    public string Name { get; set; }
}
