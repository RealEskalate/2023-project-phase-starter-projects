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
    public class CreateFollowCommandHandler : IRequestHandler<CreateFollowCommand, BaseResponse<int>>
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

        public async Task<BaseResponse<int>> Handle(CreateFollowCommand request, CancellationToken cancellationToken)
        {   

            var followValidation = new FollowDTOValidation(_userRepository,_followRepository);
            var followValidationResult = await followValidation.ValidateAsync(request.FollowDTO!);
            var createFollowResponse = new BaseResponse<int>();
            
            if (!followValidationResult.IsValid)
            {
                throw new BadRequestException("Unable to follo the user");
            }

            var followEntity = _mapper.Map<Follow>(request.FollowDTO);
            var createFollowCommandResult = await _followRepository.AddFollow(followEntity);
            createFollowResponse.Success = true;
            createFollowResponse.Message = "Followed successfully";
            createFollowResponse.Value = createFollowCommandResult.FollowerId;
            
            
            return createFollowResponse;
        }
    }
}