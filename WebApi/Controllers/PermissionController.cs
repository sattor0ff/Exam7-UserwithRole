using System.Net;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;


[Route("[controller]")]


public class PermissionController:ControllerBase
{       
        private readonly PermissionService _permissionService;

        public PermissionController(PermissionService permissionService)
        {
                _permissionService = permissionService;
        }

        [HttpGet("GetPermission")]
        public async Task<Response<List<PermissionDto>>> GetPermissions()
        {
                return await _permissionService.GetPermissions();
        }

        [HttpGet("GetPermissionById")]
        public async Task<Response<PermissionDto>> GetPermissionById(int id)
        {
                return await _permissionService.GetPermissionById(id);
        }

        [HttpPost("AddPermission")]
        public async Task<Response<PermissionDto>> AddPermission(PermissionDto permission)
        {
                if (ModelState.IsValid)
                {
                        return await _permissionService.AddPermission(permission);
                }
                else
                {
                    var errors = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage).ToList();
                    return new Response<PermissionDto>(HttpStatusCode.BadRequest, errors);
                }
        }

        [HttpPut("UpdatePermission")]
        public async Task<Response<PermissionDto>> UpdatePermission(PermissionDto permission)
        {
                if (ModelState.IsValid)
                {
                        return await _permissionService.UpdatePermission(permission);
                }
                else
                {
                        var errors = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage).ToList();
                        return new Response<PermissionDto>(HttpStatusCode.BadRequest, errors);
                }
        }

        [HttpDelete("DeletePermission")]
        public async Task DeletePermission(int id)
        {
                await _permissionService.DeletePermission(id);
        }
}       