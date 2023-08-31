using Application.Features.Users.Requests.Commands;
using MediatR;

using Application.DTOs.Users.Validators;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.Common.Responses;

namespace Application.Features.Users.Handlers.Commands;

public class UserUpdateCommandHandler
    : IRequestHandler<UserUpdateCommandRequest, CommonResponse<int>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly AutoMapper.IMapper _mapper;

    public UserUpdateCommandHandler(IUnitOfWork unitOfWork, AutoMapper.IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommonResponse<int>> Handle(
        UserUpdateCommandRequest request,
        CancellationToken cancellationToken
    )
    {
        var validator = new UserDtoValidator();
        var validationResult = await validator.ValidateAsync(request.Userdto);

        if (!validationResult.IsValid)
            return CommonResponse<int>.Failure("Unable to update user.");

        var user = await _unitOfWork.UserRepository.GetAsync(request.Userdto.Id);
        if (user == null)
            return CommonResponse<int>.Failure("Unable to update user.");

        _mapper.Map(request.Userdto, user);
        await _unitOfWork.UserRepository.UpdateAsync(user);
        var status = await _unitOfWork.SaveAsync();

        if (status < 0)
            return CommonResponse<int>.Failure("Unable to update user.");

        return new CommonResponse<int> { IsSuccess = true, Error = "" };
    }
}
