using Application.Contracts;
using Application.DTO.PostDTO.DTO;
using Application.DTO.PostDTO.validations;
using Application.Features.PostFeature.Requests.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;


namespace Application.Features.PostFeature.Handlers.Commands
{
    public class CreatePostHandler : IRequestHandler<CreatePostCommand, PostResponseDTO>
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;

        public CreatePostHandler(IMapper mapper, IPostRepository postRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }
        public async Task<PostResponseDTO> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var validator = new PostCreateValidation();
            var validationResult = await validator.ValidateAsync(request.NewPostData);

            if (!validationResult.IsValid)
            {
                throw new NotImplementedException();
            }

            var newPost = _mapper.Map<Post>(request.NewPostData);
            newPost.UserId = request.userId;
            var result = await _postRepository.Add(newPost);


            return _mapper.Map<PostResponseDTO>(result);
        }
    }
}
