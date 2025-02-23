

using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class ServiceEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

}