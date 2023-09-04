using Application.Contracts.Persistence;

namespace Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly SocialSyncDbContext _context;
    private IUserRepository _userRepository;
    private IPostRepository _postRepository;
    private ICommentRepository _commentRepository;
    private IPostTagRepository _postTagRepository;
    private IPostLikesRepository _postLikesRepository;
    private INotificationRepository _notificationRepository;
    private ITagRepository _tagRepository;

    public UnitOfWork(SocialSyncDbContext context)
    {
        _context = context;
    }

    public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);
    public ICommentRepository CommentRepository => _commentRepository ??= new CommentRepository(_context);
    public IPostRepository PostRepository => _postRepository ??= new PostRepository(_context);
    public IPostTagRepository PostTagRepository => _postTagRepository ??= new PostTagRepository(_context);
    public IPostLikesRepository PostLikesRepository => _postLikesRepository ??= new PostLikesRepository(_context);
    // public ITagRepository TagRepository => _tagRepository ??= new TagRepository(_context);

    public INotificationRepository NotificationRepository =>
        _notificationRepository ??= new NotificationRepository(_context);
    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}