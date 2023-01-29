using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class RoleDto
{
    [Key]
    public int Id { get; set; }
    [Required,MaxLength(50)]
    public string Name { get; set; }
}