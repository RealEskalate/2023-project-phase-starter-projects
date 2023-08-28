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
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UpdateCommentHandler(ICommentRepository commentRepository, IMapper mapper, IMediator mediator)
        {
            _commentRepository = commentRepository;
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
            var exists = await _commentRepository.Exists(request.Id);

            if (!exists) 
            {
                throw new NotFoundException("Comment is not found");
            }


            var newComment = _mapper.Map<Comment>(request.CommentData);
            newComment.Id = request.Id;
            newComment.UserId = request.userId;
            var updationResult = await _commentRepository.Update(newComment);
            var result = _mapper.Map<CommentResponseDTO>(updationResult);



            // notification
            var notificationData = new NotificationCreateDTO
            {
                Content = $"The Comment with id : {result.Id} is updated",
                NotificationType = "comment",
                UserId = request.userId
            };
            await _mediator.Send(new CreateNotification { NotificationData = notificationData });





            return new BaseResponse<CommentResponseDTO> {
                Success = true,
                Message = "The Comment is updated successfully",
                Value = result
            };






        }
    }
}
