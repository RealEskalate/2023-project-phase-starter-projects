using Application.DTO.UserDTO;
using Application.Model;
using Domain.Entities;

namespace Application.Contracts.Identity;

public interface IAuthService{
    Task<string> Login(AuthRequest request);
    Task<string> Register(User reqeuest);
    Task<bool> Update(UpdateUserDTO request, string prevEmail); 

}