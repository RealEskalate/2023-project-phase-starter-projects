using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;
using FluentValidation;

namespace Application.DTO.FollowDTo.Validations
{
    public class FollowDTOValidation : AbstractValidator<FollowDTO>
    {
        IUserRepository _userRepository;
        IFollowRepository _followRepository;
        public FollowDTOValidation(IUserRepository userRepository,IFollowRepository followRepository)
        {
            _userRepository = userRepository;
            _followRepository = followRepository;

            RuleFor(x => x.FolloweeId)
                    .NotEmpty().WithMessage("FolloweeId is required")
                    .MustAsync(async (followeeId, cancellation) =>
                        {
                            return await _userRepository.Exists(followeeId);
                        }).WithMessage("Followee does not exist");
                
        }
    }
}