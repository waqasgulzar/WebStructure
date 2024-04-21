using Web.DTOs.Email;

namespace Web.Services.Interfaces
{
    public interface IEmailSender
    {
        Task<bool> SendMailAsync(EmailModel sendEmailModel);
        public string GenerateWelcomeEmail(string recipientName, string confirmEmailLink);
    }
}
