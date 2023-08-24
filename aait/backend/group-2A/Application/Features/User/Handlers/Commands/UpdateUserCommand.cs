using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistance;
using Application.DTO.UserDTO.Validator;
using Application.Exceptions;
using Application.Features.User.Request.Commands;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserFeatures.Handlers.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken){
            var response = new BaseCommandResponse();
            var validator = new UpdateUserDTOValidator(_unitOfWork.userRepository);
            var validationResult = await validator.ValidateAsync(request.updateUser);
            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "User update failed";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            
            var user = await _unitOfWork.userRepository.Get(request.updateUser.Id);
            _mapper.Map(request.updateUser, user);
            await _unitOfWork.userRepository.Update(user);
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "User Created Successfuly";

            return response;
        }
    }
}