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

namespace SocialMediaApp.Application.Authentication.Command.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResult>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        private readonly IUserRepository _userRepository;

        private readonly IPasswordService _passwordService;
        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository, IPasswordService passwordService)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
            _passwordService = passwordService;
        }

        public async Task<AuthenticationResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
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

            };
            var validator = new ValidateCreateUserDto(_userRepository);
            var validationResult = await validator.ValidateAsync(user);

            if (validationResult.IsValid == true)
            {
                _userRepository.AddUser(user);


                var token = _jwtTokenGenerator.GenerateToken(user);

                return new AuthenticationResult(
                    user,
                    token);
            }
            else
            {
                throw new ValidationException(validationResult);
            }
            
        }
    }
}
