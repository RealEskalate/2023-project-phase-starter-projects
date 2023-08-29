using System.Linq;
using System.Linq.Expressions;
using Application.Contracts;
using Application.DTO.CommentDTO.DTO;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories.CommentRespositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        private readonly SocialMediaDbContext _dbContext;
        private readonly IMapper _mapper;

        public CommentRepository(SocialMediaDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Comment> Get(int id)
        {
            var result = await _dbContext.Comments
                            .Include(x => x.CommentReactions)
                            .Where(x => x.Id == id)
                            .SingleOrDefaultAsync();
            return result;
        }

        public async Task<List<CommentResponseDTO>> GetAllCommentsWithReaction(int userId)
        {
            var allComments = await _dbContext.Comments
                    .Include(x => x.CommentReactions)
                    .Where(x => x.UserId == userId)
                    .ToListAsync();

            var result = new List<CommentResponseDTO> ();

            foreach (var comment in allComments)
            {
                var commentResponse = _mapper.Map<CommentResponseDTO>(comment);
                commentResponse.Like = comment.CommentReactions.Where(x => x.Like == true).Count();
                commentResponse.Like = comment.CommentReactions.Where(x => x.Dislike == true).Count();
                result.Add(commentResponse);
            }
            return result;
        }

        public async Task<List<CommentResponseDTO>> GetByPostId(int postId)
        {
            var allComments = await _dbContext.Comments
                            .Include(x => x.CommentReactions)
                            .Where(x => x.PostId == postId)
                            .ToListAsync();

            var result = new List<CommentResponseDTO> ();

            foreach (var comment in allComments)
            {
                var commentResponse = _mapper.Map<CommentResponseDTO>(comment);
                commentResponse.Like = comment.CommentReactions.Where(x => x.Like == true).Count();
                commentResponse.Like = comment.CommentReactions.Where(x => x.Dislike == true).Count();
                result.Add(commentResponse);
            }
            return result;
        }


        public async Task<bool> Exists(int id)
        {
            var result = await _dbContext.Comments.FindAsync(id);
            return result != null;
        }

        public Task<List<Comment>> GetAll(int userId)
        {
            return _dbContext.Comments.Where(x => x.UserId == userId).ToListAsync();
        }
    }
}