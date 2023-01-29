using System.Net;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("[controller]")]
public class UserController:ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpPost("Login")]
    public async Task<Response<string>> Login(LoginDto model)
    {
        if (ModelState.IsValid)
        {
            return await _userService.Login(model);
        }
        else
        {
            return new Response<string>(HttpStatusCode.BadRequest, GetModelErrors());
        }
    }
    
    [HttpPost("Register")]
    public async Task<Response<string>> Register(RegisterDto model)
    {
        if (ModelState.IsValid)
        {
            return await _userService.Register(model);
        }
        else
        {
            return new Response<string>(HttpStatusCode.BadRequest, GetModelErrors());
        }
        
    }

    [NonAction]
    private List<string> GetModelErrors()
    {
        var errors = ModelState.Values.SelectMany(x => x.Errors.Select(x=>x.ErrorMessage)).ToList();
        return errors;
    }

}