using Disertatie_backend.DatabaseContext;
using Disertatie_backend.DTO;
using Disertatie_backend.EmailTemplates;
using Disertatie_backend.Interfaces;
using System.Threading.Tasks;
using Disertatie_backend.Entities;
using Microsoft.AspNetCore.Identity;

namespace Disertatie_backend.Services
{
    public class RecuringHangfireJob : IRecuringHangfireJob
    {
        private readonly DataContext _context;
        private readonly IEmailSender _emailSender;
        private readonly UserManager<AppUser> _userManager;

        public RecuringHangfireJob(DataContext context, IEmailSender emailSender, UserManager<AppUser> userManager)
        {
            _context = context;
            _emailSender = emailSender;
            _userManager = userManager;
        }
        public async Task SendRecomandationsEmails()
        {
            
            foreach(var user in _userManager.Users)
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
