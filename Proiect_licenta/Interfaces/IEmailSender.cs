using Proiect_licenta.DTO;
using System.Threading.Tasks;

namespace Proiect_licenta.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(EmailMessage message, string username);
        Task SendHtmlEmailAsync(EmailMessage message, string username);
    }
}
