using Application.Contracts;
using Application.DTO.CommentDTO.DTO;
using Application.Exceptions;
using Application.Features.CommentFeatures.Requests.Queries;
using Application.Response;
using AutoMapper;
using MediatR;


namespace Application.Features.CommentFeatures.Handlers.Queries
{
    public class GetCommentQueryHandler : IRequestHandler<GetSingleCommentQuery, BaseResponse<CommentResponseDTO>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public GetCommentQueryHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<CommentResponseDTO>> Handle(GetSingleCommentQuery request, CancellationToken cancellationToken)
        {
            var result = await _commentRepository.Get(request.Id);
            if (result == null)
            {
                throw new BadRequestException("Comment is not found");
            }

            var comment = _mapper.Map<CommentResponseDTO>(result);
            comment.Like = result.CommentReactions.Where(x => x.Like == true).Count();
            comment.Dislike = result.CommentReactions.Where(x => x.Like == false).Count();
            
            return new BaseResponse<CommentResponseDTO>{
                Success = true,
                Message = "The Comment is retrieved successfully",
                Value = comment
            };
            
        }
    }
}
