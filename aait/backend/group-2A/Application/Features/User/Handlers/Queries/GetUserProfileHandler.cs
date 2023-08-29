using Application.Contracts.Identity;
using Application.Contracts.Persistance;
using Application.DTO.UserDTO;
using Application.Exceptions;
using Application.Features.User.Request.Queries;
using Application.Responses;
using AutoMapper;
using MediatR;

namespace Application.Features.User.Handlers.Queries;

public class GetUserProfileHandler : IRequestHandler<GetUserProfile, BaseCommandResponse<UserProfileDTO>>{
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public GetUserProfileHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper; 
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseCommandResponse<UserProfileDTO>> Handle(GetUserProfile request, CancellationToken cancellationToken){
        try{
            var user = await _unitOfWork.userRepository.Get(request.Id);
            if (user is null){
                throw new NotFoundException(nameof(user), request.Id);
            }
            return BaseCommandResponse<UserProfileDTO>.SuccessHandler(_mapper.Map<UserProfileDTO>(user));
        }
        catch(Exception ex){
            return BaseCommandResponse<UserProfileDTO>.FailureHandler(ex);
        }
    }
}