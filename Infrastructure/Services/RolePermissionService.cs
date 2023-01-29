
using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class RolePermissionService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public RolePermissionService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<Response<List<RolePermissionDto>>> GetRolePermissions()
    {
            var result = await _context.RolePermissions.ToListAsync();
            return new Response<List<RolePermissionDto>>(_mapper.Map<List<RolePermissionDto>>(result));
    }
    
    public async Task<Response<RolePermissionDto>> GetRolePermissionById(int id)
    {
        try
        {
            var result =  await _context.RolePermissions.FindAsync(id);
            var mapped = _mapper.Map<RolePermissionDto>(result);
            return new Response<RolePermissionDto>(mapped);
        }
        catch (System.Exception ex)
        {
            return new Response<RolePermissionDto>(HttpStatusCode.InternalServerError, new List<string>(){"Server Error!"});
        }
        
    }
    public async Task<Response<RolePermissionDto>> AddRolePermission(RolePermissionDto model)
    {
        try
        {
            var added = _mapper.Map<RolePermission>(model);
            _context.RolePermissions.Add(added);
            await _context.SaveChangesAsync();
            return new Response<RolePermissionDto>(model);
        }
        catch (System.Exception ex)
        {
            return new Response<RolePermissionDto>(HttpStatusCode.InternalServerError, new List<string>(){ex.Message});
        }
        
    }
    public async Task<Response<RolePermissionDto>> UpdateRolePermission(RolePermissionDto model)
    {
        try
        {
            var mapped = _mapper.Map<RolePermission>(model);
            _context.RolePermissions.Update(mapped);
            await _context.SaveChangesAsync();
            return new Response<RolePermissionDto>(model);

        }
        catch (System.Exception ex)
        {
            return new  Response<RolePermissionDto> (HttpStatusCode.InternalServerError, new List<string>(){ex.Message});
        }
        
    }
    public async Task<Response<string>> DeleteRolePermission(int id)
    {
        var existing  = await _context.RolePermissions.FindAsync(id);
        if(existing == null) return new Response<string>(HttpStatusCode.NotFound, new List<string>(){"NotFound"});
        _context.RolePermissions.Remove(existing);
        await _context.SaveChangesAsync();
        return new Response<string>("Deleted successfully");
    }
}