using Application.DTOs.Posts;
using Domain.Entities;
using MediatR;
using SocialSync.Application.Responses;

namespace Application.Features.Posts.Requests.Commands;

public class CreatePostRequest : IRequest<BaseCommandResponse>
{
    public CreatePostDto Post { get; set; }
}