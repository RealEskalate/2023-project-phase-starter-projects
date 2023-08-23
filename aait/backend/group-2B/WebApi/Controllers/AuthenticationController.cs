using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialSync.Application.DTOs.Authentication;

namespace SocialSync.WebApi.Controller;

[ApiController]
[Route("api/auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    #region Queries
    [HttpPost("register")]
    public async Task<ActionResult<LoggedInUserDto>> Register([FromBody] RegisterUserDto request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    #endregion
    #region Commands
    [HttpPost("login")]
    public async Task<ActionResult<LoggedInUserDto>> Login([FromBody] LoginUserDto request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
    #endregion
}
