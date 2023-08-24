using Application.Model;
using Domain.Entities;

namespace Application.Contracts.Identity;

public interface IAuthService{
    Task<string> Login(AuthRequest request);
    Task<string> Register(User reqeuest);

}