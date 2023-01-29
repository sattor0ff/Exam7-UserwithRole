
using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class PermissionService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public PermissionService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<Response<List<PermissionDto>>> GetPermissions()
    {
            var result = await _context.Permissions.ToListAsync();
            return new Response<List<PermissionDto>>(_mapper.Map<List<PermissionDto>>(result));
    }
    
    public async Task<Response<PermissionDto>> GetPermissionById(int id)
    {
        try
        {
            var result =  await _context.Permissions.FindAsync(id);
            var mapped = _mapper.Map<PermissionDto>(result);
            return new Response<PermissionDto>(mapped);
        }
        catch (System.Exception ex)
        {
            return new Response<PermissionDto>(HttpStatusCode.InternalServerError, new List<string>(){"Server Error!"});
        }
        
    }
    public async Task<Response<PermissionDto>> AddPermission(PermissionDto model)
    {
        try
        {
            var added = _mapper.Map<Permission>(model);
            _context.Permissions.Add(added);
            await _context.SaveChangesAsync();
            return new Response<PermissionDto>(model);
        }
        catch (System.Exception ex)
        {
            return new Response<PermissionDto>(HttpStatusCode.InternalServerError, new List<string>(){ex.Message});
        }
        
    }
    public async Task<Response<PermissionDto>> UpdatePermission(PermissionDto model)
    {
        try
        {
            var mapped = _mapper.Map<Permission>(model);
            _context.Permissions.Update(mapped);
            await _context.SaveChangesAsync();
            return new Response<PermissionDto>(model);

        }
        catch (System.Exception ex)
        {
            return new  Response<PermissionDto> (HttpStatusCode.InternalServerError, new List<string>(){ex.Message});
        }
        
    }
    public async Task<Response<string>> DeletePermission(int id)
    {
        var existing  = await _context.Permissions.FindAsync(id);
        if(existing == null) return new Response<string>(HttpStatusCode.NotFound, new List<string>(){"NotFound"});
        _context.Permissions.Remove(existing);
        await _context.SaveChangesAsync();
        return new Response<string>("Deleted successfully");
    }
}