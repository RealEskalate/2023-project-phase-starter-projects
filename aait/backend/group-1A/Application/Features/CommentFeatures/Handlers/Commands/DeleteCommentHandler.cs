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
    public class CommentDeleteHandler : IRequestHandler<CommentDeleteCommand, BaseResponse<string>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMediator _mediator;

        public CommentDeleteHandler(ICommentRepository commentRepository, IMediator mediator)
        {
            _commentRepository = commentRepository;
            _mediator = mediator;
        }

        public async Task<BaseResponse<string>> Handle(CommentDeleteCommand request, CancellationToken cancellationToken)
        {

            
             var comment = await _commentRepository.Get(request.Id);
            if (comment == null) 
            {
                throw new NotFoundException("Comment is not found");
            }
            
            var result = await _commentRepository.Delete(comment);

            // notification
            var notificationData = new NotificationCreateDTO
            {
                Content = $"The Comment with id : {comment.Id} is deleted",
                NotificationType = "comment",
                UserId = request.userId
            };
            await _mediator.Send(new CreateNotification { NotificationData = notificationData });


            return new BaseResponse<string> {
                Success = true,
                Message = "The Comment is deleted successfully"
            };

        }
    }
}
