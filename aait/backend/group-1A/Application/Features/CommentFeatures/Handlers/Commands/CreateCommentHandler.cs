using Application.Common;
using Application.Contracts;
using Application.DTO.CommentDTO.DTO;
using Application.DTO.CommentDTO.Validations;
using Application.DTO.NotificationDTO;
using Application.Exceptions;
using Application.Features.CommentFeatures.Requests.Commands;
using Application.Features.NotificationFeaure.Requests.Commands;
using Application.Response;
using AutoMapper;
using Domain.Entites;
using Domain.Entities;
using MediatR;


namespace Application.Features.CommentFeatures.Handlers.Commands
{
    public class CommentCreateHandler : IRequestHandler<CommentCreateCommand, BaseResponse<CommentResponseDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public CommentCreateHandler(IUnitOfWork unitOfWork,  IMapper mapper,IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<BaseResponse<CommentResponseDTO>> Handle(CommentCreateCommand request, CancellationToken cancellationToken)
        {
            

            var validator = new CommentCreateValidation();
            var validationResult = await validator.ValidateAsync(request.NewCommentData);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var post = await _unitOfWork.PostRepository.Get(request.NewCommentData.PostId);
            if (post == null)
            {
                throw new NotFoundException("Post with the Provided Id doesn't exist");
            }

            var newComment = _mapper.Map<Comment>(request.NewCommentData);
            newComment.UserId = request.userId;
            var result = await _unitOfWork.CommentRepository.Add(newComment);
            
            
            await _mediator.Send(new CreateNotification {
                NotificationData = new NotificationCreateDTO()
                    {
                    Content = $"User with Id {request.userId} commented on your post with Id {request.NewCommentData.PostId}",
                    NotificationContentId = result.Id,
                    NotificationType = NotificationEnum.COMMENT,
                    UserId = post.UserId
                    }
                }
            );

            await _unitOfWork.Save();
            return new BaseResponse<CommentResponseDTO> {
                Success = true,
                Message = "Comment is created successfully",
                Value =  _mapper.Map<CommentResponseDTO>(result)
            };



        }
    }
}
