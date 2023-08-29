using Application.Contracts;
using Application.DTO.UserDTO.validations;
using Application.Exceptions;
using Application.Features.UserFeature.Requests.Commands;
using Application.Response;
using AutoMapper;
using MediatR;
using SocialSync.Domain.Entities;

namespace Application.Features.UserFeature.Handlers.Commands
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, BaseResponse<string>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _UserRepository;

        public CreateUserHandler(IMapper mapper, IUserRepository UserRepository)
        {
            _mapper = mapper;
            _UserRepository = UserRepository;
        }
        public async Task<BaseResponse<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new UserCreateValidation(_UserRepository);
            var validationResult = await validator.ValidateAsync(request.NewUserData!);

            var createResponse = new BaseResponse<string>();
            if (!validationResult.IsValid)
            {
                throw new BadRequestException("Unable to create a user");
            }


            var newUser = _mapper.Map<User>(request.NewUserData);
            var result = await _UserRepository.Add(newUser);
            
            createResponse.Success = true;
            createResponse.Message = "User created successfully";
            
            return createResponse;
            
        }
    }
}
