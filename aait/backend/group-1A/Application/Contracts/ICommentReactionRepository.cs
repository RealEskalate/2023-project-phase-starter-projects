
using Domain.Entities;

namespace Application.Contracts
{
    public interface ICommentReactionRepository : IGenericRepository<CommentReaction>
    {
        public Task<List<CommentReaction>> Likes(int Id);

        public Task<List<CommentReaction>> DisLikes(int Id);

        public Task<CommentReaction> MakeReaction(int Id, CommentReaction entity);

        Task<bool> Exists(int id);
    }
}
