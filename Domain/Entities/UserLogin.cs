using System.ComponentModel.DataAnnotations;
using Domain.Dtos;
using Domain.Entities;

public class UserLogin
{
    public DateTime LoginDate { get; set; }
    public DateTime LogoutDate { get; set; }
    public int UserId { get; set; }
}