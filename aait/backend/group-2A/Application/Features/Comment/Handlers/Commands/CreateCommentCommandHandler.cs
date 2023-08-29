using Application.Contracts.Persistance;
using Application.DTO.CommentDTO.Validator;
using Application.Features.Comment.Requests.Commands;
using AutoMapper;
using MediatR;
using Application.Exceptions;
using Application.Responses;
using Domain.Entities;

namespace Application.Features.Comment.Handlers.Commands;

public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, BaseCommandResponse<int>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateCommentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseCommandResponse<int>> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        try 
        {
            var validator = new CreateCommentDtoValidator(_unitOfWork.postRepository, _unitOfWork.userRepository);
            var validationResult = await validator.ValidateAsync(request.CommentDto);

            if (!validationResult.IsValid) throw new ValidationException(validationResult);

            var comment = _mapper.Map<Domain.Entities.Comment>(request.CommentDto);
            var PostDetail = await _unitOfWork.postRepository.Get(request.CommentDto.PostId);
            
            var notify = new Notification(){
                UserId =  PostDetail.UserId,
                NotifierId = request.CommentDto.UserId,
                Message = "Commented On your post" };

            await _unitOfWork.commentRepository.Add(comment);
            await _unitOfWork.notificationRepository.AddNotification(notify);
            int affectedRows = await _unitOfWork.Save();
            if (affectedRows == 0) throw new ServerErrorException("Something Went Wrong");
            return BaseCommandResponse<int>.SuccessHandler(comment.Id);
        }
        catch (Exception ex) 
        {
            return BaseCommandResponse<int>.FailureHandler(ex);
        }
    }
}