using Application.Contracts.Persistance;
using Application.DTO.FollowDTO.Validator;
using Application.Features.FollowFeatures.Request.Command;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            var validationResult = await validator.ValidateAsync(request.unfollow);
            if (!validationResult.IsValid)
            {
                throw new ValidationException();
            }

            var unfollow = _mapper.Map<Follow>(request.unfollow);

            await _followRepository.Unfollow(unfollow);

            return Unit.Value;
        }
    }
}
