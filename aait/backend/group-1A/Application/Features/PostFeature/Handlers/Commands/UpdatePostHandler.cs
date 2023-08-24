using Application.Contracts;
using Application.DTO.Common;
using Application.DTO.PostDTO.DTO;
using Application.DTO.PostDTO.validations;
using Application.Features.PostFeature.Requests.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PostFeature.Handlers.Commands
{
    public class UpdatePostHandler : IRequestHandler<UpdatePostCommand, PostResponseDTO>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public UpdatePostHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<PostResponseDTO> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var validator = new PostUpdateValidation();
            var validationResult = await validator.ValidateAsync(request.PostUpdateData);

            if (!validationResult.IsValid)
            {
                throw new Exception();
            }
            if (request.Id <= 0)
            {
                throw new Exception();
            }
            var newPost = _mapper.Map<Post>(request.PostUpdateData);
            newPost.Id = request.Id;
            newPost.UserId = request.userId;
            var updationResult = await _postRepository.Update(newPost);

            return _mapper.Map<PostResponseDTO>(updationResult);
        }
    }
}
