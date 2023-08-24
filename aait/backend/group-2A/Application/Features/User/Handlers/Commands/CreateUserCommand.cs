using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistance;
using Application.DTO.Post.Validation;
using Application.DTO.UserDTO.Validator;
using Application.Exceptions;
using Application.Features.User.Request.Commands;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserFeatures.Handlers.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken){
            var response = new BaseCommandResponse();
            var validator = new CreateUserDTOValidator(_unitOfWork.userRepository);
            var validationResult = await validator.ValidateAsync(request.CreateUser);
            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "User Create Faild";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            var user = _mapper.Map<Domain.Entities.User>(request.CreateUser);
            await _unitOfWork.userRepository.Add(user);
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "User Created Successfuly";
            response.Id = user.Id;

            return response;
        }
    }
}
