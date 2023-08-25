

using Application.Contracts;
using Application.DTO.NotificationDTO;
using Application.DTO.PostDTO.DTO;
using Application.Exceptions;
using Application.Features.NotificationFeaure.Requests.Commands;
using Application.Features.PostFeature.Requests.Commands;
using Application.Response;
using MediatR;

namespace Application.Features.PostFeature.Handlers.Commands
{
    public class DeletePostHandler : IRequestHandler<DeletePostCommand, BaseResponse<PostResponseDTO>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMediator _mediator;
        public DeletePostHandler(IPostRepository postRepository, IMediator mediator)
        {
            _postRepository = postRepository;
            _mediator = mediator;
        }
        public async Task<BaseResponse<PostResponseDTO>> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.Get(request.Id, request.userId);
            if (post == null) 
            {
                throw new NotFoundException("Post is not found");
                
            }
            
            var result = await _postRepository.Delete(post);

            // notification
            var notificationData = new NotificationCreateDTO
            {
                Content = $"The post with id : {post.Id} is deleted",
                NotificationType = "post",
                UserId = request.userId,
            };

            await _mediator.Send(new CreateNotification {  NotificationData = notificationData });

            return  new BaseResponse<PostResponseDTO> {
                Success = true,
                Message = "The post is deleted successfully"
            };
        }
    }
}
