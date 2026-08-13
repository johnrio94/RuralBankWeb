using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace RuralBankWeb.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        public EmailService(IConfiguration config) => _config = config;

        public async Task SendContactFormEmailAsync(string fullName, string phone, string email, string message)
        {
            var smtpServer = _config["EmailSettings:SmtpServer"];
            var smtpPort = int.Parse(_config["EmailSettings:SmtpPort"] ?? "587");
            var senderEmail = _config["EmailSettings:SenderEmail"];
            var senderPassword = _config["EmailSettings:SenderPassword"];
            var receiverEmail = _config["EmailSettings:ReceiverEmail"];

            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress("Rural Bank Website", senderEmail));
            mimeMessage.To.Add(new MailboxAddress("Rural Bank Admin", receiverEmail));
            mimeMessage.ReplyTo.Add(new MailboxAddress(fullName, email));
            mimeMessage.Subject = $"New Contact Form Message from {fullName}";

            mimeMessage.Body = new TextPart("plain")
            {
                Text = $@"You received a new message from the website contact form.

Name: {fullName}
Phone: {phone}
Email: {email}

Message:
{message}
"
            };

            using var client = new SmtpClient();
            await client.ConnectAsync(smtpServer, smtpPort, SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(senderEmail, senderPassword);
            await client.SendAsync(mimeMessage);
            await client.DisconnectAsync(true);
        }
    }
}