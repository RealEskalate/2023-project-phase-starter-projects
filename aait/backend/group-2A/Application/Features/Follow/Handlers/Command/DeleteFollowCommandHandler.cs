using Application.Contracts.Persistance;
using Application.DTO.FollowDTO.Validator;
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
    public class DeleteFollowCommandHandler : IRequestHandler<DeleteFollowCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteFollowCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseCommandResponse> Handle(DeleteFollowCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validation = new FollowDtoValidator(_unitOfWork.userRepository);
            var validationResult = await validation.ValidateAsync(request.follow);
            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Unfollowing Faild";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            var unfollow = _mapper.Map<Follow>(request.follow);
            await _unitOfWork.followRepository.Unfollow(unfollow);
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Successfuly unfollowed";

            return response;
        }
    }
}