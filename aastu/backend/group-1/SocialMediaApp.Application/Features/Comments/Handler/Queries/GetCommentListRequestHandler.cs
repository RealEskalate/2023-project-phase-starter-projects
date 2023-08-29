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

namespace SocialMediaApp.Application.Features.Comments.Handler.Queries
{
    public class GetCommentListRequestHandler : IRequestHandler<GetCommentListRequest, List<CommentDto>>
    {
        private readonly ICommentRepository? _commentRepository;
        private readonly IMapper? _mapper;
        public GetCommentListRequestHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            this._commentRepository = commentRepository;
            this._mapper = mapper;
        }
        public async Task<List<CommentDto>> Handle(GetCommentListRequest request, CancellationToken cancellationToken)
        {
            var comments = await _commentRepository.GetCommentsByPostId(request.Id);
            return _mapper.Map<List<CommentDto>>(comments);

        }
    }
}
