namespace Application.Contracts.Persistance;

public interface IUnitOfWork : IDisposable
{ 
    IUserRepository userRepository{ get; }
    IPostRepository postRepository{ get;  }
    ICommentRepository commentRepository{ get;  }
    IFollowRepository followRepository{ get;  }
    ILikeRepository likeRepository{ get;  }
    Task<int> Save();

}