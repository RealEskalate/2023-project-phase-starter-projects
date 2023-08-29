using Application.Contracts;
using Application.DTO.Common;
using Application.DTO.UserDTO.DTO;
using Application.DTO.UserDTO.validations;
using Application.Features.UserFeature.Requests.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;
using SocialSync.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserFeature.Handlers.Commands
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UserResponseDTO>
    {
        private readonly IUserRepository _UserRepository;
        private readonly IMapper _mapper;

        public UpdateUserHandler(IUserRepository UserRepository, IMapper mapper)
        {
            _UserRepository = UserRepository;
            _mapper = mapper;
        }

        public async Task<UserResponseDTO> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new UserUpdateValidation();
            var validationResult = await validator.ValidateAsync(request.UserUpdateData!);

            if (!validationResult.IsValid)
            {
                throw new Exception();
            }
            if (request.userId <= 0)
            {
                throw new Exception();
            }
            var newUser = _mapper.Map<User>(request.UserUpdateData);
            newUser.Id = request.userId;
            var updationResult = await _UserRepository.Update(newUser);

            return _mapper.Map<UserResponseDTO>(updationResult);
        }
    }
}
