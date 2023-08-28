using SocialSync.Application.Contracts.Persistence;

namespace SocialSync.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly SocialSyncDbContext _dbContext;

    private IUserRepository? _userRepository;
    private IPostRepository? _postRepository;
    private IInteractionRepository? _interactionRepository;
    private INotificationRepository? _notificationRepository;

    public UnitOfWork(SocialSyncDbContext dbContext) => _dbContext = dbContext;

    public IUserRepository UserRepository
    {
        get => _userRepository ??= new UserRepository(_dbContext);
    }

    public IPostRepository PostRepository
    {
        get => _postRepository ??= new PostRepository(_dbContext);
    }

    public IInteractionRepository InteractionRepository
    {
        get => _interactionRepository ??= new InteractionRepository(_dbContext);
    }

    public INotificationRepository NotificationRepository
    {
        get => _notificationRepository ??= new NotificationRepository(_dbContext);
    }

    public async Task<int> SaveAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _dbContext.Dispose();
        GC.SuppressFinalize(this);
    }
}
