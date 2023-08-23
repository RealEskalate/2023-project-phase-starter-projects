using Application.DTO.Post;
using MediatR;

namespace Application.Features.Post.Request.Queries;

public class GetByTagRequest : IRequest<List<PostDto>>
{
    public required string Tag{ set; get;}
}