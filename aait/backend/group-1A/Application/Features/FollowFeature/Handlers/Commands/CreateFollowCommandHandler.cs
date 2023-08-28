using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common;
using Application.Contracts;
using Application.DTO.Common;
using Application.DTO.FollowDTo;
using Application.DTO.FollowDTo.Validations;
using Application.Exceptions;
using Application.Features.FollowFeature.Requests.Commands;
using AutoMapper;
using Domain.Entites;
using MediatR;

namespace Application.Features.FollowFeature.Handlers.Commands
{
    public class CreateFollowCommandHandler : IRequestHandler<CreateFollowCommand, CommonResponseDTO>
    {
      
        private readonly IFollowRepository _followRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateFollowCommandHandler(IMapper mapper, IFollowRepository FollowRepository,IUserRepository userRepository)
        {
            _mapper = mapper;
            _followRepository = FollowRepository;
            _userRepository = userRepository;
        }

        public async Task<CommonResponseDTO> Handle(CreateFollowCommand request, CancellationToken cancellationToken)
        {   

            var followValidation = new FollowDTOValidation(_userRepository,_followRepository);
            var followValidationResult = await followValidation.ValidateAsync(request.FollowDTO!);
            var createFollowResponse = new CommonResponseDTO();
            if (!followValidationResult.IsValid)
            {
                createFollowResponse.Status = "Failure";
                createFollowResponse.Message = "Unable to follow given user";

                return createFollowResponse;
            }

            var followEntity = _mapper.Map<Follow>(request.FollowDTO);
            var createFollowCommandResult = await _followRepository.AddFollow(followEntity);

            createFollowResponse.Status = "Success";
            createFollowResponse.Message = "Successfully followed the given User";

            return createFollowResponse;
        }
    }
}