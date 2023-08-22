using Domain.Entities;
using MediatR;

namespace Application.Features.Posts.Requests.Queries;

public class GetPostRequest : IRequest<Post>
{
    public int Id { get; set; }
}