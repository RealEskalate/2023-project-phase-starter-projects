using Application.DTO.Post;
using Application.Responses;
using MediatR;

namespace Application.Features.Like.Request.Queries;

public class GetLikedPostRequest : IRequest<BaseCommandResponse<List<PostDto>>?>{
    public int Id{ get; set; }
    public int PageNumber{ get; set; } = 0;
    public int PageSize{ get; set; } = 10;
    
}