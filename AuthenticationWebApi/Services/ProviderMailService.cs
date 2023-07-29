using AuthenticationWebApi.Models;
using MailKit.Net.Smtp;
using MimeKit;

namespace AuthenticationWebApi.Services
{
    public class ProviderMailService
    {
        private readonly EmailConfiguration _emailConfig = new();

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            using var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(_emailConfig.FromName, _emailConfig.FromAddress));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.SmtpPort, true);
                await client.AuthenticateAsync(_emailConfig.SmtpUsername, _emailConfig.SmtpPassword);
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}
