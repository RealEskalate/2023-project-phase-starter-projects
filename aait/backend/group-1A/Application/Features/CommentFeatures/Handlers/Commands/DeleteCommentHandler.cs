using Application.Common;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        public CommentDeleteHandler(IUnitOfWork unitOfWork,IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task<BaseResponse<int>> Handle(CommentDeleteCommand request, CancellationToken cancellationToken)
        {
   
             var comment = await _unitOfWork.CommentRepository.Get(request.Id);
            if (comment == null) 
            {
                throw new NotFoundException("Comment is not found");
            }
            
            var result = await _unitOfWork.CommentRepository.Delete(comment);
            var post = await _unitOfWork.PostRepository.Get(comment.PostId);


            await _mediator.Send(new CreateNotification {NotificationData = new NotificationCreateDTO()
                    {
                        Content = $"A comment on your post made by user with Id {request.userId} has been removed",
                        NotificationContentId = comment.Id,
                        NotificationType = NotificationEnum.COMMENT,
                        UserId = post.UserId
                        }});


            await _unitOfWork.Save();

            return new BaseResponse<int> {
                Success = true,
                Message = "The Comment is deleted successfully",
                Value = comment.Id
            };

        }
    }
}
