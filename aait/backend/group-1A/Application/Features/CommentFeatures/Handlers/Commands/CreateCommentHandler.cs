using Application.Contracts;
using Application.DTO.CommentDTO.DTO;
using Application.DTO.CommentDTO.Validations;
using Application.DTO.NotificationDTO;
using Application.Exceptions;
using Application.Features.CommentFeatures.Requests.Commands;
using Application.Features.NotificationFeaure.Requests.Commands;
using Application.Response;
using AutoMapper;
using Domain.Entities;
using MediatR;


namespace Application.Features.CommentFeatures.Handlers.Commands
{
    public class CommentCreateHandler : IRequestHandler<CommentCreateCommand, BaseResponse<CommentResponseDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;

        private readonly IMediator _mediator;
        private readonly IPostRepository _postRepository;

        public CommentCreateHandler(IMapper mapper, ICommentRepository commentRepository, IMediator mediator, IPostRepository postRepository)
        {
            _mapper = mapper;
            _commentRepository = commentRepository;
            _mediator = mediator;
            _postRepository = postRepository;
        }

        public async Task<BaseResponse<CommentResponseDTO>> Handle(CommentCreateCommand request, CancellationToken cancellationToken)
        {
            

            var validator = new CommentCreateValidation();
            var validationResult = await validator.ValidateAsync(request.NewCommentData);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var postExist = await _postRepository.Exists(request.NewCommentData.PostId);
            if (!postExist)
            {
                throw new NotFoundException("Post with the Provided Id doesn't exist");
            }

            var newComment = _mapper.Map<Comment>(request.NewCommentData);
            newComment.UserId = request.userId;
            var result = await _commentRepository.Add(newComment);

            // notification
            var notificationData = new NotificationCreateDTO
            {
                Content = $"New Comment is Created by user with id : {request.userId}",
                NotificationContentId = result.Id,
                NotificationType = "comment",
                UserId = request.userId

            };
            
            await _mediator.Send(new CreateNotification { NotificationData = notificationData });

            return new BaseResponse<CommentResponseDTO> {
                Success = true,
                Message = "Comment is created successfully",
                Value =  _mapper.Map<CommentResponseDTO>(result)
            };



        }
    }
}
