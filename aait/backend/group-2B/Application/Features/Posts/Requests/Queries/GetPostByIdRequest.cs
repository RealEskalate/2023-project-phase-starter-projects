using MediatR;
using SocialSync.Application.DTOs.PostDtos;

namespace SocialSync.Application.Features.Posts.Requests.Queries;

public class GetPostByIdRequest : IRequest<GeneralPostDto>
{
    public int Id;
    public GetPostByIdRequest(int id)
    {
        Id = id;
    }
}