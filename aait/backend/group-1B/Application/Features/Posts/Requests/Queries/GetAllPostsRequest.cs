using Application.DTOs.Posts;
using MediatR;

namespace Application.Features.Posts.Requests.Queries;

public class GetAllPostsRequest : IRequest<List<PostContentDto>>
{
    
}