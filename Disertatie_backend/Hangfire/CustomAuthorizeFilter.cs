using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace Disertatie_backend.Hangfire
{
    public class CustomAuthorizeFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            return true;
        }
    }
}
