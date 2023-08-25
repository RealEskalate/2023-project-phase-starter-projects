using Application.Contracts;
using Application.DTO.CommentDTOS.DTO;
using Application.DTO.CommentDTOS.Validations;
using Application.Features.CommentFeatures.Requests.Commands;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CommentFeatures.Handlers.Commands
{
    public class CommentCreateCommandHandler : IRequestHandler<CommentCreateCommand, CommentDTO>
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;

        public CommentCreateCommandHandler(IMapper mapper, ICommentRepository commentRepository)
        {
            _mapper = mapper;
            _commentRepository = commentRepository;
        }

        public async Task<CommentDTO> Handle(CommentCreateCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCommentValidator();
            var validationResult = await validator.ValidateAsync(request.CommentDTO);

            if (!validationResult.IsValid)
            {
                throw new NotImplementedException(); // Handle validation failure
            }

            var newComment = _mapper.Map<Comment>(request.CommentDTO);
            newComment.UserId = request.UserId;
            newComment.PostId = request.PostId;

            var result = await _commentRepository.Add(newComment);

            return _mapper.Map<CommentDTO>(result);
        }
    }
}
