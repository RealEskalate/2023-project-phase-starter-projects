
using Application.Features.Like.Request.Commands;
using MediatR;
using Application.Contracts.Persistance;
using AutoMapper;
using Application.Responses;

namespace Application.Features.Like.Handlers.Commands
{
    public class DeleteLikeCommandHandler : IRequestHandler<DeleteLikeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteLikeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse> Handle(DeleteLikeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
             await _unitOfWork.likeRepository.UnlikePost(_mapper.Map<Domain.Entities.Like>(request.like));
             await _unitOfWork.Save();

            response.Success = true;
            response.Message = "like Faild";

            return response;
        }
    }
}