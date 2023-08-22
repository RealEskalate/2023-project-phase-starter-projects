using Application.Contracts.Persistance;
using Application.Features.FollowFeatures.Request.Command;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FollowFeatures.Handlers.Command
{
    public class CreateFollowCommandHandler : IRequestHandler<CreateFollowCommand, Unit>
    {
        private readonly IFollowRepository _followRepository;
        private readonly IMapper _mapper;

        public CreateFollowCommandHandler(IFollowRepository followRepository, IMapper mapper)
        {
            _followRepository = followRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateFollowCommand request, CancellationToken cancellationToken)
        {
            var follow = _mapper.Map<Follow>(request.follow);

            await _followRepository.Follow(follow);

            return Unit.Value;
        }
    }
}
