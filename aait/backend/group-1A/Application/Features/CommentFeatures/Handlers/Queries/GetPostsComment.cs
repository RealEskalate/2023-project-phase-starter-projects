using Application.Contracts;
using Application.DTO.CommentDTO.DTO;
using Application.Exceptions;
using Application.Features.CommentFeatures.Requests.Queries;
using Application.Response;
using AutoMapper;
using MediatR;

namespace Application.Features.CommentFeatures.Handlers.Queries
{
    public class GetPostsComment : IRequestHandler<GetCommentsForPostQuery, BaseResponse<List<CommentResponseDTO>>>
    {
        private readonly ICommentRepository _commentRepository;
            private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;

        public GetPostsComment(ICommentRepository commentRepository, IMapper mapper, IPostRepository postRepository)
            {
                _commentRepository = commentRepository;
                _mapper = mapper;
                _postRepository = postRepository;
        }

        public async Task<BaseResponse<List<CommentResponseDTO>>> Handle(GetCommentsForPostQuery request, CancellationToken cancellationToken)
        {
            var postExist = await _postRepository.Exists(request.PostId);
            if (!postExist) 
            {
                throw new NotFoundException("Post with the Provided Id is not found");
            }

            var result = await _commentRepository.GetByPostId(request.PostId);
            if (result == null)
            {
                throw new BadRequestException("Comments are not found");
            }


            var comments = _mapper.Map<List<CommentResponseDTO>>(result);
            return new BaseResponse<List<CommentResponseDTO>>{
                Success = true,
                Message = "The Comment is retrieved successfully",
                Value = comments
            };
        }
    }
}