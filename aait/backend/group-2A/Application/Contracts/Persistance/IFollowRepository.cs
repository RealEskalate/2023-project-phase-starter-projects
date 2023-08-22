using Domain.Entities;

namespace Application.Contracts.Persistance;

public interface IFollowRepository{

    Task<List<Follow>> GetFollowing(int id);
    Task<List<Follow>> GetFollower(int id);
    Task Follow(Follow follow);

}
