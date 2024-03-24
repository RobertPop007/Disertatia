using Disertatie_backend.DTO;
using System.Threading.Tasks;

namespace Disertatie_backend.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(EmailMessage message, string username);
        Task SendHtmlEmailAsync(EmailMessage message, string username);
    }
}
