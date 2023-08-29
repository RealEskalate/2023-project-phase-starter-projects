using Application.DTO.CommentDTO.DTO;
using Application.Response;
using MediatR;

namespace Application.Features.CommentFeatures.Requests.Commands
{
    public class CommentDeleteCommand : IRequest<BaseResponse<string>>
    {
        public int Id { get; set; }
        public int userId { get; set; }
    }
}
