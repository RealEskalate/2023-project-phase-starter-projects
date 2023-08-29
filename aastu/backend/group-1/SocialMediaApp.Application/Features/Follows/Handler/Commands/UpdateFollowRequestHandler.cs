using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SocialMediaApp.Application.Exceptions;
using SocialMediaApp.Application.Features.Follows.Request.Commands;
using SocialMediaApp.Application.Persistence.Contracts;

namespace SocialMediaApp.Application.Features.Follows.Handler.Commands
{
    public class UpdateFollowRequestHandler : IRequestHandler<UpdateFollowCommandRequest, Unit>
    {
        private readonly IFollowRepository _followRepository;
        
        private readonly IMapper _mapper;

        public UpdateFollowRequestHandler(IFollowRepository followRepository, IMapper mapper)
        {
            _followRepository = followRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateFollowCommandRequest request, CancellationToken cancellationToken)
        {
            var follow = await _followRepository.GetById(request.Id);
            if (follow == null )
                throw new NotFoundException(nameof(follow), request.Id);
            await _followRepository.Update(follow);
            return Unit.Value;
        }
    }
}