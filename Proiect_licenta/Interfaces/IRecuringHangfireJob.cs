using System.Threading.Tasks;

namespace Disertatie_backend.Interfaces
{
    public interface IRecuringHangfireJob
    {
        Task SendRecomandationsEmails();
    }
}
