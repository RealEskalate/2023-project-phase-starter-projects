using Application.Features.Users.Requests.Commands;
using MediatR;

using Application.DTOs.Users.Validators;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.Common.Responses;

namespace Application.Features.Users.Handlers.Commands
{
    public class UserUpdateHandler : IRequestHandler<UserUpdateCommand, CommonResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AutoMapper.IMapper _mapper;

        public UserUpdateHandler(IUnitOfWork unitOfWork, AutoMapper.IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommonResponse<int>> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
        {
            var validator = new UserDtoVallidator();
            var validationResult = await validator.ValidateAsync(request.Userdto);

            if (!validationResult.IsValid)
            {

                var errorMessages = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

                return CommonResponse<int>.FailureWithError("update faild", errorMessages);
            }

            var user = await _unitOfWork.UserRepository.GetAsync(request.Userdto.Id);

        
            _mapper.Map(request.Userdto, user);
            await _unitOfWork.UserRepository.UpdateAsync(user);
            await _unitOfWork.SaveAsync();

            
            

            return CommonResponse<int>.Success(1);
        }
    }
}
