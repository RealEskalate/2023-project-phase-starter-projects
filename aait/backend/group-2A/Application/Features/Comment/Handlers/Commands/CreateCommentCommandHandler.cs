using Application.Contracts.Persistance;
using Application.DTO.CommentDTO.Validator;
using Application.Features.Comment.Requests.Commands;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.Features.Comment.Handlers.Commands;

public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, int>{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateCommentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateCommentDtoValidator(_unitOfWork.postRepository, _unitOfWork.userRepository);
        var validationResult = await validator.ValidateAsync(request.CommentDto);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        
        var comment = _mapper.Map<Domain.Entities.Comment>(request.CommentDto);
        await _unitOfWork.commentRepository.Add(comment);
        await _unitOfWork.Save();
        return comment.Id;
    }
}