using AutoMapper;
using MediatR;
using SocialMediaApp.Application.Exceptions;
using SocialMediaApp.Application.Features.Comments.Request.Commands;
using SocialMediaApp.Application.Features.Notifications.Request.Commands;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Features.Comments.Handler.Commands
{
    public class DeleteCommentRequestHandler : IRequestHandler<DeleteCommentRequest, Unit>
    {
        private ICommentRepository? _commentRepository;

        public DeleteCommentRequestHandler(ICommentRepository commentRepository)
        {
            this._commentRepository = commentRepository;
        }
        public async Task<Unit> Handle(DeleteCommentRequest request, CancellationToken cancellationToken)
        {
            var notification = await _commentRepository.GetCommentById(request.Id);
            await _commentRepository.Delete(notification);
            return Unit.Value;
        }
    }
}
