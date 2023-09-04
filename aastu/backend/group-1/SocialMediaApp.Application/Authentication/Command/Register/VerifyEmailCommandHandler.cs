using AutoMapper;
using MediatR;
using SocialMediaApp.Application.Authentication.Common;
using SocialMediaApp.Application.DTOs.Users;
using SocialMediaApp.Application.Persistence.Contracts.Common;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Domain;
using Microsoft.Office.Interop.Excel;
using SocialMediaApp.Application.Persistence.Contracts.Infrastructure;

namespace SocialMediaApp.Application.Authentication.Command.Register
{
    public class VerifyEmailCommandHandler : IRequestHandler<VerifyEmailCommand, AuthenticationResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenValidation _jwtTokenValidation;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IMapper _mapper;

        public VerifyEmailCommandHandler(IUserRepository userRepository, IJwtTokenValidation jwtTokenValidation, IJwtTokenGenerator jwtTokenGenerator, IMapper mapper)
        {
            _userRepository = userRepository;
            _jwtTokenValidation = jwtTokenValidation;
            _jwtTokenGenerator = jwtTokenGenerator;
            _mapper = mapper;
        }
        public async Task<AuthenticationResult> Handle(VerifyEmailCommand request, CancellationToken cancellationToken)
        {
  

            Guid UserId = _jwtTokenValidation.ExtractUserIdFromToken(request.Token);

            if (UserId == Guid.Empty)
            {
                throw new Exception("User Id not Found");
            }

            User user = await _userRepository.GetById(UserId);
            if (user == null)
            {
               // return Errors.Auth.InvalidToken;
               throw new Exception();
            }

            if (user.IsVerified)
            {
                //return Errors.Auth.EmailAlreadyConfirmed;
                throw new Exception("Email Already Confirmed");
            }

            user.IsVerified = true;
            User usr = _userRepository.EditUser(user);
            if (usr == null)
            {
                //return Errors.Auth.EmailNotConfirmed;
                throw new Exception( "Email Not Found");
            }


            var Token = _jwtTokenGenerator.GenerateToken(usr);
            var res = new AuthenticationResult(_mapper.Map<User>(user), Token);

            // return res;

            return res;
        }

    }
}