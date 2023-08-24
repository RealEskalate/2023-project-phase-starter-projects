using Application.DTO.CommentDTOS.DTO;
using MediatR;

namespace Application.Features.CommentFeatures.Requests.Queries
{
    public class GetAllCommentsQuery : IRequest<List<CommentDTO>>
    {
    }
}
