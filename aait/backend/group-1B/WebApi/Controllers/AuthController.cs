using Application.DTOs.Auth;
using Application.DTOS.Auth;
using Application.Features.Auth.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // POST api/<AuthController>/Register
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
        {
            int createdId = await _mediator.Send(new RegisterUserRequest() { registerRequest = request });

            return Ok(createdId);
        }

        // PUT api/<AuthController>/Login
        [HttpPost("Login")]
        public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginRequestDto request)
        {
            var response = await _mediator.Send(new LoginUserRequest() { loginRequest = request });

            return Ok(response);
        }
    }
}
