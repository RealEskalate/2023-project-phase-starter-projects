using Application.Contracts.Persistance;

namespace Persistence.Persistance.Repository;

public class UnitOfWork : IUnitOfWork{
    private readonly SocialSyncDbContext _context;
    private IUserRepository _userRepository;
    private IPostRepository _postRepository;
    private ICommentRepository _commentRepository;
    private IFollowRepository _followRepository;
    private ILikeRepository _likeRepository;
    private INotificationRepository _notificationRepository;

    public UnitOfWork(SocialSyncDbContext context){
        _context = context;
    }

    public IUserRepository userRepository => _userRepository ??= new UserRepository(_context);
    public ICommentRepository commentRepository => _commentRepository ??= new CommentRepository(_context);
    public IPostRepository postRepository => _postRepository ??= new PostRepository(_context);
    public IFollowRepository followRepository => _followRepository ??= new FollowRepository(_context);
    public ILikeRepository likeRepository => _likeRepository ??= new LikeRepository(_context);
    public INotificationRepository notificationRepository => _notificationRepository ??= new NotificationRepository(_context);

    public void Dispose(){
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task<int> Save(){
        return await _context.SaveChangesAsync();
    }
}