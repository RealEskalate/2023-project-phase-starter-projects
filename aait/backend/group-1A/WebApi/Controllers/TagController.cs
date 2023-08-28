using MediatR;
using Microsoft.AspNetCore.Mvc;
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
    public IActionResult Post(CreateTagCommand command){

        var result = _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet]
    public IActionResult Get(GetAllTagsRequest request){
        var result = _mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id){
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id){
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id){
        return NoContent();
    }

}