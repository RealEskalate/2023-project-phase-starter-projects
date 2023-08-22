using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Like.Request.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Like.Handlers.Commands
{
    public class CreateLikeCommandHandler : IRequestHandler<CreateLikeCommand, Unit>
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;

        public CreateLikeCommandHandler(IPostRepository postRepository, IUserRepository userRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
        }

        public async Task<uint> Handle(CreateLikeCommand request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetById(request.PostId);
            if (post == null)
            {
                throw new NotFoundException("Post not found.");
            }

            var user = await _userRepository.GetById(request.UserId);
            if (user == null)
            {
                throw new NotFoundException("User not found.");
            }

            var like = new Like
            {
                PostId = request.PostId,
                UserId = request.UserId
            };

            post.Likes.Add(like);
            await _postRepository.Update(post);

            return like.Id;
        }
    }
}