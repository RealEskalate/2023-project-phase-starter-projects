

using Application.Contracts;
using Application.DTO.NotificationDTO;
using Application.DTO.PostDTO.DTO;
using Application.DTO.PostDTO.validations;
using Application.Exceptions;
using Application.Features.NotificationFeaure.Requests.Commands;
using Application.Exceptions;
using Application.Features.PostFeature.Requests.Commands;
using Application.Response;
using Application.Response;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.PostFeature.Handlers.Commands
{
    public class UpdatePostHandler : IRequestHandler<UpdatePostCommand, BaseResponse<BaseResponse<PostResponseDTO>>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public UpdatePostHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<BaseResponse<PostResponseDTO>>> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var validator = new PostUpdateValidation();
            var validationResult = await validator.ValidateAsync(request.PostUpdateData);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
                throw new ValidationException(validationResult);
            }
            var exists = await _postRepository.Exists(request.Id);

            if (!exists) 
            var exists = await _postRepository.Exists(request.Id);

            if (!exists) 
            {
<<<<<<< HEAD
                throw new NotFoundNotFoundException("Post is not found"
                "Post is not found");
                throw new NotFoundException("Post is not found");
>>>>>>> 144f3669 (feat(AAiT-backend-1A): updated comment feature)

            var newPost = _mapper.Map<Post>(request.PostUpdateData);
            newPost.Id = request.Id;
            newPost.UserId = request.userId;
            var updationResult = await _postRepository.Update(newPost);
            var result = _mapper.Map<PostResponseDTO>(updationResult);
            var result = _mapper.Map<PostResponseDTO>(updationResult);


            // notification
            // var notificationData = new NotificationCreateDTO
            // {
            //     Content = $"The Post with id {request.userId} is updated",
            //     NotificationContentId = result.Id,
            //     NotificationType = "post",
            //     UserId = request.userId,
            // };

            // await _mediator.Send(new CreateNotification { NotificationData = notificationData });

            return new BaseResponse<PostResponseDTO> {
                Success = true,
                Message = "The Post is updated successfully",
                Value = result
            };
        }
    }
}
