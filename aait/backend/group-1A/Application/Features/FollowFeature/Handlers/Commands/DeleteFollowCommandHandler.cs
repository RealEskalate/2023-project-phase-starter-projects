using Application.Contracts;
using Application.DTO.FollowDTo.Validations;
using Application.Exceptions;
using Application.Features.FollowFeature.Requests.Commands;
using Application.Response;
using AutoMapper;
using Domain.Entites;
using MediatR;

namespace Application.Features.FollowFeature.Handlers.Commands
{
     public class DeleteFollowCommandHandler : IRequestHandler<DeleteFollowCommand, BaseResponse<int>>
    {
      
        private readonly IFollowRepository _followRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public DeleteFollowCommandHandler(IMapper mapper, IFollowRepository FollowRepository,IUserRepository userRepository)
        {
            _mapper = mapper;
            _followRepository = FollowRepository;
            _userRepository = userRepository;

        }

        public async Task<BaseResponse<int>> Handle(DeleteFollowCommand request, CancellationToken cancellationToken)
        {   
            var followValidation = new FollowDTOValidation(_userRepository,_followRepository);
            var followValidationResult = await followValidation.ValidateAsync(request.FollowDTO!);
            var createFollowResponse = new BaseResponse<int>();

            if (!followValidationResult.IsValid)
            {
                throw new BadRequestException("Unable to delete the follow request");
            }

            var followEntity = _mapper.Map<Follow>(request.FollowDTO);
            await _followRepository.DeleteFollow(followEntity);
            
            createFollowResponse.Success = true;
            createFollowResponse.Message = $"User with Id {followEntity.FollowerId} has un followed you";
            createFollowResponse.Value = followEntity.FolloweeId;
            return createFollowResponse;
        }
    }
}