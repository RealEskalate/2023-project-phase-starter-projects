using Application.DTOs.Users;
using Application.features.Users.Request.command;
using Application.Features.Users.Request;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<UserController>/follow/5 ? followers = true
        [HttpGet("/follow/{id}")]
        public async Task<ActionResult<List<UserListDto>>> GetUsers(int id, [FromQuery] bool followers = false)
        {
            if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))

                return Unauthorized();

            return Ok(await _mediator.Send(new GetUsersRequest { Id = id, getFollowers = followers }));
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDetail>> GetUserDetail(int id)
        {
            if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))

                return Unauthorized();

            return await _mediator.Send(new GetUserDetailRequest { Id = id });
        }

        // POST api/<UserController>
        [HttpPost("/follow")]
        public async Task<ActionResult> Follow(FollowDto follow)
        {
            if (follow.FollowerId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var response = await _mediator.Send(new FollowUserRequest { followDto = follow });

            return Ok(response);
        }

        //POST api/<UserController>/unfollow
        [HttpPost("/unfollow")]
        public async Task<ActionResult> UnFollow(FollowDto follow)
        {
            if (follow.FollowerId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var response = await _mediator.Send(new UnfollowUserRequest { followDto = follow });

            return Ok(response);
        }

        // PUT api/<UserController>
        [HttpPut]
        public async Task<ActionResult> UpdateUser(UpdateUserDto updateDto)
        {
            if (updateDto.Id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var response = await _mediator.Send(new UpdateUserRequest { UpdateUserDto = updateDto });

            return Ok(response);
        }
    }
}
