using Application.DTO.NotificationDTO;
using Application.Features.User.Request.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.DTO.UserDTO;
using Application.Features.User.Request;
using Application.Features.User.Request.Queries;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using WebApi.Middleware;

namespace WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Notifications")]
        public async Task<IActionResult> GetNotification( [FromQuery] int? pageNumber, [FromQuery] int? pageSize){
            var command = new GetNotifications(){UserId  = int.Parse(User.FindFirst("reader")?.Value ?? "-1") };
            var notifications = await _mediator.Send(command);
            return ResponseHandler<List<Notification>>.HandleResponse(notifications, 200);
        }


        [HttpGet("{userId:int}")]
        public async Task<IActionResult> GetProfile( int userId)
        {
            var command = new GetUserProfile() { Id = userId };
            var token = await _mediator.Send(command);
            return ResponseHandler<UserProfileDTO>.HandleResponse(token, 200);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetUsers(  [FromQuery] int? pageNumber, [FromQuery] int? pageSize)
        {
            var command = new GetUsers{PageNumber = pageNumber ?? 0, PageSize = pageSize ?? 10};
            var token = await _mediator.Send(command);
            return ResponseHandler<List<UserDto>>.HandleResponse(token, 200);
        }

        [HttpGet("Search")]
        public async Task<IActionResult> SearchUsers([FromQuery] string name,  [FromQuery] int? pageNumber, [FromQuery] int? pageSize){
            var command = new SearchUsers{ Query = name, PageNumber = pageNumber ?? 0, PageSize = pageSize ?? 10 };
            var users = await _mediator.Send(command);
            return ResponseHandler<List<UserDto>>.HandleResponse(users, 200);
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateUserDTO updateUser)
        {   
            var userId = int.Parse(User.FindFirst("reader")?.Value ?? "-1");
            updateUser.Id = userId;
            var command = new UpdateUserCommand() { updateUser = updateUser };
            var token = await _mediator.Send(command);
            return ResponseHandler<Unit>.HandleResponse(token, 204);
        }

        [HttpPatch("Notifications/{id:int}")]
        public async Task<IActionResult> MarkNotificationAsRead(int id)
        {
            var userId = int.Parse(User.FindFirst("reader")?.Value ?? "-1");
            var updateDto = new UpdateNotificationDto() { UserId = userId, Id = id };
            var command = new MakeNotificationReadCommand() { UpdateDto = updateDto };
            var result = await _mediator.Send(command);
            return ResponseHandler<Unit?>.HandleResponse(result, 204);
        }
        
        [HttpGet("Notifications/{id:int}")]
        public async Task<IActionResult> GetASingleNotification (int id)
        {
            var command = new GetSingleNotificationRequest() { Id = id };
            var result = await _mediator.Send(command);
            return ResponseHandler<Notification>.HandleResponse(result, 200);
        }
    }
}
