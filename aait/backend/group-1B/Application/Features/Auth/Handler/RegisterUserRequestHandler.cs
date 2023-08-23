using Application.Contracts.Auth;
using Application.DTOS.Auth.Validation;
using Application.Exceptions;
using Application.Features.Auth.Request;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Handler
{
    public class RegisterRequestHandler : IRequestHandler<RegisterUserRequest, int>
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public RegisterRequestHandler(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }



        public async Task<int> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
        {
            var validator = new RegisterRequestDtoValidator(_authService);

            var validationResult = await validator.ValidateAsync(request.registerRequest);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var user = _mapper.Map<User>(request.registerRequest);

            var createdUser = await _authService.Register(user, request.registerRequest.Password);



            return createdUser.Id;
        }



    }
}
