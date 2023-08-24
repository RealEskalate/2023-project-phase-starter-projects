using Application.Contracts;
using Application.DTO.CommentDTOS.DTO;
using Application.Features.CommentFeatures.Requests.Queries;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CommentFeatures.Handlers.Queries
{
    public class GetCommentsForPostQueryHandler : IRequestHandler<GetCommentsForPostQuery, List<CommentDTO>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public GetCommentsForPostQueryHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<List<CommentDTO>> Handle(GetCommentsForPostQuery request, CancellationToken cancellationToken)
        {
            var comments = await _commentRepository.GetCommentsForPostAsync(request.PostId); // Replace with actual repository method
            var commentDTOs = _mapper.Map<List<CommentDTO>>(comments); // Map to DTOs

            return commentDTOs;
        }
    }
}
