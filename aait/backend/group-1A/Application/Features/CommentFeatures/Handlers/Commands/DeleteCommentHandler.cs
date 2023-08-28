using Application.Contracts;
using Application.DTO.CommentDTO.DTO;
using Application.DTO.NotificationDTO;
using Application.Exceptions;
using Application.Features.CommentFeatures.Requests.Commands;
using Application.Features.NotificationFeaure.Requests.Commands;
using Application.Response;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CommentFeatures.Handlers.Commands
{
    public class CommentDeleteHandler : IRequestHandler<CommentDeleteCommand, BaseResponse<int>>
    {
        private readonly ICommentRepository _commentRepository;

        public CommentDeleteHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<BaseResponse<int>> Handle(CommentDeleteCommand request, CancellationToken cancellationToken)
        {

            
             var comment = await _commentRepository.Get(request.Id);
            if (comment == null) 
            {
                throw new NotFoundException("Comment is not found");
            }
            
            var result = await _commentRepository.Delete(comment);


            return new BaseResponse<int> {
                Success = true,
                Message = "The Comment is deleted successfully",
                Value = comment.Id
            };

        }
    }
}
