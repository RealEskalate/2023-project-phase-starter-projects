using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;
using Application.DTO.PostDTO.DTO;
using Application.Features.PostFeature.Requests.Queries;
using Application.Response;
using AutoMapper;
using MediatR;
using SocialSync.Domain.Entities;

namespace Application.Features.PostFeature.Handlers.Queries
{
    public class GetFeedQueryHandler : IRequestHandler<GetFeedQuery, BaseResponse<List<PostResponseDTO>>>
    {
        
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public GetFeedQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseResponse<List<PostResponseDTO>>> Handle(GetFeedQuery request, CancellationToken cancellationToken)
        {
            var feeds = await _unitOfWork.PostRepository.GetFeed(request.UserId);
            return new BaseResponse<List<PostResponseDTO>> {
                Success = true,
                Message = "Posts are retrieved successfully",
                Value = _mapper.Map<List<PostResponseDTO>>(feeds)
            };

        }
    }
}