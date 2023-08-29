namespace Application.Contracts.Persistence;

public interface IUnitOfWork : IDisposable
{ 
    IUserRepository UserRepository{ get; }
    IPostRepository PostRepository{ get;  }
    ICommentRepository CommentRepository{ get;  }
    IPostTagRepository PostTagRepository { get; }
    IPostLikesRepository PostLikesRepository { get;  }
    INotificationRepository NotificationRepository { get; }
    // ITagRepository TagRepository{get;}
    Task Save();
}