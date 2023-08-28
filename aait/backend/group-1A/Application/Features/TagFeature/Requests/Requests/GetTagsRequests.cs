
using Application.Response;
using MediatR;
using SocialSync.Application.DTO;
using SocialSync.Domain.Entities;

namespace SocialSync.Application.Features.Requests;
public class GetAllTagsRequest : IRequest<BaseResponse<List<TagResponseDto>>>
{
    public int userId { get; set; }
}