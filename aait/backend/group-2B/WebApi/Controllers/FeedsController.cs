using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialSync.Application.Features.Feed.Requests.Queries;

namespace SocialSync.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FeedsController : ControllerBase
{
    private readonly IMediator _mediator;
    public FeedsController(IMediator mediator){
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetFeeds(int userID){
        var feedsRequest = new GetFeedsByUserIdRequest {UserID = userID};
        var response = await _mediator.Send(feedsRequest);

        if(response.IsSuccess){
            return Ok(response);
        }
        else{
            return BadRequest(response);
        }
    }
}
