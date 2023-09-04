using Application.Contracts;
using Application.Exceptions;
using Application.Features.UserFeature.Requests.Commands;
using Application.Response;
using MediatR;


namespace Application.Features.UserFeature.Handlers.Commands
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, BaseResponse<string>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var deleteResponse = new BaseResponse<string>();
            var user = await _unitOfWork.UserRepository.Get(request.userId);
            if (user == null)
            {
                throw new NotFoundException("user is not found");
            }
            
            var result = await _unitOfWork.UserRepository.Delete(user!);

            deleteResponse.Success = true;
            deleteResponse.Message = "User deleted successfully";
            return deleteResponse;
            
        }
    }
}
