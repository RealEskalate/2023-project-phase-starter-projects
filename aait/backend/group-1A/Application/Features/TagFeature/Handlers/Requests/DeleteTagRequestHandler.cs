using Application.Exceptions;
using AutoMapper;
using MediatR;
using SocialSync.Application.Contracts;
using SocialSync.Application.Features.Requests;
using SocialSync.Domain.Entities;
using Application.Exceptions;
using Application.Contracts;

namespace SocialSync.Application.Features;

public class DeleteTagRequestHandler : IRequestHandler<DeleteTagRequest, Unit>
{
    IMapper _mapper;
    // ITagRepository _tagRepository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteTagRequestHandler(IMapper mapper,IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        // _tagRepository = tagRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Unit> Handle(DeleteTagRequest request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.TagRepository.Exists(request.tag);

        if (!result){
            throw new NotFoundException("task not found");
        }

        return Unit.Value;
    }
}