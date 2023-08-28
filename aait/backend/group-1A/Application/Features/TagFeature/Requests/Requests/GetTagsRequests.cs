
using MediatR;
using SocialSync.Application.DTO;
using SocialSync.Domain.Entities;

namespace SocialSync.Application.Features.Requests;
public class GetAllTagsRequest : IRequest<IEnumerable<TagResponseDto>>
{
}