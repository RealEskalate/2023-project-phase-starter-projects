namespace SocialSync.Application.Contracts.Persistence;

public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; }
    IInteractionRepository InteractionRepository { get; }
    IPostRepository PostRepository { get; }
    INotificationRepository NotificationRepository { get; }

    Task<int> SaveAsync();
}
