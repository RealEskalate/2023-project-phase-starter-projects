using MediatR;
using Application.Contracts.Persistance;
using Application.DTO.UserDTO;
using AutoMapper;
using Application.Responses;
using System.Collections.Generic;
using Application.Exceptions;

namespace Application.Features.Like.Handlers.Query
{
    public class GetPostLikesQueryHandler : IRequestHandler<GetPostLikesQuery, BaseCommandResponse<List<UserDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPostLikesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse<List<UserDto>>> Handle(GetPostLikesQuery request, CancellationToken cancellationToken)
        {
            var likes = await _unitOfWork.likeRepository.GetLikers(request.Id);

            if (likes == null)
            {
                var notFoundException = new NotFoundException(nameof(Domain.Entities.Like), request.Id);
                return BaseCommandResponse<List<UserDto>>.FailureHandler(notFoundException);
            }

            var userDtos = _mapper.Map<List<UserDto>>(likes);
            return BaseCommandResponse<List<UserDto>>.SuccessHandler(userDtos);
        }
    }
}
