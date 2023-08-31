using Application.Contracts;
using Application.Response;
using AutoMapper;
using MediatR;
using SocialSync.Application.Contracts;
using SocialSync.Application.DTO;
using SocialSync.Application.Features.Requests;
using SocialSync.Domain.Entities;

namespace SocialSync.Application.Features.Handlers;

public class GetAllTagsRequestHandler : IRequestHandler<GetAllTagsRequest, BaseResponse<List<TagResponseDto>>>
{
    private readonly IMapper _mapper;
    // private readonly ITagRepository _tagReposiotry;
    private readonly IUnitOfWork _unitOfWork;
    public GetAllTagsRequestHandler(IUnitOfWork unitOfWork,IMapper mapper)
    {
        // _tagReposiotry = tagRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<BaseResponse<List<TagResponseDto>>> Handle(GetAllTagsRequest request, CancellationToken cancellationToken)
    {
        var tags = await _unitOfWork.TagRepository.GetAll(request.userId);
        Console.WriteLine(tags);
        
        return new BaseResponse<List<TagResponseDto>>(){
            Success = true,
            Message = "Tags retrived successfully",
            Value = _mapper.Map<List<TagResponseDto>>(tags)
        };
        

    }
}