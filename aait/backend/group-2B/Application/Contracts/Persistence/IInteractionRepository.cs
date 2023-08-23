using SocialSync.Domain.Entities;

namespace SocialSync.Application.Contracts.Persistence;

public interface IInteractionRepository : IGenericRepository<Interaction> {  
     Task<List<Interaction>> GetAllCommentInteractions(int PostId);

    Task<Interaction> likeUnlikeInteraction(Interaction interaction);
    }
