using Domain.Dtos;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<UserLogin> UserLogins { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
     public DbSet<Permission> Permissions { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
    


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserLogin>().HasKey(x => new { x.UserId});
        base.OnModelCreating(modelBuilder);      

        modelBuilder.Entity<UserRole>().HasKey(x => new { x.UserId, x.RoleId});
        base.OnModelCreating(modelBuilder);  

        modelBuilder.Entity<RolePermission>().HasKey(x => new { x.RoleId, x.PermissionId});
        base.OnModelCreating(modelBuilder);
    }
}