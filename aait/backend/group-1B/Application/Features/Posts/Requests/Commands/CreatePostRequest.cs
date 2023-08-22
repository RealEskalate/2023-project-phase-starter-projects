using Application.DTOs.Posts;
using Domain.Entities;
using MediatR;

namespace Application.Features.Posts.Requests.Commands;

public class CreatePostRequest : IRequest<Post>
{
    public CreatePostDto Post { get; set; }
}