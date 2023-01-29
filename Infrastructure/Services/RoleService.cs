
using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class RoleService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public RoleService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<Response<List<RoleDto>>> GetRoles()
    {
            var result = await _context.Roles.ToListAsync();
            return new Response<List<RoleDto>>(_mapper.Map<List<RoleDto>>(result));
    }
    
    public async Task<Response<RoleDto>> GetRoleById(int id)
    {
        try
        {
            var result =  await _context.Roles.FindAsync(id);
            var mapped = _mapper.Map<RoleDto>(result);
            return new Response<RoleDto>(mapped);
        }
        catch (System.Exception ex)
        {
            return new Response<RoleDto>(HttpStatusCode.InternalServerError, new List<string>(){"Server Error!"});
        }
        
    }
    public async Task<Response<RoleDto>> AddRole(RoleDto model)
    {
        try
        {
            var added = _mapper.Map<Role>(model);
            _context.Roles.Add(added);
            await _context.SaveChangesAsync();
            model.Id = added.Id;
            return new Response<RoleDto>(model);
        }
        catch (System.Exception ex)
        {
            return new Response<RoleDto>(HttpStatusCode.InternalServerError, new List<string>(){ex.Message});
        }
        
    }
    public async Task<Response<RoleDto>> UpdateRole(RoleDto model)
    {
        try
        {
            var mapped = _mapper.Map<Role>(model);
            _context.Roles.Update(mapped);
            await _context.SaveChangesAsync();
            return new Response<RoleDto>(model);

        }
        catch (System.Exception ex)
        {
            return new  Response<RoleDto> (HttpStatusCode.InternalServerError, new List<string>(){ex.Message});
        }
        
    }
    public async Task<Response<string>> DeleteRole(int id)
    {
        var existing  = await _context.Roles.FindAsync(id);
        if(existing == null) return new Response<string>(HttpStatusCode.NotFound, new List<string>(){"NotFound"});
        _context.Roles.Remove(existing);
        await _context.SaveChangesAsync();
        return new Response<string>("Deleted successfully");
    }
}