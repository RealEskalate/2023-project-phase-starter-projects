

using SocialSync.Application.Contracts;

namespace Application.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthRepository AuthRepository{get;}
        ICommentRepository CommentRepository{get;}
        ICommentReactionRepository CommentReactionRepository{get;}
        IFollowRepository FollowRepository{get;}
        INotificationRepository NotificationRepository{get;}
        ITagRepository TagRepository{get;}
        IPostRepository PostRepository{get;}
        IPostReactionRepository PostReactionRepository{get;}
        IUserRepository UserRepository{get;}

        IPostTagRepository PostTagRepository{get;}
        Task<int> Save();
    }
}