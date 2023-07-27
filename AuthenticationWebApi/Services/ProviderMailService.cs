using MailKit.Net.Smtp;
using MimeKit;

namespace AuthenticationWebApi.Services
{
    public class ProviderMailService
    {
        private string message = "Your code: ";
        public async Task SendEmailAsync(string email, int code, string subject = "Email Confirmation")
        {
            message += code;

            using var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Spotty Motor", ""));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.mail.ru", 465, true);
                await client.AuthenticateAsync("my email :)", "my code :)");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}
