using Application.Contracts.Persistance;
using Application.DTO.Post;
using Application.Features.Post.Request.Queries;
using AutoMapper;
using MediatR;
using Application.Responses;
using System.Collections.Generic;
using Application.Exceptions;

namespace Application.Features.Post.Handlers.Queries
{
    public class GetByTagRequestHandler : IRequestHandler<GetByTagRequest, BaseCommandResponse<List<PostDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetByTagRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse<List<PostDto>>> Handle(GetByTagRequest request, CancellationToken cancellationToken)
        {
            var posts = await _unitOfWork.postRepository.GetBytag(request.Tag);

            if (posts == null || posts.Count == 0)
            {
                var notFoundException = new NotFoundException(nameof(Domain.Entities.Post), request.Tag);
                return BaseCommandResponse<List<PostDto>>.FailureHandler(notFoundException);
            }

            var postDtos = _mapper.Map<List<PostDto>>(posts);
            return BaseCommandResponse<List<PostDto>>.SuccessHandler(postDtos);
        }
    }
}
