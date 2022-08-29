using Portafolio.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Portafolio.Services
{
    public interface IEmailService
    {
        Task Send(ContactViewModel contact);
    }

    public class EmailServiceSendGrid : IEmailService
    {
        private readonly IConfiguration configuration;

        public EmailServiceSendGrid(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task Send(ContactViewModel contact)
        {
            var apiKey = configuration.GetValue<string>("SENDGRID_API_KEY");
            var email = configuration.GetValue<string>("SENDGRID_FROM");
            var name = configuration.GetValue<string>("SENDGRID_NAME");

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(email, name);
            var subject = $"{contact.representativeName}({contact.companyName}) wants to contact you";
            var to = new EmailAddress(email, name);
            var plainTextContent = contact.message;
            var htmlContent = @$"From: {contact.representativeName}({contact.companyName}) -
                                Email: {contact.email} -
                                Message: {contact.message}";
            var message = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(message);
        }
    }
}
