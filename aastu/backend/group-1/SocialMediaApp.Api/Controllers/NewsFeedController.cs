using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Application.DTOs.Comments;
using SocialMediaApp.Application.DTOs.Likes;
using SocialMediaApp.Application.DTOs.Posts;
using SocialMediaApp.Application.Features.Comments.Request.Queries;
using SocialMediaApp.Application.Features.Follows.Request.Queries;
using SocialMediaApp.Application.Features.Likes.Request.Queries;
using SocialMediaApp.Application.Features.Posts.Request.Queries;
using SocialMediaApp.Domain;
using System.Diagnostics.Metrics;
using System.Security.Claims;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialMediaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NewsFeedController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _contextAccessor;

        public NewsFeedController(IMediator mediator, IHttpContextAccessor httpContextAccessor )
        {
            _mediator = mediator;
            _contextAccessor = httpContextAccessor;
        }



        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<List<PostListDto>>> GetNewsFeedItemRequest()
        {
            var Id = _contextAccessor.HttpContext!.User.FindFirstValue("uid");
            var newsFeedItems = new List<PostListDto>();
            var userFollowings = await _mediator.Send(new GetFollowingRequest { userId = new Guid(Id) });

            foreach (var follower in userFollowings)
            {
                var posts = await _mediator.Send(new GetPostsRequestByUser { UserId = follower.ToBeFollowed });
                foreach(var post in posts)
                {
                    var likes = await _mediator.Send(new GetLikesRequest { PostId = post.Id });
                    var comments = await _mediator.Send(new GetCommentListRequest { Id = post.Id });
                    var newsFeedItem = new PostListDto
                    {
                        Id = post.Id,
                        HashTag = post.HashTag,
                        Title = post.Title,
                        Content = post.Content,
                        Likes = likes.Count(),
                        CreatedDate = post.CreatedDate,
                        Comments = comments.Select(c => c.Text).ToList(),
                        UserId = post.UserId
                    };
                    newsFeedItems.Add(newsFeedItem);

                }
            }
            if(newsFeedItems.Count > 0)
            {
                newsFeedItems.OrderByDescending(news => news.CreatedDate);
            }

            return Ok(newsFeedItems);
        }

        
      

    }
}
