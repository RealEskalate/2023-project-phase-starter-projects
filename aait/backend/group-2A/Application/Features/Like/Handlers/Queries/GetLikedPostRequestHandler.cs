using Application.Contracts.Persistance;
using Application.DTO.Post;
using Application.Exceptions;
using Application.Features.Like.Request.Queries;
using Application.Responses;
using AutoMapper;
using MediatR;

namespace Application.Features.Like.Handlers.Query;

public class GetLikedPostRequestHandler : IRequestHandler<GetLikedPostRequest, BaseCommandResponse<List<PostDto>>>{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetLikedPostRequestHandler(IUnitOfWork unitOfWork, IMapper mapper){
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse<List<PostDto>>> Handle(GetLikedPostRequest request, CancellationToken cancellationToken){
        try{
            var posts = await _unitOfWork.likeRepository.GetLikedPost(request.Id, request.PageNumber,
                request.PageSize);
            if (posts == null) throw new NotFoundException(nameof(List<PostDto>), request.Id);
            return BaseCommandResponse<List<PostDto>>.SuccessHandler(_mapper.Map<List<PostDto>>(posts));
        }
        catch(Exception ex){
            return BaseCommandResponse<List<PostDto>>.FailureHandler(ex);
        }

    }
}