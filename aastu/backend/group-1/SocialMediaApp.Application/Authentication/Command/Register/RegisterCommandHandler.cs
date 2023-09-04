using MediatR;
using SocialMediaApp.Application.Persistence.Contracts.Common;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SocialMediaApp.Application.Authentication.Common;
using SocialMediaApp.Application.Authentication.Command.Validations;
using SocialMediaApp.Application.Exceptions;
using SocialMediaApp.Application.Persistence.Contracts.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace SocialMediaApp.Application.Authentication.Command.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, string>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        private readonly IUserRepository _userRepository;

        private readonly IPasswordService _passwordService;

        private readonly IEmailSender _emailSender;
        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository, IPasswordService passwordService, IEmailSender emailSender)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
            _passwordService = passwordService;
            _emailSender = emailSender;
        }

        public async Task<String> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {

            
            // validate if the user email does not exist

            if (_userRepository.GetByEmail(command.Email) is not null)
            {
                throw new Exception("User with the given email already exists");
            }

            string h_password = _passwordService.HashPassword(command.Password);
            // create a new user (generate unique Id ) and add it to the database

            var user = new User
            {
                Name = command.Name,
                email = command.Email,
                password = h_password,
                Bio = "",
                CreatedDate = DateTime.UtcNow,

            };
            var validator = new ValidateCreateUserDto(_userRepository);
            var validationResult = await validator.ValidateAsync(user);

            if (validationResult.IsValid == true)
            {
                _userRepository.AddUser(user);


                var token = _jwtTokenGenerator.GenerateToken(user);
                var http = new HttpContextAccessor();
                var scheme = http.HttpContext?.Request.Scheme ?? "https";
                var host = http.HttpContext?.Request.Host.Value ?? "localhost:5293";

                await _emailSender.SendEmail(new Email()
                {
                    To = user.email,
                    Subject = "Social Media App Verification",
                    Body = $"Please verify your account by clicking the link below: <br/> <a href='{scheme}://{host}/api/Authentication/verify-email?token={token}'>Verify Email</a>"
                });

                return "Please verify your Email";
            }
            else
            {
                throw new ValidationException(validationResult);
            }
            
        }
    }
}
