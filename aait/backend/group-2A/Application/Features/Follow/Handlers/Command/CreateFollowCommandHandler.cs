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
    public class CreateFollowCommandHandler : IRequestHandler<CreateFollowCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateFollowCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseCommandResponse> Handle(CreateFollowCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validation = new FollowDtoValidator(_unitOfWork.userRepository);
            var validationResult = await validation.ValidateAsync(request.follow);
            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Following Faild";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            var follow = _mapper.Map<Follow>(request.follow);
            await _unitOfWork.followRepository.Follow(follow);
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Successfuly followed";

            return response;
        }
    }
}