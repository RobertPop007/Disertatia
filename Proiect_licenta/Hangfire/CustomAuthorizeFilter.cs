using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace Proiect_licenta.Hangfire
{
    public class CustomAuthorizeFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            return true;
        }
    }
}
