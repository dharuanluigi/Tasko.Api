using Microsoft.AspNetCore.Mvc;

namespace Tasko.Api.Domain.Controllers
{
  [ApiController]
  [Route("api/v1/[controller]")]
  public class UserController : ControllerBase
  {
    [HttpGet("{v1:int}/{v2:int}")]
    public IActionResult Get([FromRoute] int v1, [FromRoute] int v2)
    {
      if (v1 == 2)
      {
        var a = "abs";
        var total = int.Parse(a) + 10;
        return Ok(total);
      }

      return Ok(10);
    }
  }
}