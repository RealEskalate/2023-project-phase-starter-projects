using System.Security.Claims;
using Application.DTO.Common;
using Application.DTO.UserDTO.DTO;
using Application.Features.UserFeature.Requests.Commands;
using Application.Features.UserFeature.Requests.Queries;
using Application.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

    

        [HttpGet]
        public async Task<ActionResult<UserResponseDTO>> GetAllUsers()
        {
            var result = await _mediator.Send(new GetAllUsersQuery());

            return Ok(result);
        }

        [HttpGet("Profile")]
        public async Task<ActionResult<UserResponseDTO>> Get()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = await _mediator.Send(new GetSingleUserQuery { userId = userId });

            return Ok(result);
        }
        
    [HttpPut("EditProfile")]
        [Authorize]
        public async Task<ActionResult<UserResponseDTO>> EditProfile([FromBody] UserUpdateDTO UpdateUserData)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = await _mediator.Send(new UpdateUserCommand { userId = userId, UserUpdateData = UpdateUserData});
            return Ok(result);
        }

        [HttpPut("UpdatePassword")]
        [Authorize]
        public async Task<ActionResult<BaseResponse<UpdatePasswordDTO>>> UpdatePassword([FromBody] UpdatePasswordDTO updatePasswordDTO)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = await _mediator.Send(new UpdatePasswordCommand { UserId = userId, UpdatePasswordDTO = updatePasswordDTO});
            return Ok(result);
        }



        [HttpDelete()]
        [Authorize]
        public async Task<ActionResult<BaseResponse<string>>> Delete()
        {
            var userId =  int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = await _mediator.Send(new DeleteUserCommand { userId = userId});
            return Ok(result);
        }
    }
}
