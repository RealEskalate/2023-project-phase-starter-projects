using Application.Contracts;
using AutoMapper;
using MediatR;
using SocialSync.Application.Contracts;
using SocialSync.Application.DTO;
using SocialSync.Application.Features.Requests;
using SocialSync.Domain.Entities;

namespace SocialSync.Application.Features;

public class UpdateTagRequestHandler : IRequestHandler<UpdateTagRequest, TagResponseDto>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateTagRequestHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    public Task<TagResponseDto> Handle(UpdateTagRequest request, CancellationToken cancellationToken)
    {
        var result = _unitOfWork.TagRepository.Update(_mapper.Map<Tag>(request.UpdateTagDto));

        if (result != null)
        {
            return Task.FromResult(_mapper.Map<TagResponseDto>(result));
        }
        else
        {
            throw new Exception("Error while updating tag");
        }
        
    }
}