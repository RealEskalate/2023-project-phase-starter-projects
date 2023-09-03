using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;
using Application.DTO.UserDTO.DTO;
using Application.DTO.UserDTO.validations;
using Application.Exceptions;
using Application.Features.UserFeature.Requests.Commands;
using Application.Response;
using AutoMapper;
using MediatR;

namespace Application.Features.UserFeature.Handlers.Commands
{
    public class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommand, BaseResponse<UpdatePasswordDTO>>
    {
         private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePasswordCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<UpdatePasswordDTO>> Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdatePasswordValidation(request.UpdatePasswordDTO!,_unitOfWork.UserRepository,request.UserId);
            var validationResult = await validator.ValidateAsync(request.UpdatePasswordDTO);
            var updatePasswordResponse = new BaseResponse<UpdatePasswordDTO>();
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }
            if (request.UserId <= 0)
            {
                throw new BadRequestException("USER with this Id doesnt exist");
            }
            var user = await  _unitOfWork.UserRepository.Get(request.UserId);
            if (user == null)
            {
                throw new NotFoundException("User is not found");
            }

            await _unitOfWork.UserRepository.UpdatePassword(request.UpdatePasswordDTO,request.UserId);
            updatePasswordResponse.Success = true;
            updatePasswordResponse.Message = "Successfully Updated Password";

            return updatePasswordResponse;
        }
    }
}