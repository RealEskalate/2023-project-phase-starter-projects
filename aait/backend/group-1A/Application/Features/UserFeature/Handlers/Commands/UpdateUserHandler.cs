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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateUserHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task<UserResponseDTO> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            
            if (request.userId <= 0)
            {
                throw new BadRequestException("USER with this Id doesnt exist");
            }
            var user = await  _unitOfWork.UserRepository.Get(request.userId);
            if (user == null)
            {
                throw new NotFoundException("User is not found");
            }
            

            var updationResult = await _unitOfWork.UserRepository.UpdateUser(request.UserUpdateData!,request.userId);

            return _mapper.Map<UserResponseDTO>(updationResult);
        }
    }
}
