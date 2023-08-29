using System.Linq.Expressions;
using System.Text.RegularExpressions;
using Application.Contracts;
using Application.DTO.PostDTO.DTO;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        private readonly SocialMediaDbContext _dbContext;
        private readonly IMapper _mapper;

        public PostRepository(SocialMediaDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public async Task<Post> Get(int id, int userId)
        {
            var result = await _dbContext.Posts
                    .Include(x => x.Comments)
                    .Include(x => x.PostReactions)
                    .Where(x => x.Id == id && x.UserId == userId)
                    .SingleOrDefaultAsync();
            return result;
        }

        public async Task<List<PostResponseDTO>> GetAllPostsWithReaction(int userId)
        {   
            var allPosts = await _dbContext.Posts
                    .Where(x => x.UserId == userId)
                    .Include(x => x.PostReactions)
                    .ToListAsync();

            var result = new List<PostResponseDTO> ();

            foreach (var post in allPosts)
            {
                var postResponse = _mapper.Map<PostResponseDTO>(post);
                postResponse.Like = post.PostReactions.Where(x => x.Like == true).Count();
                postResponse.Dislike = post.PostReactions.Where(x => x.Dislike == true).Count();
                result.Add(postResponse);
            }
            return result;
        }


        public async Task<bool> Exists(int id)
        {
            var result = await _dbContext.Posts.FindAsync(id);
            return result != null;
        }


        public async Task<List<Post>> GetAll(int userd)
        {
            var result =  _dbContext.Posts
                                    .Where(x => x.UserId == userd).ToList();
            return result;
        }


    }
}
