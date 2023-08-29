using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Application.DTOs.Comments;
using SocialMediaApp.Application.DTOs.Likes;
using SocialMediaApp.Application.DTOs.Notifications;
using SocialMediaApp.Application.DTOs.Views;
using SocialMediaApp.Application.Features.Likes.Request.Commands;
using SocialMediaApp.Application.Features.Likes.Request.Queries;
using SocialMediaApp.Application.Features.Notifications.Request.Commands;
using SocialMediaApp.Application.Features.Posts.Request.Queries;
using SocialMediaApp.Application.Features.Users.Request.Queries;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialMediaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LikeController : ControllerBase
    {
        public readonly IMediator _mediator;
        private readonly IHttpContextAccessor _contextAccessor;
        public LikeController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            _contextAccessor = httpContextAccessor;
        }
        

        // GET api/<LikeController>/5
        [HttpGet("{PostId:Guid}")]
        public async Task<ActionResult<List<LikeDto>>> Get(Guid PostId)
        {
            var likes = await _mediator.Send(new GetLikesRequest { PostId = PostId });

            return Ok(likes);
        }

        // POST api/<LikeController>
        [HttpPost]
        public async Task<ActionResult<LikeDto>> Post([FromBody] CreateLikeView createLike)
        {

            var Id = _contextAccessor.HttpContext!.User.FindFirstValue("uid");
            CreateLikeDto likeDto = new CreateLikeDto()
            {
                PostId = createLike.PostId,
                UserId = new Guid(Id)
            };
            var command = new CreateLikeRequest { LikeDto = likeDto };
            var response = await _mediator.Send(command);
            if(response.Success == true)
            {
                var notificationDto = new CreateNotificationDto();
                var user = await _mediator.Send(new GetUserRequest { Id = likeDto.UserId });
                var post = await _mediator.Send(new GetPostRequestById { Id = likeDto.PostId, UserID = user.Id });

                notificationDto.UserId = post.UserId;
                notificationDto.Content = $"{user.Name} liked your {post.Title} post";
                notificationDto.IsRead = false;

                var notificationCommand = new CreateNotificationRequest { CreateNotificationDto = notificationDto };
                await _mediator.Send(notificationCommand);
            }

            return Ok(response);

        }
       

        // DELETE api/<LikeController>/5
        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> Unlike(Guid id)
        {
            // authenticate the user pls 
            var UserId = _contextAccessor.HttpContext!.User.FindFirstValue("uid");
            await _mediator.Send(new DeleteLikeRequest { LikeId = id, UserId = new Guid(UserId) });
            return NoContent();
        }
    }
}
