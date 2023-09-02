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
    [Route("User/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserResponseDTO>>> Get()
        {
            var result = await _mediator.Send(new GetAllUsersQuery());
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponseDTO>> Get(int id)
        {
            var result = await _mediator.Send(new GetSingleUserQuery { userId = id });

            return result;
        }


        
        [HttpPut("")]
        [Authorize]
        public async Task<ActionResult<UserResponseDTO>> Put(int id, [FromBody] UserUpdateDTO UpdateUserData)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = await _mediator.Send(new UpdateUserCommand { userId = userId, UserUpdateData = UpdateUserData});
            return Ok(result);
        }



        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<BaseResponse<string>>> Delete(int id)
        {
            var userId =  int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var result = await _mediator.Send(new DeleteUserCommand { userId = id});
            return Ok(result);
        }
    }
}
