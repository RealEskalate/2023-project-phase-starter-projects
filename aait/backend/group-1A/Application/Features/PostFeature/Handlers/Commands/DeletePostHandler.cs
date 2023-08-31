using Application.Contracts;
using Application.DTO.NotificationDTO;
using Application.DTO.PostDTO.DTO;
using Application.Exceptions;
using Application.Features.NotificationFeaure.Requests.Commands;
using Application.Features.PostFeature.Requests.Commands;
using Application.Response;
using MediatR;

namespace Application.Features.PostFeature.Handlers.Commands
{
    public class DeletePostHandler : IRequestHandler<DeletePostCommand, BaseResponse<int>>
    {
        // private readonly IPostRepository _postRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletePostHandler(IUnitOfWork unitOfWork)
        {
            // _postRepository = postRepository;
            _unitOfWork = unitOfWork;

        }
        public async Task<BaseResponse<int>> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _unitOfWork.PostRepository.Get(request.Id);
            if (post == null) 
            {
                
                throw new NotFoundException("Post is not found");
                
            }

            if (post.UserId != request.userId)
            {
                throw new BadRequestException("You cannot delete other people's posts");
            }
            
            var result = await _unitOfWork.PostRepository.Delete(post);

            if (!result){
                throw new BadRequestException("The post is not deleted");
            }


            return  new BaseResponse<int> {
                Success = true,
                Message = "The post is deleted successfully",
                Value = post.Id
            };
        }
    }
}
