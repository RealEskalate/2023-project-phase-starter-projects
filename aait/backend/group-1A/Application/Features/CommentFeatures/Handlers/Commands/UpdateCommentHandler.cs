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
using Domain.Entities;
using MediatR;


namespace Application.Features.CommentFeatures.Handlers.Commands
{
    public class UpdateCommentHandler : IRequestHandler<UpdateCommentCommand, BaseResponse<CommentResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UpdateCommentHandler(IUnitOfWork unitOfWork, IMapper mapper,IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task<BaseResponse<CommentResponseDTO>> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            
            var validator = new CommentUpdateValidation();
            var validationResult = await validator.ValidateAsync(request.CommentData);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }
            var comment = await _unitOfWork.CommentRepository.Get(request.Id);

            if (comment == null) 
            {
                throw new NotFoundException("Comment is not found");
            }


            _mapper.Map(request.CommentData, comment);
            
            var updationResult = await _unitOfWork.CommentRepository.Update(comment);
            var result = _mapper.Map<CommentResponseDTO>(updationResult);
            var post  = await _unitOfWork.PostRepository.Get(comment.PostId);

            await _mediator.Send(new CreateNotification {NotificationData = new NotificationCreateDTO()
            {
                Content = $"A comment on your post made by user with id {request.userId} has been Updated",
                NotificationContentId = comment.Id,
                NotificationType = NotificationEnum.COMMENT,
                UserId = post.UserId}
                }
                );

                
            await _unitOfWork.Save();



            return new BaseResponse<CommentResponseDTO> {
                Success = true,
                Message = "The Comment is updated successfully",
                Value = result
            };






        }
    }
}
