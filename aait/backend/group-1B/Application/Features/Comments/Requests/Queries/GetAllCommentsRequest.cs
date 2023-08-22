using Application.DTOs.Comments;
using Domain.Entities;
using MediatR;

namespace Application.Features.Comments.Requests.Queries;

public class GetAllCommentsRequest : IRequest<List<CommentContentDto>>
{
    
}