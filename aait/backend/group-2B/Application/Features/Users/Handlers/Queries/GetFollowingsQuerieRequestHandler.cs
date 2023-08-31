using Application.Features.Users.Requests.Queries;
using AutoMapper;
using MediatR;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.Authentication;

namespace Application.Features.Users.Handlers.Queries;
public class GetFollowingsQuerieRequestHandler : IRequestHandler<GetFollowingsQuerieRequest, CommonResponse<List<UserDto>>>
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public GetFollowingsQuerieRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<CommonResponse<List<UserDto>>> Handle(GetFollowingsQuerieRequest request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.UserRepository.GetAsync(request.Id);

        return (CommonResponse<List<UserDto>>)user.Followings;

    }
}
