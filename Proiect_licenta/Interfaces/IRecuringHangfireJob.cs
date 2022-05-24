using System.Threading.Tasks;

namespace Proiect_licenta.Interfaces
{
    public interface IRecuringHangfireJob
    {
        Task SendRecomandationsEmails();
    }
}
