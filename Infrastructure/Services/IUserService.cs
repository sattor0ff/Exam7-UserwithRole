using Domain.Dtos;
using Domain.Wrapper;

namespace Infrastructure.Services;

public interface IUserService
{
    Task<Response<string>> Login(LoginDto model);
    Task<Response<string>> Register(RegisterDto model);
    
}