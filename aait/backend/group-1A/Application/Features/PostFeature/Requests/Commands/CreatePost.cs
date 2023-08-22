using Application.DTO.PostDTO.DTO;
using MediatR;


namespace Application.Features.PostFeature.Requests.Commands
{
    public class CreatePostCommand : IRequest<PostResponseDTO>
    {
        public PostCreateDTO NewPostData { get; set; }
    }
}
