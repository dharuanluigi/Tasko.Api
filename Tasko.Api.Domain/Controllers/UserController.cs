using Microsoft.AspNetCore.Mvc;
using Tasko.Api.Domain.Attributes;

namespace Tasko.Api.Domain.Controllers
{
  [ApiController]
  [ApiKey]
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