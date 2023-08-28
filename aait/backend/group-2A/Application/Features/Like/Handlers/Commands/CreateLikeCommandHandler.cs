
using MediatR;
using Application.Contracts.Persistance;
using Application.DTO.Like.Validator;
using Application.Exceptions;
using AutoMapper;
using Application.Responses;
using Domain.Entities;

namespace Application.Features.Like.Handlers.Commands
{
    public class CreateLikeCommandHandler : IRequestHandler<CreateLikeCommand, BaseCommandResponse<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateLikeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse<Unit>> Handle(CreateLikeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validator = new LikedDtoValidator(_unitOfWork.userRepository, _unitOfWork.postRepository);
                var validationResult = await validator.ValidateAsync(request.like);
                if (!validationResult.IsValid) throw new ValidationException(validationResult);
                
                var PostDetail = await _unitOfWork.postRepository.Get(request.like.PostId);
            
                var notify = new Notification(){
                    UserId =  PostDetail.UserId,
                    NotifierId = request.like.UserId,
                    Message = "Liked On your post" };

                await _unitOfWork.likeRepository.LikePost(_mapper.Map<Domain.Entities.Like>(request.like));
                await _unitOfWork.notificationRepository.AddNotification(notify);
                int affectedRows = await _unitOfWork.Save();
                if (affectedRows == 0) throw new ServerErrorException("Something Went Wrong");

                return BaseCommandResponse<Unit>.SuccessHandler(Unit.Value); ;
            }catch (Exception ex)
            {
                return BaseCommandResponse<Unit>.FailureHandler(ex);
            }
        }
    }
}