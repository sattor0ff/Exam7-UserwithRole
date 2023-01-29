using System.Net;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;


[Route("[controller]")]


public class UserRoleController:ControllerBase
{       
        private readonly UserRoleService _userRoleService;

        public UserRoleController(UserRoleService userRoleService)
        {
                _userRoleService = userRoleService;
        }

        [HttpGet("GetUserRole")]
        public async Task<Response<List<UserRoleDto>>> GetUserRoles()
        {
                return await _userRoleService.GetUserRoles();
        }

        [HttpGet("GetUserRoleById")]
        public async Task<Response<UserRoleDto>> GetUserRoleById(int id)
        {
                return await _userRoleService.GetUserRoleById(id);
        }

        [HttpPost("AddUserRole")]
        public async Task<Response<UserRoleDto>> AddUserRole(UserRoleDto userRole)
        {
                if (ModelState.IsValid)
                {
                        return await _userRoleService.AddUserRole(userRole);
                }
                else
                {
                    var errors = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage).ToList();
                    return new Response<UserRoleDto>(HttpStatusCode.BadRequest, errors);
                }
        }

        [HttpPut("UpdateUserRole")]
        public async Task<Response<UserRoleDto>> UpdateUserRole(UserRoleDto userRole)
        {
                if (ModelState.IsValid)
                {
                        return await _userRoleService.UpdateUserRole(userRole);
                }
                else
                {
                        var errors = ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage).ToList();
                        return new Response<UserRoleDto>(HttpStatusCode.BadRequest, errors);
                }
        }

        [HttpDelete("DeleteUserRole")]
        public async Task DeleteUserRole(int id)
        {
                await _userRoleService.DeleteUserRole(id);
        }
}       