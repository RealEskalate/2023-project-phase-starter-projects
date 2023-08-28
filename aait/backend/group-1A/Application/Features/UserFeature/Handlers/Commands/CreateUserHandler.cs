using Application.Common;
using Application.Contracts;
using Application.DTO.Common;
using Application.DTO.UserDTO.DTO;
using Application.DTO.UserDTO.validations;
using Application.Features.UserFeature.Requests.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;
using SocialSync.Domain.Entities;

namespace Application.Features.UserFeature.Handlers.Commands
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, CommonResponseDTO>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _UserRepository;

        public CreateUserHandler(IMapper mapper, IUserRepository UserRepository)
        {
            _mapper = mapper;
            _UserRepository = UserRepository;
        }
        public async Task<CommonResponseDTO> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new UserCreateValidation(_UserRepository);
            var validationResult = await validator.ValidateAsync(request.NewUserData!);

            var createResponse = new CommonResponseDTO();
            if (!validationResult.IsValid)
            {
                createResponse.Status = "Failure";
                createResponse.Message = "Unable to create user";
                return createResponse;
            }


            var newUser = _mapper.Map<User>(request.NewUserData);
            var result = await _UserRepository.Add(newUser);
            
            createResponse.Status = "Success";
            createResponse.Message = "Successfully Created User";

            return createResponse;
            
        }
    }
}
