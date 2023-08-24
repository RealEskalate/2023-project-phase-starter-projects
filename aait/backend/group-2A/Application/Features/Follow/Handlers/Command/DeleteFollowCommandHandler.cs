using Application.Contracts.Persistance;
using Application.DTO.FollowDTO.Validator;
using Application.Features.FollowFeatures.Request.Command;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Application.Exceptions;
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
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public DeleteFollowCommandHandler(IFollowRepository followRepository, IUserRepository userRepository, IMapper mapper)
        {
            _followRepository = followRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteFollowCommand request, CancellationToken cancellationToken)
        {
            var validator = new FollowDtoValidator(_userRepository);
            var validationResult = await validator.ValidateAsync(request.follow);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var unfollow = _mapper.Map<Follow>(request.follow);

            await _followRepository.Unfollow(unfollow);

            return Unit.Value;
        }
    }
}
