using AutoMapper;
using MediatR;
using SocialMediaApp.Application.Exceptions;
using SocialMediaApp.Application.Features.Likes.Request.Commands;
using SocialMediaApp.Application.Features.Notifications.Request.Commands;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Features.Likes.Handler.Commands
{
    public class DeleteLIkeCommandHandler : IRequestHandler<DeleteLikeRequest, Unit>
    {
        private readonly ILikeRepository _likeRepository;
        private readonly IMapper _mapper;
        public DeleteLIkeCommandHandler(ILikeRepository likeRepository, IMapper mapper)
        {
            _likeRepository = likeRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteLikeRequest request, CancellationToken cancellationToken)
        {
            var like = await _likeRepository.GetById
                ( request.LikeId);
             
            if (like == null)
            {
                throw new NotFoundException(nameof(Like), request.LikeId);
            }
            else if(like.UserId !=  request.UserId)
            {
                throw new BadRequestException("you are not the owner of the like");
            }
            await _likeRepository.Delete(like);
            return Unit.Value;
        }
    }
}
