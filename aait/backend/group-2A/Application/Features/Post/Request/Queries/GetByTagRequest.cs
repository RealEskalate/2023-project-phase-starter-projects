using Application.DTO.Post;
using Application.Responses;
using MediatR;

namespace Application.Features.Post.Request.Queries;

public class GetByTagRequest : IRequest<BaseCommandResponse<List<PostDto>>>
{
    public required string Tag{ set; get;}
    public int PageNumber{ get; set; } = 0;
    public int PageSize{ get; set; } = 10;
}