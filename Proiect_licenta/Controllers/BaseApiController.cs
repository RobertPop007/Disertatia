using Microsoft.AspNetCore.Mvc;
using Proiect_licenta.Helpers;

namespace Proiect_licenta.Controllers;

[ServiceFilter(typeof(LogUserActivity))]
[ApiController]
[Route("api/[controller]")]
public class BaseApiController : ControllerBase
{
}
