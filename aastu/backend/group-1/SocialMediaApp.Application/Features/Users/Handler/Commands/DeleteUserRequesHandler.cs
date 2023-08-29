using AutoMapper;
using MediatR;
using SocialMediaApp.Application.Features.Users.Request.Commands;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Application.Exceptions;

namespace SocialMediaApp.Application.Features.Users.Handler.Commands
{
    public class DeleteUserRequestHandler: IRequestHandler<DeleteUserCommandRequest, Unit>
    {
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public DeleteUserRequestHandler(IUserRepository userRepository,    IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetById(request.Id);

        if(user == null){
            throw new NotFoundException(nameof(user), request.Id);
        }
        await _userRepository.Delete(user);
        return Unit.Value;
    }
    }
}