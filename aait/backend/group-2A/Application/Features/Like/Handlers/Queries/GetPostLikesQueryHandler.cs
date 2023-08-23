using MediatR;
using Application.Contracts.Persistance;
using Application.DTO.UserDTO;

namespace Application.Features.Like.Handlers.Query
{
    public class GetPostLikesQueryHandler : IRequestHandler<GetPostLikesQuery, List<UserDto>>
    {
        private readonly ILikeRepository _likeRepository;

        public GetPostLikesQueryHandler(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public async Task<List<UserDto>> Handle(GetPostLikesQuery request, CancellationToken cancellationToken)
        {
            var likes = await _likeRepository.Likers(request.Id);
            return likes;
        }
    }
}