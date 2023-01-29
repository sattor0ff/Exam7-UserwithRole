using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class UserService:IUserService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public UserService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Response<string>> Login(LoginDto model)
    {
        var existing  = await _context.Users
            .FirstOrDefaultAsync(x=>(x.Email == model.Username || x.PhoneNumber == model.Username) && x.Password == model.Password);

        if (existing == null)
        {
            return new Response<string>(HttpStatusCode.BadRequest, new List<string>(){"Username or password is incorrect"});
        }

        return new Response<string>("You Logged in successfuly!");
    }

    public async Task<Response<string>> Register(RegisterDto model)
    {
        var existing = await _context.Users.FirstOrDefaultAsync(x => x.Email == model.Email || x.PhoneNumber == model.PhoneNumber);
        if (existing != null)
        {
            return new Response<string>(HttpStatusCode.BadRequest,
                new List<string>() { "This email or phone already exists" });
        }
        
        var mapped = _mapper.Map<User>(model);
        await _context.Users.AddAsync(mapped);
        await _context.SaveChangesAsync();
        return new Response<string>("You are successfully registered");
    }
}