using AutoMapper;
using MediatR;
using SocialMediaApp.Application.DTOs.Comments.Validator;
using SocialMediaApp.Application.Exceptions;
using SocialMediaApp.Application.Features.Comments.Request.Commands;
using SocialMediaApp.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Features.Comments.Handler.Commands
{
    public class UpdateCommentRequestHandler : IRequestHandler<UpdateCommentRequest, Unit>
    {
        private readonly IMapper? _mapper;

        private ICommentRepository? _commentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;
        public UpdateCommentRequestHandler(ICommentRepository commentRepository, IMapper mapper, IUserRepository userRepository, IPostRepository postRepository )
        {
            this._mapper = mapper;  
            this._commentRepository = commentRepository;
            this._userRepository = userRepository;
            this._postRepository = postRepository;
        }
        public async Task<Unit> Handle(UpdateCommentRequest request, CancellationToken cancellationToken)
        {
           

            var CommentToBeUpdated = await _commentRepository.GetCommentById(request.updatedCommentDto.Id);
            var validator = new UpdateCommentDtoValidator(_userRepository,_postRepository);
            var validationResult = await validator.ValidateAsync(request.updatedCommentDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            _mapper.Map(request.updatedCommentDto, CommentToBeUpdated);

            await _commentRepository.Update(CommentToBeUpdated);

            return Unit.Value;
            
        }
    }
}
