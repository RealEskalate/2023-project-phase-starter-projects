using Application.Contracts;
using AutoMapper;
using Persistence.Repositories.CommentRespositories;
using Persistence.Repositories.ReactionRespositories;
using SocialSync.Application.Contracts;
using SocialSync.Persistence.Repositories.Auth;
using SocialSync.Persistnece.Repositories;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SocialMediaDbContext _dbContext;
        private readonly IMapper _mapper;
        private IAuthRepository _authRepository;
        private ICommentRepository _commentRepository;
        private ICommentReactionRepository _commentReactionRepository;
        private IFollowRepository _followRepository;
        private INotificationRepository _notificationRepository;
        private ITagRepository _tagRepository;
        private IPostRepository _postRepository;
        private IPostReactionRepository _postReactionRepository;

        private IPostTagRepository _postTagRepository;

        private IUserRepository _userRepositoy;
        public UnitOfWork(SocialMediaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public IAuthRepository AuthRepository {
            get{
                if (_authRepository == null){
                    _authRepository = new AuthRepository(_dbContext);
                }
                return _authRepository;
            }
        }

        public ICommentRepository CommentRepository {
            get{
                if (_commentRepository == null){
                    _commentRepository = new CommentRepository(_dbContext,_mapper);
                }
                return _commentRepository;
            }
        }

        public ICommentReactionRepository CommentReactionRepository {
            get{
                if (_commentReactionRepository == null){
                    _commentReactionRepository = new CommentReactionRepository(_dbContext);
                }
                return _commentReactionRepository;
            }
        }

        public IFollowRepository FollowRepository {
            get{
                if (_followRepository == null){
                    _followRepository = new FollowRepository(_dbContext);
                }
                return _followRepository;
            }
        }

        public INotificationRepository NotificationRepository {
            get{
                if (_notificationRepository == null){
                    _notificationRepository = new NotificationRepository(_dbContext);
                };
                return _notificationRepository;
            }
        }

        public ITagRepository TagRepository {
            get{
                if (_tagRepository == null){
                    _tagRepository = new TagReposiotry(_dbContext);

                }
                return _tagRepository;
            }
        }

        public IPostRepository PostRepository {
            get{
                if (_postRepository == null){
                    _postRepository = new PostRepository(_dbContext, _mapper);
                }

                return _postRepository;
            }
        }

        public IPostReactionRepository PostReactionRepository {
            get{
                if (_postReactionRepository == null)
                {
                    _postReactionRepository = new PostReactionRepository(_dbContext);
                }
                return _postReactionRepository;
            }
        }

        public IUserRepository UserRepository {
            get{
                if (_userRepositoy == null)
                {
                    _userRepositoy = new UserRepository(_dbContext);
                }
                return _userRepositoy;
            }
        }

        public IPostTagRepository PostTagRepository {
            get{
                if (_postTagRepository == null)
                {
                    _postTagRepository = new PostTagRepository(_dbContext);
                }
                return _postTagRepository;
            }
        }

        public void Dispose()
        {
             _dbContext.Dispose();
        GC.SuppressFinalize(this);
        }

        public async Task<int> Save()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}