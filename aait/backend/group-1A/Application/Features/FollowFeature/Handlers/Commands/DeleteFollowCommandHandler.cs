using Application.Common;
using Application.Contracts;
using Application.DTO.FollowDTo.Validations;
using Application.DTO.NotificationDTO;
using Application.Exceptions;
using Application.Features.FollowFeature.Requests.Commands;
using Application.Features.NotificationFeaure.Requests.Commands;
using Application.Response;
using AutoMapper;
using Domain.Entites;
using MediatR;

namespace Application.Features.FollowFeature.Handlers.Commands
{
     public class DeleteFollowCommandHandler : IRequestHandler<DeleteFollowCommand, BaseResponse<int>>
    {
      
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMediator _mediator;

        public DeleteFollowCommandHandler(IMediator mediator,IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }

        public async Task<BaseResponse<int>> Handle(DeleteFollowCommand request, CancellationToken cancellationToken)
        {   
            var followValidation = new FollowDTOValidation(_unitOfWork.UserRepository,_unitOfWork.FollowRepository);
            var followValidationResult = await followValidation.ValidateAsync(request.FollowDTO!);
            var createFollowResponse = new BaseResponse<int>();

            if (!followValidationResult.IsValid)
            {
                throw new ValidationException(followValidationResult);
            }

            var followEntity = _mapper.Map<Follow>(request.FollowDTO);
            await _unitOfWork.FollowRepository.DeleteFollow(followEntity);
            



            await _mediator.Send(new CreateNotification {NotificationData = new NotificationCreateDTO()
            {
                Content = $"The user with Id {request.FollowDTO.FollowerId} has currently un followed you",
                NotificationType = NotificationEnum.FOLLOW,
                UserId = request.FollowDTO.FolloweeId
            }});

            
            createFollowResponse.Success = true;
            createFollowResponse.Message = $"You have unfollowed the user with Id {request.FollowDTO.FolloweeId}";
            createFollowResponse.Value = followEntity.FolloweeId;
            return createFollowResponse;
        }
    }
}