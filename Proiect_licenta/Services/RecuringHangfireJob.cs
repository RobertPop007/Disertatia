using Microsoft.EntityFrameworkCore;
using Proiect_licenta.DatabaseContext;
using Proiect_licenta.DTO;
using Proiect_licenta.EmailTemplates;
using Proiect_licenta.Interfaces;
using System.Threading.Tasks;

namespace Proiect_licenta.Services
{
    public class RecuringHangfireJob : IRecuringHangfireJob
    {
        private readonly DataContext _context;
        private readonly IEmailSender _emailSender;

        public RecuringHangfireJob(DataContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }
        public async Task SendRecomandationsEmails()
        {
            
            foreach(var user in _context.Users
                .Include(o => o.AppUserMovie)
                .Include(o => o.AppUserAnime)
                .Include(o => o.AppUserTvShow)
                .Include(o => o.AppUserManga)
                .Include(o => o.AppUserGame))
            {
                if(user.IsSubscribedToNewsletter == true)
                {
                    var mail_content = RecommandationEmailTemplate.GetEmailTemplate(user, _context);

                    var message = new EmailMessage(new string[] { user.Email }, "Daily recommandations", mail_content);
                    await _emailSender.SendHtmlEmailAsync(message, user.UserName);
                }
            }
        }
    }
}
