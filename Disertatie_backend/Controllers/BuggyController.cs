using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Disertatie_backend.Entities.User;

namespace Disertatie_backend.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        public BuggyController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "secret text";
        }

        [HttpGet("not-found")]
        public async Task<ActionResult<AppUser>> GetNotFound()
        {
            var thing = await _userManager.FindByIdAsync("-1");

            return thing == null ? NotFound() : thing;
        }

        [HttpGet("server-error")]
        public async Task<ActionResult<string>> GetServerError()
        {
            var thing = await _userManager.FindByIdAsync("-1");

            var thingToReturn = thing.ToString();

            return thingToReturn;
        }

        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest();
        }
    }
}
