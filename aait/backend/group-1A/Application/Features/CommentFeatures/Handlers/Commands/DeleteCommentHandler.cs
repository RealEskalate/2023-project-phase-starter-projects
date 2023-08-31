using Application.Contracts;
using Application.DTO.CommentDTO.DTO;
using Application.DTO.NotificationDTO;
using Application.Exceptions;
using Application.Features.CommentFeatures.Requests.Commands;
using Application.Features.NotificationFeaure.Requests.Commands;
using Application.Response;
using Domain.Entites;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CommentFeatures.Handlers.Commands
{
    public class CommentDeleteHandler : IRequestHandler<CommentDeleteCommand, BaseResponse<int>>
    {
        // private readonly ICommentRepository _commentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CommentDeleteHandler(IUnitOfWork unitOfWork)
        {
            // _commentRepository = commentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<int>> Handle(CommentDeleteCommand request, CancellationToken cancellationToken)
        {
   
             var comment = await _unitOfWork.CommentRepository.Get(request.Id);
            if (comment == null) 
            {
                throw new NotFoundException("Comment is not found");
            }
            
            var result = await _unitOfWork.CommentRepository.Delete(comment);
            await _unitOfWork.Save();
            // notification
        //    var notification =  new Notification()
        //                 {
        //                     Content = "Comment is deleted",
        //                     NotificationContentId = request.Id,
        //                     UserId = post.UserId,
        //                     Comment = true
        //                 };

            return new BaseResponse<int> {
                Success = true,
                Message = "The Comment is deleted successfully",
                Value = comment.Id
            };

        }
    }
}
