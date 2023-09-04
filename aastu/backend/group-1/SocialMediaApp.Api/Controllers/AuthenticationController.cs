using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Application.Authentication.Command.Register;
using SocialMediaApp.Application.Authentication.Common;
using SocialMediaApp.Application.Authentication.Query.Login;
using SocialMediaApp.Application.Features.Authentication;
using System.Data.Common;
using System.Collections.Generic;

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

            string authResult = await _mediator.Send(command);

            /* var authResponse = new AuthenticationResponse(
                 authResult.User.Id,
                 authResult.User.email,
                 authResult.User.Name,
                 authResult.Token);*/

            /*return authResult.Match(
            result => Ok(result),
            error => Problem(error));*/

            if (authResult == null)
            {
                throw new Exception();
            }
            return Ok(authResult);

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


        [HttpGet("verify-email")]
        public async Task<IActionResult> VerifyEmail(string token)
        {
            var command = new VerifyEmailCommand { Token = token }; // Create a command with the token
            var verificationResult = await _mediator.Send(command);

            /* return verificationResult.Match<IActionResult>(
                 result => Ok(result),    // Redirect to success page or message
                 error => Problem(error)   // Redirect to error page or display error message
             );*/


            if (verificationResult == null)
            {
                throw new Exception();
            }

            return Ok("Welcome to Social Media App " + verificationResult.User.Name + " use this Token to Authenticate: " + verificationResult.Token);
            //return Ok(verificationResult);
        }



    }
}
