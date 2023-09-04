using Application.Contracts.Persistance;
using Application.DTO.FollowDTO.Validator;
using Application.Exceptions;
using Application.Features.FollowFeatures.Request.Command;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FollowFeatures.Handlers.Command
{
    public class DeleteFollowCommandHandler : IRequestHandler<DeleteFollowCommand, BaseCommandResponse<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteFollowCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseCommandResponse<Unit>> Handle(DeleteFollowCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validation = new UnFollowDtoValidator(_unitOfWork.userRepository, _unitOfWork.followRepository);
                var validationResult = await validation.ValidateAsync(request.follow);
                if (!validationResult.IsValid) throw new ValidationException(validationResult);
                var unfollow = _mapper.Map<Follow>(request.follow);
                await _unitOfWork.followRepository.Unfollow(unfollow);
                int affectedRows = await _unitOfWork.Save();
                if (affectedRows == 0) throw new ServerErrorException("Something Went Wrong");

                return BaseCommandResponse<Unit>.SuccessHandler(Unit.Value); ;
            }catch(Exception ex)
            {
                return BaseCommandResponse<Unit>.FailureHandler(ex);
            }
        }
    }
}