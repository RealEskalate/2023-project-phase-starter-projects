using MediatR;
using SocialSync.Application.Responses;

namespace SocialSync.Application.Features.Posts.Requests.Commands;

public class RemovePostCommand: IRequest<BaseCommandResponse>{
  public int Id;
  public RemovePostCommand(int id)
  {
    Id = id;
  }
}
