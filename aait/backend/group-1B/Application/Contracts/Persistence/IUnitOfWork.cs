namespace Application.Contracts.Persistence;

public interface IUnitOfWork : IDisposable
{ 
    IUserRepository UserRepository{ get; }
    IPostRepository PostRepository{ get;  }
    ICommentRepository CommentRepository{ get;  }
    IPostTagRepository PostTagRepository { get; }
    IPostLikesRepository PostLikesRepository { get;  }
    Task Save();
}