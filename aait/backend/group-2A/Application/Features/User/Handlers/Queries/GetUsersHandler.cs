using Application.Contracts.Identity;
using Application.Contracts.Persistance;
using Application.DTO.UserDTO;
using Application.Features.User.Request.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.User.Handlers.Queries;

public class GetUsersHandler : IRequestHandler<GetUsers, List<UserDto>>{
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public GetUsersHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper; 
        _unitOfWork = unitOfWork;
    }

    public async Task<List<UserDto>> Handle(GetUsers request, CancellationToken cancellationToken){
        var user = await _unitOfWork.userRepository.GetAll();
        return _mapper.Map<List<UserDto>>(user);
    }
}