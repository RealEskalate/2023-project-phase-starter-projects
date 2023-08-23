using Application.Common.Model;
using Application.Contracts.Auth;
using Application.DTOS.Auth;
using Application.Exceptions;
using Application.Features.Auth.Request;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Handler
{
    public class LoginUserRequestHandler : IRequestHandler<LoginUserRequest, LoginResponseDto>
    {

        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly JwtSettings _jwtSettings;

        public LoginUserRequestHandler(IAuthService authService, IMapper mapper, IOptions<JwtSettings> jwtSettings)
        {
            _authService = authService;
            _mapper = mapper;
            _jwtSettings = jwtSettings.Value;
        }
        public async Task<LoginResponseDto> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _authService.Login(request.loginRequest.username, request.loginRequest.password);

            if (user == null)
                throw new BadRequestException("credential provided are invalid");

            var token = GenerateToken(user);

            var response = new LoginResponseDto()
            {
                Token = token
            };

            return response;

        }

        private string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username)
                }),
                Expires = DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;


        }
    }
}
