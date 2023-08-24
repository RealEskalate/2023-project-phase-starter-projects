using SocialSync.Domain.Entities;

namespace SocialSync.Application.Contracts.Persistence;

public interface IInteractionRepository : IGenericRepository<Interaction>
{
    Task<List<Interaction>> GetAllCommentInteractionsAsync(int postId);

    Task<Interaction> LikeUnlikeInteractionAsync(Interaction interaction);
}