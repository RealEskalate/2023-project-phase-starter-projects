using Microsoft.AspNetCore.Mvc;

namespace SocialSync.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TagController : ControllerBase{

    [HttpPost]
    public IActionResult Post(){
        return Ok();
    }

    [HttpGet]
    public IActionResult Get(){
        return Ok();
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