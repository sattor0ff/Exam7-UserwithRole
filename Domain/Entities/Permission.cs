using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Permission
{
    [Key]
    public int Id { get; set; }
    [Required,MaxLength(50)]
    public string Name { get; set; }
}