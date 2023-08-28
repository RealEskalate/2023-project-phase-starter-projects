
using Application.DTOs.Users.Validators;
using Application.Features.Users.Requests.Commands;
using MediatR;
using SocialSync.Application.Contracts.Persistence;

namespace Application.Features.Users.Handlers.Commands
{
    public class UserDeleteHandler : IRequestHandler<UserDeleteCommand, Unit>
    {
    private readonly IUnitOfWork _unitOfWork;

        public UserDeleteHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<Unit> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeletUpdateValidator(_unitOfWork);
            var validateResult = await validator.ValidateAsync(request.UserdleteDto);
            var user = await _unitOfWork.UserRepository.GetAsync(request.UserdleteDto.Id);
        
            await _unitOfWork.SaveAsync();
    
            return Unit.Value;
        }
    }
}
