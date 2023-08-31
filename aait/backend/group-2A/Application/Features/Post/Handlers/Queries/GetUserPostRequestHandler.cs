using Application.Contracts.Persistance;
using Application.DTO.Post;
using Application.Features.Post.Request.Queries;
using AutoMapper;
using MediatR;
using Application.Responses;
using System.Collections.Generic;
using Application.Exceptions;

namespace Application.Features.Post.Handlers.Queries{
    public class GetUserPostRequestHandler : IRequestHandler<GetUserPostRequest, BaseCommandResponse<List<PostDto>>>{
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUserPostRequestHandler(IUnitOfWork unitOfWork, IMapper mapper){
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse<List<PostDto>>> Handle(GetUserPostRequest request,
            CancellationToken cancellationToken){
            try{
                var posts = await _unitOfWork.postRepository.GetUserPost(request.Id, request.PageNumber,
                    request.PageSize);

                if (posts == null || posts.Count == 0){
                    throw new NotFoundException(nameof(Domain.Entities.Post), request.Id);
                }

                var postDtos = _mapper.Map<List<PostDto>>(posts);
                return BaseCommandResponse<List<PostDto>>.SuccessHandler(postDtos);
            }
            catch(Exception ex){
                return BaseCommandResponse<List<PostDto>>.FailureHandler(ex);
            }
        }
    }
}
