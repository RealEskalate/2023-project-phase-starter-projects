using Application.Response;
using MediatR;


namespace Application.Features.UserFeature.Requests.Commands
{
    public class DeleteUserCommand : IRequest<BaseResponse<string>>
    {
         public int userId { get; set; }
    }
}
