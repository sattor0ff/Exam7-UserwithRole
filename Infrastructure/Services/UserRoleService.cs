
using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class UserRoleService
{

    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public UserRoleService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<Response<List<UserRoleDto>>> GetUserRoles()
    {
            var result = await _context.UserRoles.ToListAsync();
            return new Response<List<UserRoleDto>>(_mapper.Map<List<UserRoleDto>>(result));
    }
    
    public async Task<Response<UserRoleDto>> GetUserRoleById(int id)
    {
        try
        {
            var result =  await _context.UserRoles.FindAsync(id);
            var mapped = _mapper.Map<UserRoleDto>(result);
            return new Response<UserRoleDto>(mapped);
        }
        catch (System.Exception ex)
        {
            return new Response<UserRoleDto>(HttpStatusCode.InternalServerError, new List<string>(){"Server Error!"});
        }
        
    }
    public async Task<Response<UserRoleDto>> AddUserRole(UserRoleDto model)
    {
        try
        {
            var added = _mapper.Map<UserRole>(model);
            _context.UserRoles.Add(added);
            await _context.SaveChangesAsync();
            return new Response<UserRoleDto>(model);
        }
        catch (System.Exception ex)
        {
            return new Response<UserRoleDto>(HttpStatusCode.InternalServerError, new List<string>(){ex.Message});
        }
        
    }
    public async Task<Response<UserRoleDto>> UpdateUserRole(UserRoleDto model)
    {
        try
        {
            var mapped = _mapper.Map<UserRole>(model);
            _context.UserRoles.Update(mapped);
            await _context.SaveChangesAsync();
            return new Response<UserRoleDto>(model);

        }
        catch (System.Exception ex)
        {
            return new  Response<UserRoleDto> (HttpStatusCode.InternalServerError, new List<string>(){ex.Message});
        }
        
    }
    public async Task<Response<string>> DeleteUserRole(int id)
    {
        var existing  = await _context.UserRoles.FindAsync(id);
        if(existing == null) return new Response<string>(HttpStatusCode.NotFound, new List<string>(){"NotFound"});
        _context.UserRoles.Remove(existing);
        await _context.SaveChangesAsync();
        return new Response<string>("Deleted successfully");
    }
}