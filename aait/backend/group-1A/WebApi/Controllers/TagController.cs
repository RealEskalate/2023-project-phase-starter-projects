using Application.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialSync.Application.DTO;
using SocialSync.Application.Features.Requests;

namespace SocialSync.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TagController : ControllerBase{

    private readonly IMediator _mediator;
    public TagController(IMediator mediator)
    {
        _mediator = mediator;
        
    }

    [HttpPost]
    public async Task<ActionResult<BaseResponse<string>>> Post(CreateTagCommand command){

        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<BaseResponse<List<TagResponseDto>>>> Get(){
        var result = await _mediator.Send(new GetAllTagsRequest());
        return Ok(result);
    }

}