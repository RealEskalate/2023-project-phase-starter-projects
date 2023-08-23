using MediatR;
using SocialSync.Application.DTOs.PostDtos;

namespace SocialSync.Application.Features.Posts.Requests.Queries;

public class GetPostsByUserIdRequest: IRequest<List<GeneralPostDto>>{
    public int UserId;
    public GetPostsByUserIdRequest(int userId)
    {
        UserId = userId;   
    }
}