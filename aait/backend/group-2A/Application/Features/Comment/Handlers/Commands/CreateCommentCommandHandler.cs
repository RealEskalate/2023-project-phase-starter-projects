using Application.Contracts.Persistance;
using Application.DTO.CommentDTO.Validator;
using Application.Features.Comment.Requests.Commands;
using AutoMapper;
using MediatR;
using Application.Exceptions;
using Application.Responses;

namespace Application.Features.Comment.Handlers.Commands;

public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateCommentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseCommandResponse> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new CreateCommentDtoValidator(_unitOfWork.postRepository, _unitOfWork.userRepository);
        var validationResult = await validator.ValidateAsync(request.CommentDto);

        if (!validationResult.IsValid)
        {
            response.Success = false;
            response.Message = "Comment Creation Faild";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
        }
        
        var comment = _mapper.Map<Domain.Entities.Comment>(request.CommentDto);
        await _unitOfWork.commentRepository.Add(comment);
        await _unitOfWork.Save();

        response.Success = true;
        response.Message = "Comment Creation Successful";
        response.Id = comment.Id;

        return response;
    }
}