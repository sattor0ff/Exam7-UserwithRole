using System.Net;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;


[Route("[controller]")]


public class RoleController:ControllerBase
{       
        private readonly RoleService _roleService;

        public RoleController(RoleService roleService)
        {
                _roleService = roleService;
        }

        [HttpGet("GetRole")]
        public async Task<Response<List<RoleDto>>> GetRoles()
        {
                return await _roleService.GetRoles();
        }

        [HttpGet("GetRoleById")]
        public async Task<Response<RoleDto>> GetRoleById(int id)
        {
                return await _roleService.GetRoleById(id);
        }

        [HttpPost("AddRole")]
        public async Task<Response<RoleDto>> AddRole(RoleDto role)
        {
                if (ModelState.IsValid)
                {
                        return await _roleService.AddRole(role);
                }
                else
                {
                    var errors = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage).ToList();
                    return new Response<RoleDto>(HttpStatusCode.BadRequest, errors);
                }
        }

        [HttpPut("UpdateRole")]
        public async Task<Response<RoleDto>> UpdateRole(RoleDto role)
        {
                if (ModelState.IsValid)
                {
                        return await _roleService.UpdateRole(role);
                }
                else
                {
                        var errors = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage).ToList();
                        return new Response<RoleDto>(HttpStatusCode.BadRequest, errors);
                }
        }

        [HttpDelete("DeleteRole")]
        public async Task DeleteRole(int id)
        {
                await _roleService.DeleteRole(id);
        }
}       