
using Application.DTOs.Users.Validators;
using Application.Features.Users.Requests.Commands;
using MediatR;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.Contracts.Persistence;

namespace Application.Features.Users.Handlers.Commands
{
    public class UserDeleteHandler : IRequestHandler<UserDeleteCommand, CommonResponse<int>>
    {
    private readonly IUnitOfWork _unitOfWork;

        public UserDeleteHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<CommonResponse<int>> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeletUpdateValidator(_unitOfWork);
            var validateResult = await validator.ValidateAsync(request.UserdleteDto);

            if (!validateResult.IsValid){
            

                return CommonResponse<int>.Failure("Delate faild");
            }
            var user = await _unitOfWork.UserRepository.GetAsync(request.UserdleteDto.Id);
        
            await _unitOfWork.SaveAsync();
    
            return CommonResponse<int>.Success(1);
        }
    }
}
