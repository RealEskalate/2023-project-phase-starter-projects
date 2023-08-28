using Application.Contracts.Persistance;
using Application.DTO.UserDTO;
using Application.Model;
using Domain.Entities;

namespace Application.Contracts.Identity;

public interface IAuthService{
    Task<string> Login(AuthRequest request, IUserRepository userRepository);
    Task<bool?> Register(CreateUserDTO reqeuest, IUserRepository userRepository);
    Task<bool> Update(UpdateUserDTO request, string prevEmail); 

}