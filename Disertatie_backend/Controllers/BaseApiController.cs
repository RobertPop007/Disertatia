using Microsoft.AspNetCore.Mvc;
using Disertatie_backend.Helpers;

namespace Disertatie_backend.Controllers
{
    [ServiceFilter(typeof(LogUserActivity))]
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {

    }
}
