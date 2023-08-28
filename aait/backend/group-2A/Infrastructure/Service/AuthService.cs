using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Claims;
using System.Text;
using Application.Contracts.Identity;
using Application.Contracts.Persistance;
using Application.DTO.UserDTO;
using Application.Model;
using Domain.Entities;
using Infrastructure.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Service;

public class AuthService : IAuthService {
    
     private readonly UserManager<ApplicaionUser> _userManager;
     private readonly SignInManager<ApplicaionUser> _signInManager;
     private readonly JwtSetting _jwtSettings; 
    
     public AuthService(UserManager<ApplicaionUser> userManager,SignInManager<ApplicaionUser> signInManager, IOptions<JwtSetting> jwtSettings) 
     { 
         _userManager = userManager; 
         _signInManager = signInManager; 
         _jwtSettings = jwtSettings.Value; 
          
     } 
     
     public async Task<string?> Login(AuthRequest request, IUserRepository userRepository) 
     {
         var user = await _userManager.FindByEmailAsync(request.Email);
         if (user is null){
             Console.WriteLine("-------------------User Not Found ");
             return null;
             // throw new NotFoundException("Account",req.Email); 
         }
    
         var isCorrect = await _signInManager.PasswordSignInAsync(userName: user.UserName, request.Password,isPersistent:true, lockoutOnFailure:false);
         if (!isCorrect.Succeeded){
             Console.WriteLine("-------------------Creditial Not Found ");
             return null;
             // throw new Exception($"invalid credentials for user: {request.Email}"); 
         }
         
         Console.WriteLine("-------------UseR Repository started");

         var customeUser = await userRepository.GetUserByEmail(user.Email);

         Console.WriteLine("---------------OKKKKKKKKKKKKK  JWT");
         JwtSecurityToken token = await GenerateToken(user, customeUser.Id.ToString());
         var Token = new JwtSecurityTokenHandler().WriteToken(token);
         Console.WriteLine("---------------OKKKKKKKKKKKKK  JWT");
         return Token; 
     
     } 
     
     public async Task<bool?> Register(CreateUserDTO req, IUserRepository userRepository) 
     {
         var alreadyExist = await _userManager.FindByEmailAsync(req.Email); 
         if (alreadyExist is not null){
             Console.WriteLine("----Email Exist");
             return null;
             // throw new Exception($"{req.Email} already exist"); 
         } 
    
         var user = new ApplicaionUser { 
             Email = req.Email, 
             UserName = req.UserName, 
             EmailConfirmed = true
         };
         var creatingUser = await _userManager.CreateAsync(user, req.Password);
         if (!creatingUser.Succeeded){
             Console.WriteLine("Create Error ---------------");
             Console.WriteLine(creatingUser.ToString());
             return null;
             // throw new Exception($"Failed to register \n"); 
         } 
         Console.WriteLine("User Registered");
         AuthRequest request = new AuthRequest {Email = req.Email, Password = req.Password };
         return true;
         // return await this.Login(request, userRepository);
     }
     private async Task<JwtSecurityToken> GenerateToken(ApplicaionUser user, string Id){
         var claims = new[]{
             new Claim(JwtRegisteredClaimNames.Sub, user.Email),
             new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
             new Claim(JwtRegisteredClaimNames.Email, user.Email),
             new Claim("reader", Id)
    
         };
         var ssk = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key)); 
         var credentialsHashs = new SigningCredentials(ssk,SecurityAlgorithms.HmacSha256); 
     
         var jwtToken = new JwtSecurityToken( 
             issuer: _jwtSettings.Issuer, 
             audience: _jwtSettings.Audience, 
             claims: claims, 
             expires: DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes), 
             signingCredentials: credentialsHashs 
         );
         return jwtToken;
     }

     public async Task<bool> Update(UpdateUserDTO request, string prevEmail){
         
         var user = await _userManager.FindByEmailAsync(prevEmail);
         if (user is null){
             return false;
             // throw new NotFoundException("User", userId); 
         }

         user.Email = request.Email;
         user.UserName = request.UserName; // Assuming email is also used as the username
         var result = await _userManager.UpdateAsync(user);
         return result.Succeeded;
     }
     
}