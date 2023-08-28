using Application.DTO.PostDTO.DTO;
using Application.Response;
using MediatR;


namespace Application.Features.PostFeature.Requests.Commands
{
    public class CreatePostCommand : IRequest<BaseResponse<PostResponseDTO>>
    {
        public PostCreateDTO NewPostData { get; set; }
        public int userId { get; set; }
    }
}
