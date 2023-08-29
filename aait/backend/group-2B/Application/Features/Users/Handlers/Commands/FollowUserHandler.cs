using Application.Features.Users.Requests.Commands;
using AutoMapper;
using MediatR;
using SocialSync.Application.Common.Responses;
using SocialSync.Application.Contracts.Persistence;
using SocialSync.Application.DTOs.Users.Validators;

namespace Applicatin .Features.Users.Handlers.Commands
{
    public class FollowUserHandler : IRequestHandler<FollowUserCommand , CommonResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public FollowUserHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }

        public async Task<CommonResponse<int>> Handle(FollowUserCommand request, CancellationToken cancellationToken)
        {
                var validator = new FollowUnfollowDtoValidator(_unitOfWork);
                var vallidationResult = await validator.ValidateAsync(request.FollowUnfollowDto);

                if (!vallidationResult.IsValid) {
                return CommonResponse<int>.Failure("failed to follow");


                }
        
            await _unitOfWork.UserRepository.FollowUser(request.FollowUnfollowDto.FollwerId,request.FollowUnfollowDto.FollowedId);

            await _unitOfWork.SaveAsync();


            return  CommonResponse<int>.Success(1);
        
        }
        

        }
    }

