using Application.Features.Users.Requests.Queries;
using AutoMapper;
using MediatR;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.Authentication;

namespace Application.Features.Users.Handlers.Queries;

public class GetUserQuerieRequestHandler:IRequestHandler<GetUserQuerieRequest,CommonResponse<UserDto>>
{

    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public GetUserQuerieRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }


    public async Task<CommonResponse<UserDto>> Handle(GetUserQuerieRequest request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.UserRepository.GetAsync(request.Id);
        var response = CommonResponse<UserDto>.Success(_mapper.Map<UserDto>(user));
        return response;
    }
}
