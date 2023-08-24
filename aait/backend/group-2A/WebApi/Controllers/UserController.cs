using Application.Features.User.Request.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.DTO.UserDTO;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [ApiController]
    [AuthorizeSSSSSSSSSSSSSSSSSSSSSSSSSZ]
    [Route("api/[controller]")]
    
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> CreateUser(CreateUserDTO userDto)
        {
            var command = new CreateUserCommand { CreateUser = userDto };
            var userId = await _mediator.Send(command);

            return Ok(new { UserId = userId });
        }
    }
}
