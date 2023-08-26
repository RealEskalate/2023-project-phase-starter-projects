
using Application.Features.Like.Request.Commands;
using MediatR;
using Application.Contracts.Persistance;
using AutoMapper;
using Application.Responses;
using Application.Exceptions;

namespace Application.Features.Like.Handlers.Commands
{
    public class DeleteLikeCommandHandler : IRequestHandler<DeleteLikeCommand, BaseCommandResponse<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteLikeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse<Unit>> Handle(DeleteLikeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.likeRepository.UnlikePost(_mapper.Map<Domain.Entities.Like>(request.like));
                int affectedRows = await _unitOfWork.Save();
                if (affectedRows == 0) throw new ServerErrorException("Something Went Wrong");


                return BaseCommandResponse<Unit>.SuccessHandler(Unit.Value); ;
            }catch (Exception ex)
            {
                return BaseCommandResponse<Unit>.FailureHandler(ex);
            }
        }
    }
}