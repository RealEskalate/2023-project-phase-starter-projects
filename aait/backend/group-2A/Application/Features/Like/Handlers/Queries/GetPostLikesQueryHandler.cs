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
            try{
                var likes = await _unitOfWork.likeRepository.GetLikers(request.Id, request.PageNumber,
                    request.PageSize);

                if (likes == null || likes.Count == 0){
                    throw new NotFoundException(nameof(Domain.Entities.Like), request.Id);
                }

                var userDtos = _mapper.Map<List<UserDto>>(likes);
                return BaseCommandResponse<List<UserDto>>.SuccessHandler(userDtos);
            } catch(Exception ex){
                return BaseCommandResponse<List<UserDto>>.FailureHandler(ex);
            }
        }
    }
}
