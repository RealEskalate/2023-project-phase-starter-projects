using Application.Features.User.Request.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.DTO.UserDTO;
using Application.Features.User.Request.Queries;
using Application.Model;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{notifications}")]
        public async Task<IActionResult> GetNotification(){
            var command = new GetNotifications(){Id = int.Parse(User.FindFirst("reader").Value)};
            var notifcations = await _mediator.Send(command);
            return Ok(notifcations);
        }


        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetProfile( int UserId)
        {
            var command = new GetUserProfile() { Id = UserId };
            var token = await _mediator.Send(command);
            return Ok(token);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetUsers( )
        {
            var command = new GetUsers();
            var token = await _mediator.Send(command);
            return Ok(token);
        }
    }
}
