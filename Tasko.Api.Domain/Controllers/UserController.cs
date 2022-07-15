using Microsoft.AspNetCore.Mvc;

namespace Tasko.Api.Domain.Controllers
{
  [ApiController]
  [Route("api/v1/[controller]")]
  public class UserController : ControllerBase
  {
    [HttpGet]
    public IActionResult Get()
    {
      return Ok(10);
    }
  }
}