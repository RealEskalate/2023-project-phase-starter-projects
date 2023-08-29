using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Application.Authentication.Command.Register;
using SocialMediaApp.Application.Authentication.Common;
using SocialMediaApp.Application.Authentication.Query.Login;
using SocialMediaApp.Application.Features.Authentication;


namespace SocialMediaApp.Api.Controllers
{



    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController : ControllerBase
    {

        private readonly ISender _mediator;

        public AuthenticationController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = new RegisterCommand(request.Name, request.Email, request.Password);

            AuthenticationResult authResult = await _mediator.Send(command);
               
            var authResponse = new AuthenticationResponse(
                authResult.User.Id,
                authResult.User.email,
                authResult.User.Name,
                authResult.Token);
            return Ok(authResponse);
            
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = new LoginQuary(request.Email, request.Password);
            var authResult = await _mediator.Send(query);
            var authResponse = new AuthenticationResponse(
                authResult.User.Id,
                authResult.User.email,
                authResult.User.Name,
                authResult.Token);
            return Ok(authResponse);
        }
    }
}
