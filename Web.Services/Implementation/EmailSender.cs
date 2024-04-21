using MailKit.Net.Smtp;
using MimeKit;
using Web.Common.Email;
using Web.Common.Logging;
using Web.DTOs.Email;
using Web.Services.Interfaces;

namespace Web.Services.Implementation
{
    public class EmailSender: IEmailSender
    {
        private readonly EmailSettings _mailSettings;

        public EmailSender(EmailSettings emailConfig)
        {
            _mailSettings = emailConfig;
        }


        public async Task<bool> SendMailAsync(EmailModel sendEmailModel)
        {
            try
            {
                using (MimeMessage emailMessage = new MimeMessage())
                {
                    MailboxAddress emailFrom = new MailboxAddress(_mailSettings.FromEmail, _mailSettings.Username);
                    emailMessage.From.Add(emailFrom);
                    MailboxAddress emailTo = new MailboxAddress(sendEmailModel.UserName, sendEmailModel.UserEmail);
                    emailMessage.To.Add(emailTo);

                    // you can add the CCs and BCCs here.
                    //emailMessage.Cc.Add(new MailboxAddress("Cc Receiver", "cc@example.com"));
                    //emailMessage.Bcc.Add(new MailboxAddress("Bcc Receiver", "bcc@example.com"));

                    emailMessage.Subject = sendEmailModel.EmailSubject;

                    BodyBuilder emailBodyBuilder = new BodyBuilder();
                    emailBodyBuilder.HtmlBody = sendEmailModel.EmailBody;

                    emailMessage.Body = emailBodyBuilder.ToMessageBody();

                    //this is the SmtpClient from the Mailkit.Net.Smtp namespace, not the System.Net.Mail one
                    using (SmtpClient mailClient = new SmtpClient())
                    {
                        await mailClient.ConnectAsync(_mailSettings.Host, _mailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
                        await mailClient.AuthenticateAsync(_mailSettings.Username, _mailSettings.Password);
                        await mailClient.SendAsync(emailMessage);
                        await mailClient.DisconnectAsync(true);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                WebLogging.LogException(ex.Message);
                return false;
            }
        }

        public string GenerateWelcomeEmail(string recipientName, string confirmEmailLink)
        {
            string emailBody = $@"
          <html>
            <body>
                <h2>Welcome to Web - Confirm Your Email Address</h2>
                <p>Dear {recipientName},</p>
                <p>Welcome to Web! We're thrilled to have you as a member of our community. Before you can start enjoying all the benefits of your new account, we need to verify your email address.</p>
                <p>Please take a moment to confirm your email address by clicking the button below:</p>
                <a href='{confirmEmailLink}' style='display: inline-block; padding: 10px 20px; background-color: #007bff; color: #fff; text-decoration: none;'>Confirm Email</a>
                <p>If you did not create an account with Web, please disregard this message.</p>
                <p>Best regards,</p>
                <p>Web</p>
            </body>
          </html>";

            return emailBody;
        }
    }
}
