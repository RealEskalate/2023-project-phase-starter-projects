
using Application.Contracts;
using Application.DTO.PostDTO.DTO;
using Application.Exceptions;
using Application.Features.PostFeature.Requests.Queries;
using Application.Response;
using AutoMapper;
using MediatR;

namespace Application.Features.PostFeature.Handlers.Queries;

public class GetPostsByTagHandler : IRequestHandler<GetPostsByTagQuery, BaseResponse<List<PostResponseDTO>>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetPostsByTagHandler( IUnitOfWork unitOfWork,IMapper mapper )
    {  
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        
    }

    public async Task<BaseResponse<List<PostResponseDTO>>> Handle(GetPostsByTagQuery request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.PostRepository.GetByTagName(request.TagName);

        if(result ==null){
            throw new NotFoundException("Tag Not found");
        }

        return new BaseResponse<List<PostResponseDTO>> {
            Success = true,
            Message = "Posts are retrieved successfully",
            Value = _mapper.Map<List<PostResponseDTO>>(result)
        };

    }
}

