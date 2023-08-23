using Application.Contracts.Persistance;
using Application.DTO.CommentDTO.Validator;
using Application.Features.Comment.Requests.Commands;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.Features.Comment.Handlers.Commands;

public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, Unit>
{

    private readonly IMapper _mapper;
    private readonly ICommentRepository _commentRepository;

    public UpdateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
    {

        _mapper = mapper;
        _commentRepository = commentRepository;
    }

    public async Task<Unit> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateCommentDtoValidator(_commentRepository);
        var validationResult = await validator.ValidateAsync(request.UpdateCommentDto);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var comment = await _commentRepository.Get(request.UpdateCommentDto.Id);
        if ( comment is null)
        {
            throw new FileNotFoundException();
        }
        _mapper.Map(request.UpdateCommentDto, comment);
        await _commentRepository.Update(comment);
        return Unit.Value;

    }
}