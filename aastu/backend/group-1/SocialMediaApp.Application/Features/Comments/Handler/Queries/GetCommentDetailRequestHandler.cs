using AutoMapper;
using MediatR;
using SocialMediaApp.Application.DTOs.Comments;
using SocialMediaApp.Application.Features.Comments.Request.Queries;
using SocialMediaApp.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Features.Comments.Handler.Queries;

public class GetCommentDetailRequestHandler : IRequestHandler<GetCommentDetailRequest, CommentDto>
{
    private readonly ICommentRepository? _commentRepository;
    private readonly IMapper? _mapper;
    public GetCommentDetailRequestHandler(ICommentRepository commentRepository, IMapper mapper)
    {
        this._commentRepository = commentRepository;
        this._mapper = mapper;
    }
    public async Task<CommentDto> Handle(GetCommentDetailRequest request, CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.GetCommentById(request.Id);

        return _mapper.Map<CommentDto>(comment);
    }
}
