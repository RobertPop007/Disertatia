using Microsoft.AspNetCore.Mvc.Filters;
using Disertatie_backend.Extensions;
using Disertatie_backend.Interfaces;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Disertatie_backend.Helpers
{
    public class LogUserActivity : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var resultContext = await next();

            if (!resultContext.HttpContext.User.Identity.IsAuthenticated) return;

            var userId = resultContext.HttpContext.User.GetUserId();
            var repo = resultContext.HttpContext.RequestServices.GetService<IUserRepository>();

            var user = await repo.GetUserByIdAsync(userId);

            if(user != null) user.LastActive = DateTime.Now;

            await repo.SaveAllAsync();
        }
    }
}
