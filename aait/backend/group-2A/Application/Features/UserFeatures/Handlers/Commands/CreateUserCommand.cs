using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistance;
using Application.DTO.Post.Validation;
using Application.DTO.UserDTO.Validator;
using Application.Exceptions;
using Application.Features.User.Request.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserFeatures.Handlers.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken){
            var validator = new CreateUserDTOValidator(_unitOfWork.userRepository);
            var validationResult = await validator.ValidateAsync(request.CreateUser);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }
            var user = _mapper.Map<Domain.Entities.User>(request.CreateUser);
            await _unitOfWork.userRepository.Add(user);
            await _unitOfWork.Save();
            return user.Id;
        }
    }
}
