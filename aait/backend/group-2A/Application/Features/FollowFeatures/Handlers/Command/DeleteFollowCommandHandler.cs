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
    public class DeleteFollowCommandHandler : IRequestHandler<DeleteFollowCommand, Unit>
    {
        private readonly IFollowRepository _followRepository;
        private readonly IMapper _mapper;

        public DeleteFollowCommandHandler(IFollowRepository followRepository, IMapper mapper)
        {
            _followRepository = followRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteFollowCommand request, CancellationToken cancellationToken)
        {
            var unfollow = _mapper.Map<Follow>(request.unfollow);

            await _followRepository.Unfollow(unfollow);

            return Unit.Value;
        }
    }
}
