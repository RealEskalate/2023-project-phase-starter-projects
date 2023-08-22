using Application.DTOs.Posts;
using Domain.Entities;
using MediatR;

namespace Application.Features.Posts.Handlers.Commands;

public class UpdatePostRequest : IRequest<Post>
{
    public UpdatePostDto Post;
}