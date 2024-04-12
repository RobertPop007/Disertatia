using Disertatie_backend.DatabaseContext;
using Disertatie_backend.DTO;
using Disertatie_backend.EmailTemplates;
using Disertatie_backend.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Disertatie_backend.Entities.User;

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
            var userList = _userManager.Users.ToList();
            foreach(var user in userList)
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
