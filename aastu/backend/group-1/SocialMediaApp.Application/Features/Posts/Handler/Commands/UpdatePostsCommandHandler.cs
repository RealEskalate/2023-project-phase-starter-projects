using AutoMapper;
using MediatR;
using SocialMediaApp.Application.DTOs.Posts.Validators;
using SocialMediaApp.Application.Features.Posts.Request.Commands;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Features.Posts.Handler.Commands
{
    public class UpdatePostsCommandHandler : IRequestHandler<UpdatePostsCommand, Unit>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public UpdatePostsCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;

        }

        public async Task<Unit> Handle(UpdatePostsCommand request, CancellationToken cancellationToken)
        {
            
            var validator = new UpdatePostDtoValidator(_postRepository);
            var validationResult = await validator.ValidateAsync(request.post);
            if (validationResult.IsValid == true)
            {
                var post = await _postRepository.GetById(request.post.Id);
                _mapper.Map(request.post, post);
                await _postRepository.Update(post);
            }
           
            return Unit.Value;
        }
    }
}