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
        public async Task<Post> Get(int id)
        {
            var result = await _dbContext.Posts
                    .Include(x => x.Comments)
                    .Include(x => x.PostReactions)
                    .Where(x => x.Id == id)
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


        public Task<List<Post>> GetAll(int userd)
        {
            var result =  _dbContext.Posts
                                    .Where(x => x.UserId == userd).ToList();
            return Task.FromResult(result);
        }

        public  Task<List<Post>> GetByTagName(string tagName)
        {
            var result = _dbContext.Posts
                                    .Where(x => x.PostTags.Any(x => x.Tag.Title == tagName)).ToList();
            return Task.FromResult(result);
        }

        public async Task<List<Post>> GetFeed(int UserId)
        {
            int pageSize = 2; 
            int pageNumber = 1;
            var user = await _dbContext.Users
                .Include(x => x.Followee)
                .Include(x => x.Follower)
                .FirstOrDefaultAsync(u => u.Id == UserId);
            

            if (user != null)
            {
                 var followeeIds = user.Follower.Select(f => f.FolloweeId).ToList();
                return _dbContext.Posts.Where(p => followeeIds.Contains(p.UserId)).Skip((pageNumber - 1 ) * pageSize).Take(pageSize).ToList();
            }
            
            else
            {
                return new List<Post>();
            }
        }



    }
}
