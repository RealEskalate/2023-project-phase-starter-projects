using MediatR;

namespace SocialSync.Application.Features.Posts.Requests.Commands;

public class RemovePostCommand: IRequest<Unit>{
  public int Id;
  public RemovePostCommand(int id)
  {
    Id = id;
  }
}
