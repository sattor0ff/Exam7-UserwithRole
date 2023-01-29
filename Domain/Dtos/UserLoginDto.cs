using Domain.Entities;

namespace Domain.Dtos;

public class UserLoginDto
{
    public DateTime LoginDate { get; set; }
    public DateTime LogoutDate { get; set; }
    public int UserId { get; set; }
    
}