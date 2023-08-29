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
        private readonly IPostRepository _postRepository;

        public DeletePostHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;

        }
        public async Task<BaseResponse<int>> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.Get(request.Id, request.userId);
            if (post == null) 
            {
                
                throw new NotFoundException("Post is not found");
                
            }
            
            var result = await _postRepository.Delete(post);

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
