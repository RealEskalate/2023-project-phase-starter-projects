using Application.Contracts;
using Application.DTO.Common;
using Application.DTO.UserDTO.DTO;
using Application.DTO.UserDTO.validations;
using Application.Exceptions;
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
        // private readonly IUserRepository _UserRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateUserHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            // _serRepository = UserRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserResponseDTO> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new UserUpdateValidation();
            var validationResult = await validator.ValidateAsync(request.UserUpdateData!);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }
            if (request.userId <= 0)
            {
                throw new BadRequestException("USER with this Id doesnt exist");
            }
            var user = await  _unitOfWork.UserRepository.Get(request.userId);
            if (user == null)
            {
                throw new NotFoundException("User is not found");
            }

            var newUser = _mapper.Map(request.UserUpdateData,user);
            //newUser.Id = request.userId;
            var updationResult = await _unitOfWork.UserRepository.Update(user);

            return _mapper.Map<UserResponseDTO>(updationResult);
        }
    }
}
