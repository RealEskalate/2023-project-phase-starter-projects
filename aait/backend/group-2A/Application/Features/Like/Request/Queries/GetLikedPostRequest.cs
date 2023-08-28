using Application.DTO.Post;
using MediatR;

namespace Application.Features.Like.Request.Queries;

public class GetLikedPostRequest : IRequest<List<PostDto>>{
    public int Id{ get; set; }
    
}