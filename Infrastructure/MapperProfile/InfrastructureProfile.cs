using AutoMapper;
using Domain.Dtos;
using Domain.Entities;


namespace Infrastructure.MapperProfiles;

public class InfrastructureProfile : Profile
{
    public InfrastructureProfile()
    {
        CreateMap<User, RegisterDto>();
        CreateMap<RegisterDto, User>();
        CreateMap<UserLogin, UserLoginDto>();
        CreateMap<UserLoginDto, UserLogin>();
        CreateMap<UserLogin, User>();
        CreateMap<User, UserLogin>();
        CreateMap<Role, RoleDto>();
        CreateMap<RoleDto, Role>();
        CreateMap<UserRole, UserRoleDto>();
        CreateMap<UserRoleDto, UserRole>();
        CreateMap<RolePermission, RolePermissionDto>();
        CreateMap<RolePermissionDto, RolePermission>();
        CreateMap<Permission, PermissionDto>();
        CreateMap<PermissionDto, Permission>();

    }
}