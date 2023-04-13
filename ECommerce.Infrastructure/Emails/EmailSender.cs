using System.Threading.Tasks;
using ECommerce.Application.Configuration.Emails;

namespace ECommerce.Infrastructure.Emails
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(EmailMessage message)
        {
            // Integration with email service.

            return;
        }
    }
}