using System.Security.Claims;
using Application.DTO.NotificationDTO;
using Application.Features.NotificationFeaure.Requests.Commands;
using Application.Features.NotificationFeaure.Requests.Queries;
using Application.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("notification/")]
    public class NotificationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public NotificationController(IMediator mediator)
        {
            _mediator = mediator;
        }   

        [HttpGet("all")]
        [Authorize]
        public async Task<ActionResult<BaseResponse<List<NotificationResponseDTO>>>> GetALL(){
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = await _mediator.Send(new GetAllNotificationsQuery { UserId = userId});
            return Ok(result);
        }

        [HttpGet("unread")]
        [Authorize]
        public async Task<ActionResult<List<BaseResponse<NotificationResponseDTO>>>> GetALLUnread(){
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = await _mediator.Send(new GetUnreadNotification { UserId = userId});
            return Ok(result);
        }

        [HttpGet("/{id}")]
        [Authorize]
        public async Task<ActionResult<BaseResponse<List<NotificationResponseDTO>>>> Get(int id){
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = await _mediator.Send(new GetSingleNotification { NotificationId = id});
            return Ok(result);
        }

        [HttpPost("mark-all-read")]
        [Authorize]
        public async Task<ActionResult<BaseResponse<List<NotificationResponseDTO>>>> MarkAllRead(){
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = await _mediator.Send(new MarkReadAllRequest {UserId = userId});
            return Ok(result);
        }

        [HttpPost("mark-read/{id}")]
        [Authorize]
        public async Task<ActionResult<BaseResponse<List<NotificationResponseDTO>>>> MarkRead(int id){
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = await _mediator.Send(new MarkAsReadCommand {UserId = userId, NotificationId = id});
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        [Authorize]
        public async Task<ActionResult<BaseResponse<List<NotificationResponseDTO>>>> Delete(int id){
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = await _mediator.Send(new DeleteNotification { UserId = userId, NotificationId = id});
            return Ok(result);
        }

    }
}