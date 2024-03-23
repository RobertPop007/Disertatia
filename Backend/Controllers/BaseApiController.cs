using Microsoft.AspNetCore.Mvc;
using Backend.Helpers;

namespace Backend.Controllers;

[ServiceFilter(typeof(LogUserActivity))]
[ApiController]
[Route("api/[controller]")]
public class BaseApiController : ControllerBase
{
}
