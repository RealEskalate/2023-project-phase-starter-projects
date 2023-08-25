using Application.Contracts.Persistance;
using Application.DTO.CommentDTO.Validator;
using Application.Features.Comment.Requests.Commands;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.Features.Comment.Handlers.Commands;

public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateCommentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateCommentDtoValidator(_unitOfWork.commentRepository);
        Console.WriteLine("reached handler");
        var validationResult = await validator.ValidateAsync(request.UpdateCommentDto);
        Console.WriteLine(request.UpdateCommentDto);
        if (!validationResult.IsValid)
        {    
            Console.WriteLine("validation");
            throw new Exception();
        }

        var comment = await _unitOfWork.commentRepository.Get(request.UpdateCommentDto.Id);
        if ( comment is null)
        {
            throw new FileNotFoundException();
        }
        _mapper.Map(request.UpdateCommentDto, comment);
        await _unitOfWork.commentRepository.Update(comment);
        await _unitOfWork.Save();
        return Unit.Value;

    }
}