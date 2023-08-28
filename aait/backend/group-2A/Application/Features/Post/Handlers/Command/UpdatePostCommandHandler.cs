using Application.Contracts.Persistance;
using Application.DTO.Post.Validation;
using Application.Exceptions;
using Application.Features.Post.Request.Commands;
using Application.Responses;
using AutoMapper;
using MediatR;

namespace Application.Features.Post.Handlers.Command;

public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, BaseCommandResponse<Unit>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdatePostCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;

    }

    public async Task<BaseCommandResponse<Unit>> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var validator = new UpdatePostDtoValidator(_unitOfWork.postRepository, _unitOfWork.userRepository);
            var validationResult = await validator.ValidateAsync(request.UpdatedPost);
            if (!validationResult.IsValid) throw new ValidationException(validationResult);

            var post = await _unitOfWork.postRepository.Get(request.UpdatedPost.Id);
            _mapper.Map(request.UpdatedPost, post);
            await _unitOfWork.postRepository.Update(post);
            int affectedRows = await _unitOfWork.Save();
            if (affectedRows == 0) throw new ServerErrorException("Something Went Wrong");

            return BaseCommandResponse<Unit>.SuccessHandler(Unit.Value); ;
        }catch (Exception ex)
        {
            return BaseCommandResponse<Unit>.FailureHandler(ex);
        }
    }

}