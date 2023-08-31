using Application.Contracts.Persistance;
using Application.DTO.UserDTO;
using Application.Exceptions;
using Application.Features.User.Request;
using Application.Responses;
using AutoMapper;
using MediatR;

namespace Application.Features.User.Handlers.Queries;

public class SearchUsersHandler : IRequestHandler<SearchUsers, BaseCommandResponse<List<UserDto>>>{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SearchUsersHandler(IUnitOfWork unitOfWork, IMapper mapper){
        _unitOfWork = unitOfWork;
        _mapper = mapper;

    }

    public async Task<BaseCommandResponse<List<UserDto>>> Handle(SearchUsers request, CancellationToken cancellationToken){
        try{
            var users = await _unitOfWork.userRepository.Search(request.Query, request.PageNumber,
                request.PageSize);
            if (users == null) throw new NotFoundException(nameof(List<Domain.Entities.User>), "Users Not found");
            return BaseCommandResponse<List<UserDto>>.SuccessHandler(_mapper.Map<List<UserDto>>(users));
        }
        catch(Exception ex){
            return BaseCommandResponse<List<UserDto>>.FailureHandler(ex);
        }
    }
}