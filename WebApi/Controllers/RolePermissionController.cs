using System.Net;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;


[Route("[controller]")]


public class RolePermissionController:ControllerBase
{       
        private readonly RolePermissionService _rolePermissionService;

        public RolePermissionController(RolePermissionService rolePermissionService)
        {
                _rolePermissionService = rolePermissionService;
        }

        [HttpGet("GetRolePermission")]
        public async Task<Response<List<RolePermissionDto>>> GetRolePermissions()
        {
                return await _rolePermissionService.GetRolePermissions();
        }

        [HttpGet("GetRolePermissionById")]
        public async Task<Response<RolePermissionDto>> GetRolePermissionById(int id)
        {
                return await _rolePermissionService.GetRolePermissionById(id);
        }

        [HttpPost("AddRolePermission")]
        public async Task<Response<RolePermissionDto>> AddRolePermission(RolePermissionDto rolePermission)
        {
                if (ModelState.IsValid)
                {
                        return await _rolePermissionService.AddRolePermission(rolePermission);
                }
                else
                {
                    var errors = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage).ToList();
                    return new Response<RolePermissionDto>(HttpStatusCode.BadRequest, errors);
                }
        }

        [HttpPut("UpdateRolePermission")]
        public async Task<Response<RolePermissionDto>> UpdateRolePermission(RolePermissionDto rolePermission)
        {
                if (ModelState.IsValid)
                {
                        return await _rolePermissionService.UpdateRolePermission(rolePermission);
                }
                else
                {
                        var errors = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage).ToList();
                        return new Response<RolePermissionDto>(HttpStatusCode.BadRequest, errors);
                }
        }

        [HttpDelete("DeleteRolePermission")]
        public async Task DeleteRolePermission(int id)
        {
                await _rolePermissionService.DeleteRolePermission(id);
        }
}       