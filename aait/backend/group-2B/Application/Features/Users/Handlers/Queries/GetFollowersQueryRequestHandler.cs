using Application.Features.Users.Requests.Queries;
using AutoMapper;
using MediatR;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.Authentication;

namespace Application.Features.Users.Handlers.Queries;

public class GetFollowersQueryRequestHandler
    : IRequestHandler<GetFollowersQuerieRequest, CommonResponse<List<UserDto>>>
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public GetFollowersQueryRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<CommonResponse<List<UserDto>>> Handle(
        GetFollowersQuerieRequest request,
        CancellationToken cancellationToken
    )
    {
        var user = await _unitOfWork.UserRepository.GetAsync(request.Id);
        if (user == null)
            return CommonResponse<List<UserDto>>.Failure("User not found");

        return CommonResponse<List<UserDto>>.Success(_mapper.Map<List<UserDto>>(user.Followers));
    }
}
