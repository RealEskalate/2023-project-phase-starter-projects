

using Application.Contracts;
using Application.DTO.PostDTO.DTO;
using Application.DTO.PostDTO.validations;
using Application.Exceptions;
using Application.Features.PostFeature.Requests.Commands;
using Application.Response;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.PostFeature.Handlers.Commands
{
    public class UpdatePostHandler : IRequestHandler<UpdatePostCommand, BaseResponse<PostResponseDTO>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public UpdatePostHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<PostResponseDTO>> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var validator = new PostUpdateValidation();
            var validationResult = await validator.ValidateAsync(request.PostUpdateData);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }
            var exists = await _postRepository.Exists(request.Id);


            if (!exists) 
            {
                throw new NotFoundException("Post is not found");
            }

            var newPost = _mapper.Map<Post>(request.PostUpdateData);
            newPost.Id = request.Id;
            newPost.UserId = request.userId;
            var updationResult = await _postRepository.Update(newPost);
            var result = _mapper.Map<PostResponseDTO>(updationResult);

            return new BaseResponse<PostResponseDTO> {
                Success = true,
                Message = "The Post is updated successfully",
                Value = result
            };
        }
    }
}
