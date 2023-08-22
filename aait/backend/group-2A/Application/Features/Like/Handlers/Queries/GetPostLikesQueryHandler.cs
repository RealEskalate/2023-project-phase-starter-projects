using Application.Contracts.Persistence;
using Application.Features.Like.Request.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Like.Handlers.Query
{
    public class GetPostLikesQueryHandler : IRequestHandler<GetPostLikesQuery, List<Like>>
    {
        private readonly ILikeRepository _likeRepository;

        public GetPostLikesQueryHandler(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public async Task<int> Handle(GetPostLikesQuery request, CancellationToken cancellationToken)
        {
            var likes = await _likeRepository.GetLikesByPostId(request.PostId);
            return likes;
        }
    }
}