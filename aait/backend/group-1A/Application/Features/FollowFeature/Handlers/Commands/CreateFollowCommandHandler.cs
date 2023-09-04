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
    public class CreateFollowCommandHandler : IRequestHandler<CreateFollowCommand, BaseResponse<int>>
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public CreateFollowCommandHandler(IMapper mapper, IUnitOfWork unitOfWork,IMediator mediator)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task<BaseResponse<int>> Handle(CreateFollowCommand request, CancellationToken cancellationToken)
        {   

            var followValidation = new FollowDTOValidation(_unitOfWork.UserRepository,_unitOfWork.FollowRepository);
            var followValidationResult = await followValidation.ValidateAsync(request.FollowDTO!);
            var createFollowResponse = new BaseResponse<int>();
            
            if (!followValidationResult.IsValid)
            {
                throw new ValidationException(followValidationResult);
            }

            if (await _unitOfWork.FollowRepository.Get(request.FollowDTO) != null)  
            {
                throw new BadRequestException("You already follow this user");   
            }

            var followEntity = _mapper.Map<Follow>(request.FollowDTO);
            var createFollowCommandResult = await _unitOfWork.FollowRepository.AddFollow(followEntity);
            
            
            await _mediator.Send(new CreateNotification {NotificationData = new NotificationCreateDTO()
            {
                Content = $"The user with Id {request.FollowDTO.FollowerId} is currently following you",
                NotificationType = NotificationEnum.FOLLOW,
                UserId = request.FollowDTO.FolloweeId}});
            
            
            createFollowResponse.Success = true;
            createFollowResponse.Message = "Followed successfully";
            createFollowResponse.Value = createFollowCommandResult.FollowerId;
            
            
            return createFollowResponse;
        }
    }
}