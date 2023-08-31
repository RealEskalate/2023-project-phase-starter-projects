using Application.Features.Users.Requests.Queries;
using AutoMapper;
using MediatR;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.Authentication;

namespace Application.Features.Users.Handlers.Queries;

public class GetAllUsersQueryRequestHandler
    : IRequestHandler<GetAllUserQuerieRequest, CommonResponse<List<UserDto>>>
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public GetAllUsersQueryRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<CommonResponse<List<UserDto>>> Handle(
        GetAllUserQuerieRequest request,
        CancellationToken cancellationToken
    )
    {
        return CommonResponse<List<UserDto>>.Success(
            _mapper.Map<List<UserDto>>(await _unitOfWork.UserRepository.GetAsync())
        );
    }
}
