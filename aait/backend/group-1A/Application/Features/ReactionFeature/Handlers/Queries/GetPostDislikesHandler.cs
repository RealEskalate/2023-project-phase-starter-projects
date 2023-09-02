using Application.Contracts;
using Application.DTO.Common;
using Application.Exceptions;
using Application.Features.PostFeature.Requests.Queries;
using Application.Response;
using AutoMapper;
using MediatR;


namespace Application.Features.PostFeature.Handlers.Queries
{
    public class GetPostDislikesHandler : IRequestHandler<GetPostDislikesQuery, BaseResponse<List<ReactionResponseDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetPostDislikesHandler(IMapper mapper,IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<List<ReactionResponseDTO>>> Handle(GetPostDislikesQuery request, CancellationToken cancellationToken)
        {
            var exists = await _unitOfWork.PostRepository.Exists(request.PostId);
            if (!exists)
            {
                throw new NotFoundException("Post is not found to get the Reactions");
            }

            
            var result = await _unitOfWork.PostReactionRepository.DisLikes(request.PostId);

            return new BaseResponse<List<ReactionResponseDTO>> () {
                Success = true,
                Message = "Dislikes are retrieved successfully",
                
                Value = _mapper.Map<List<ReactionResponseDTO>>(result)
            };
        }
    }

}

