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
using Application.DTO.FollowDTO.Validator;
using Application.Exceptions;

namespace Application.Features.FollowFeatures.Handlers.Command
{
    public class CreateFollowCommandHandler : IRequestHandler<CreateFollowCommand, Unit>
    {
        private readonly IFollowRepository _followRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateFollowCommandHandler(IFollowRepository followRepository, IMapper mapper)
        {
            _followRepository = followRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateFollowCommand request, CancellationToken cancellationToken){
            var validation = new FollowDtoValidator(_userRepository);
            var validationResult = await validation.ValidateAsync(request.follow);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }
            var follow = _mapper.Map<Follow>(request.follow);
            await _followRepository.Follow(follow);
            return Unit.Value;
        }
    }
}
