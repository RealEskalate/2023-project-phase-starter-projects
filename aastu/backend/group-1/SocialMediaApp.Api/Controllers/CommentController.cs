using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Microsoft.Extensions.Hosting;
using SocialMediaApp.Application.DTOs.Comments;
using SocialMediaApp.Application.DTOs.Notifications;
using SocialMediaApp.Application.DTOs.Views;
using SocialMediaApp.Application.Features.Comments.Request.Commands;
using SocialMediaApp.Application.Features.Comments.Request.Queries;
using SocialMediaApp.Application.Features.Notifications.Request.Commands;
using SocialMediaApp.Application.Features.Notifications.Request.Queries;
using SocialMediaApp.Application.Features.Posts.Request.Queries;
using SocialMediaApp.Application.Features.Users.Request.Queries;
using SocialMediaApp.Domain;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialMediaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentController : ControllerBase
    {
        public IMediator _mediator { get; }
        private readonly IHttpContextAccessor _contextAccessor;

        public CommentController(IMediator mediator, IHttpContextAccessor contextAccessor)
        {
            _mediator = mediator;
            _contextAccessor = contextAccessor;
        }


        // GET: api/<CommentController>
        [HttpGet]
        public async Task<ActionResult<List<CommentDto>>> Get(Guid postId)
        {

            var query = new GetCommentListRequest { Id = postId };
            var comments = await _mediator.Send(query);
            return Ok(comments);
        }

        // GET api/<CommentController>/5
        [HttpGet("GetComment/{id:Guid}")]
        public async Task<ActionResult<CommentDto>> GetComment(Guid id)
        {
            var query = new GetCommentDetailRequest { Id = id };
            var comment = await _mediator.Send(query);
            return Ok(comment);
        }

        // POST api/<CommentController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateCommentView comment)
        {
            var Id = _contextAccessor.HttpContext!.User.FindFirstValue("uid");

            CreateCommentDto commentDto = new CreateCommentDto()
            {
                UserId = new Guid(Id),
                PostId = comment.PostId,
                Text = comment.Text
            };
            var command = new CreateCommentRequest { creatCommentDto = commentDto };
            var response = await _mediator.Send(command);
            if (response.Success == true)
            {
                var notificationDto = new CreateNotificationDto();
                var user = await _mediator.Send(new GetUserRequest { Id = commentDto.UserId});
                var post = await _mediator.Send(new GetPostRequestById { Id = commentDto.PostId, UserID = user.Id });

                notificationDto.UserId = post.UserId;
                notificationDto.Content = $"{user.Name} commented on your {post.Title} post";
                notificationDto.IsRead = false;

                var notificationCommand = new CreateNotificationRequest { CreateNotificationDto = notificationDto };
                await _mediator.Send(notificationCommand);
            }
            return Ok(response);
        }

        // PUT api/<CommentController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateCommentView comment)
        {
            var Id = _contextAccessor.HttpContext!.User.FindFirstValue("uid");
            UpdateCommentDto updateCommentDto = new UpdateCommentDto()
            {
                UserId = new Guid(Id),
                PostId = comment.PostId,
                Text = comment.Text,
                Id = comment.CommentId
            };

            var command = new UpdateCommentRequest { updatedCommentDto = updateCommentDto };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<CommentController>/5
        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            var userId = _contextAccessor.HttpContext!.User.FindFirstValue("uid");

            var command = new DeleteCommentRequest { UserId= new Guid(userId), Id = id};
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
