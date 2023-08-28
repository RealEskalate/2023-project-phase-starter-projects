using Application.Features.Users.Requests.Commands;
using MediatR;

using Application.DTOs.Users.Validators;
using SocialSync.Application.Contracts.Persistence;

namespace Application.Features.Users.Handlers.Commands
{
    public class UserUpdateHandler : IRequestHandler<UserUpdateCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AutoMapper.IMapper _mapper;

        public UserUpdateHandler(IUnitOfWork unitOfWork, AutoMapper.IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
        {
            var validator = new UserDtoVallidator();
            var validationResult = await validator.ValidateAsync(request.Userdto);

            if (!validationResult.IsValid)
            {
                
                throw new Exception("Validation failed.");
            }

            var user = await _unitOfWork.UserRepository.GetAsync(request.Userdto.Id);

            if (user != null)
            {
                _mapper.Map(request.Userdto, user);
                await _unitOfWork.UserRepository.UpdateAsync(user);
                await _unitOfWork.SaveAsync();
            }

            return Unit.Value;
        }
    }
}
