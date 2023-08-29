using Application.Contracts.Persistance;
using Application.DTO.CommentDTO.Validator;
using Application.Exceptions;
using Application.Features.Comment.Requests.Commands;
using Application.Responses;
using AutoMapper;
using MediatR;

namespace Application.Features.Comment.Handlers.Commands;

public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, BaseCommandResponse<Unit>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateCommentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseCommandResponse<Unit>> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var validator = new UpdateCommentDtoValidator(_unitOfWork.commentRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateCommentDto);

            if (!validationResult.IsValid) throw new ValidationException(validationResult);


            var comment = await _unitOfWork.commentRepository.Get(request.UpdateCommentDto.Id);
            if (comment is null) throw new NotFoundException(nameof(Comment), request.UpdateCommentDto.Id);

            _mapper.Map(request.UpdateCommentDto, comment);
            await _unitOfWork.commentRepository.Update(comment);

            if (await _unitOfWork.Save() == 0) throw new ServerErrorException("Something Went Wrong");


            return BaseCommandResponse<Unit>.SuccessHandler(Unit.Value);

        }
        catch (Exception ex)
        {
            return BaseCommandResponse<Unit>.FailureHandler(ex);
        }

    }
}