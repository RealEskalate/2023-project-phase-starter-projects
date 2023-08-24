using Application.Contracts.Identity;
using Application.Contracts.Persistance;
using Application.DTO.UserDTO;
using Application.Features.User.Request.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.User.Handlers.Queries;

public class GetUserProfileHandler : IRequestHandler<GetUserProfile, UserProfileDTO>{
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public GetUserProfileHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper; 
        _unitOfWork = unitOfWork;
    }

    public async Task<UserProfileDTO> Handle(GetUserProfile request, CancellationToken cancellationToken){
        var user = await _unitOfWork.userRepository.Get(request.Id);
        if (user is null){
            throw new Exception("Not Found");
        }
        return _mapper.Map<UserProfileDTO>(user);
    }
}