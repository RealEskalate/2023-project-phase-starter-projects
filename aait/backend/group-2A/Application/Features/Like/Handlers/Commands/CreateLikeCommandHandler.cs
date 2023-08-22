
using MediatR;
using Application.Contracts.Persistance;
using Application.DTO.Like.Validator;
using Application.Exceptions;
using AutoMapper;

namespace Application.Features.Like.Handlers.Commands
{
    public class CreateLikeCommandHandler : IRequestHandler<CreateLikeCommand, Unit>
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILikeRepository _likeRepository;
        private readonly Mapper _mapper;

        public CreateLikeCommandHandler(IPostRepository postRepository, IUserRepository userRepository, ILikeRepository likeRepository){
            _likeRepository = likeRepository;
            _postRepository = postRepository;
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(CreateLikeCommand request, CancellationToken cancellationToken)
        {
            var validator = new LikedDtoValidator(_userRepository, _postRepository);
            var validationResult = await validator.ValidateAsync(request.like);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }
            await _likeRepository.LikePost(_mapper.Map<Domain.Entities.Like>(request.like));
            return Unit.Value;
        }
    }
}