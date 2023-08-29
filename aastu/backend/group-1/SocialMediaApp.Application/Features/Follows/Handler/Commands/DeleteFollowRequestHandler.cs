using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SocialMediaApp.Application.Exceptions;
using SocialMediaApp.Application.Features.Follows.Request.Commands;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Application.Responses;

namespace SocialMediaApp.Application.Features.Follows.Handler.Commands
{
    public class DeleteFollowRequestHandler : IRequestHandler<DeleteFollowCommandRequest, Unit>
    {
        private readonly IFollowRepository _followRepository;
        private readonly IMapper _mapper;

        public DeleteFollowRequestHandler(IFollowRepository followRepository, IMapper mapper)
        {
            _followRepository = followRepository;
            _mapper = mapper;
            
        }
        public async Task<Unit> Handle(DeleteFollowCommandRequest request, CancellationToken cancellationToken)
        {
            var follow = await _followRepository.GetById(request.Id);
            if (follow == null)
            {
                throw new NotFoundException(nameof(follow), request.Id);
            }
            else if(follow.CurrentUser != request.UserId)
            {
                throw new BadRequestException("you are not the owner of the Follow");
            }
            await _followRepository.Delete(follow);

            return Unit.Value;
        }
    }
}