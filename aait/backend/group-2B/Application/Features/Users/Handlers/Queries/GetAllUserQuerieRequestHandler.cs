using Application.Features.Users.Requests.Queries;
using AutoMapper;
using MediatR;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.Authentication;

namespace Application.Features.Users.Handlers.Queries;

public class GetAllUserQuerieRequestHandler : IRequestHandler<GetAllUserQuerieRequest, CommonResponse<List<UserDto>>>
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public GetAllUserQuerieRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<CommonResponse<List<UserDto>>> Handle(GetAllUserQuerieRequest request, CancellationToken cancellationToken)
    {
        CommonResponse<List<UserDto>> response ;

        response = CommonResponse<List<UserDto>>.Success(_mapper.Map<List<UserDto>>(await _unitOfWork.UserRepository.GetAsync()));

        return response;
    }


}
