using Application.Features.User.Request.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.DTO.UserDTO;
using Application.Features.User.Request.Queries;
using Application.Model;
using WebApi.Middleware;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> CreateUser( CreateUserDTO userDto)
        {
            var command = new CreateUserCommand { CreateUser = userDto };
            var userId = await _mediator.Send(command);
            
            return ResponseHandler<AuthResponse>.HandleResponse(userId, 201);
        }
        
        
        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser(AuthRequest userDto)
        {
            var command = new Login() { LogInDto = userDto };
            var token = await _mediator.Send(command);
            return ResponseHandler<AuthResponse>.HandleResponse(token, 200);
        }
        
       
    }
}