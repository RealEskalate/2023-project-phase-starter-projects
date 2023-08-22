using Application.DTO.Post;
using MediatR;

namespace Application.Features.Post.Request.Queries;

public class GetByContenetRequest : IRequest<List<PostDto>>
{
    public string Contenet{ get; set; }
}