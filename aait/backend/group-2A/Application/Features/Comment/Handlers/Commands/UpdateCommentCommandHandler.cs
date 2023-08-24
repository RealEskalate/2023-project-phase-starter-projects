using Application.Contracts.Persistance;
using Application.DTO.CommentDTO.Validator;
using Application.Exceptions;
using Application.Features.Comment.Requests.Commands;
using Application.Responses;
using AutoMapper;
using MediatR;

namespace Application.Features.Comment.Handlers.Commands;

public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateCommentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseCommandResponse> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new UpdateCommentDtoValidator(_unitOfWork.commentRepository);
        var validationResult = await validator.ValidateAsync(request.UpdateCommentDto);

        if (!validationResult.IsValid)
        {
            response.Success = false;
            response.Message = "Comment Update Faild";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
        }

        var comment = await _unitOfWork.commentRepository.Get(request.UpdateCommentDto.Id);
        if ( comment is null)
        {
            response.Success = false;
            response.Message = "Comment Not found";
            response.Errors = new List<string> { "Comment Not found" };
        }
        else
        {  
            _mapper.Map(request.UpdateCommentDto, comment);
            await _unitOfWork.commentRepository.Update(comment);
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Comment Updated Successfuly";
        }
        return response;

    }
}