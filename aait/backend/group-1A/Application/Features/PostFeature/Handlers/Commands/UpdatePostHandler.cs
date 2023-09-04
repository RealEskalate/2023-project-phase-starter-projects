

using Application.Common;
using Application.Contracts;
using Application.DTO.NotificationDTO;
using Application.DTO.PostDTO.DTO;
using Application.DTO.PostDTO.validations;
using Application.Exceptions;
using Application.Features.NotificationFeaure.Requests.Commands;
using Application.Features.PostFeature.Requests.Commands;
using Application.Response;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.PostFeature.Handlers.Commands
{
    public class UpdatePostHandler : IRequestHandler<UpdatePostCommand, BaseResponse<PostResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public UpdatePostHandler(IUnitOfWork unitOfWork, IMapper mapper,IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<BaseResponse<PostResponseDTO>> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var validator = new PostUpdateValidation();
            var validationResult = await validator.ValidateAsync(request.PostUpdateData);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }
            var post = await _unitOfWork.PostRepository.Get(request.Id);


            if (post == null) 
            {
                throw new NotFoundException("Post is not found");
            }

            _mapper.Map(request.PostUpdateData, post);
            var updationResult = await _unitOfWork.PostRepository.Update(post);
            var result = _mapper.Map<PostResponseDTO>(updationResult);


            await _mediator.Send(new CreateNotification {NotificationData = new NotificationCreateDTO()
            {
                Content = "A Post has been Updated",
                NotificationContentId = result.Id,
                NotificationType = NotificationEnum.POST,
                UserId = request.userId}});

                
            return new BaseResponse<PostResponseDTO> {
                Success = true,
                Message = "The Post is updated successfully",
                Value = result
            };
        }
    }
}
