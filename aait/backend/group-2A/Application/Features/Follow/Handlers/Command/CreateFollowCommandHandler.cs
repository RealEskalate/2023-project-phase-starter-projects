using Application.Contracts.Persistance;
using Application.Features.FollowFeatures.Request.Command;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO.FollowDTO.Validator;
using Application.Exceptions;
using Application.Responses;

namespace Application.Features.FollowFeatures.Handlers.Command
{
    public class CreateFollowCommandHandler : IRequestHandler<CreateFollowCommand, BaseCommandResponse<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateFollowCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseCommandResponse<Unit>> Handle(CreateFollowCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validation = new FollowDtoValidator(_unitOfWork.userRepository, _unitOfWork.followRepository);
                var validationResult = await validation.ValidateAsync(request.follow);
                if (!validationResult.IsValid) throw new ValidationException(validationResult);
            
                var notify = new Notification(){
                    UserId =  request.follow.FollowedId,
                    NotifierId = request.follow.FollowerId,
                    Message = "Started Following You" };
                var follow = _mapper.Map<Follow>(request.follow);
                await _unitOfWork.followRepository.Follow(follow);
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