using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
namespace LandingEstudioJuridico.Services
{


    public interface IEmailService
    {
        // Agregamos el parámetro replyTo como opcional (puede ser null)
        Task SendEmailAsync(string toEmail, string subject, string message, string? replyTo = null);
    }

    public class EmailSettings
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string ReceiverEmail { get; set; }
    }

    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        // Inyectamos la configuración usando IOptions (Patrón Options)
        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string messageBody, string? replyTo = null)
        {
            var email = new MimeMessage();

            // 1. El remitente SIEMPRE es tu aplicación (para evitar bloqueos)
            email.From.Add(new MailboxAddress(_emailSettings.SenderName, _emailSettings.SenderEmail));

            // 2. El destinatario (en este caso, sos vos mismo, pero lo pasamos por parámetro)
            email.To.Add(MailboxAddress.Parse(toEmail));

            // 3. CLAVE: Si hay un replyTo (el visitante), lo agregamos aquí
            if (!string.IsNullOrEmpty(replyTo))
            {
                email.ReplyTo.Add(MailboxAddress.Parse(replyTo));
            }

            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = messageBody };

            using var smtp = new SmtpClient();
            try
            {
                await smtp.ConnectAsync(_emailSettings.Server, _emailSettings.Port, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(_emailSettings.Username, _emailSettings.Password);
                await smtp.SendAsync(email);
            }
            catch (Exception ex)
            {
                // Loguear error...
                throw;
            }
            finally
            {
                await smtp.DisconnectAsync(true);
            }
        }
    }
}


