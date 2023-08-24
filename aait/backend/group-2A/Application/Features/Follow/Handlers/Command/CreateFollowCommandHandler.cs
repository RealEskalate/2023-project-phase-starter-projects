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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateFollowCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(CreateFollowCommand request, CancellationToken cancellationToken)
        {
            var validation = new FollowDtoValidator(_unitOfWork.userRepository);
            var validationResult = await validation.ValidateAsync(request.follow);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }
            var follow = _mapper.Map<Follow>(request.follow);
            await _unitOfWork.followRepository.Follow(follow);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}