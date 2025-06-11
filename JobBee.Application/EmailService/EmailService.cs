using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;
using static System.Net.Mime.MediaTypeNames;
using System.Security.Principal;

namespace JobBee.Application.EmailService
{
	public class EmailService : IEmailService
	{
		private readonly IConfiguration _configuration;

		public EmailService(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public async Task SendEmail(string receptor, string subject, string body)
		{
			var email = _configuration.GetValue<string>("EMAIL_CONFIGURATION:EMAIL");
			var password = _configuration.GetValue<string>("EMAIL_CONFIGURATION:PASSWORD");
			var host = _configuration.GetValue<string>("EMAIL_CONFIGURATION:HOST");
			var port = _configuration.GetValue<int>("EMAIL_CONFIGURATION:PORT");

			var smtpClient = new SmtpClient(host, port);
			smtpClient.EnableSsl = true;
			smtpClient.UseDefaultCredentials = false;

			smtpClient.Credentials = new NetworkCredential(email, password);

			var message = new MailMessage(email!, receptor, subject, body);
			await smtpClient.SendMailAsync(message);
		}

		public async Task SendEmailPassword(string receptor, string subject, string url)
		{
			var email = _configuration.GetValue<string>("EMAIL_CONFIGURATION:EMAIL");
			var password = _configuration.GetValue<string>("EMAIL_CONFIGURATION:PASSWORD");
			var host = _configuration.GetValue<string>("EMAIL_CONFIGURATION:HOST");
			var port = _configuration.GetValue<int>("EMAIL_CONFIGURATION:PORT");

			var bodyHtml = $@"<div style='font-family: Segoe UI, sans-serif; max-width: 600px; margin: 0 auto; padding: 24px; background-color: #ffffff; color: #333333; border: 1px solid #e5e7eb; border-radius: 10px; box-shadow: 0 4px 12px rgba(0, 0, 0, 0.05);'>
    <h2 style='color: #111827; margin-bottom: 16px;'>Reset Your <span style='color: #2563eb;'>JobBee</span> Password</h2>
    <p style='font-size: 16px; line-height: 1.6; margin-bottom: 24px;'>
        We received a request to reset the password for your JobBee account. Click the button below to set a new password. If you didn’t request this, you can safely ignore this email.
    </p>
    <div style='text-align: center; margin: 30px 0;'>
        <a href='{url}' target='_blank'
           style='display: inline-block;
                  font-size: 16px;
                  font-weight: 600;
                  letter-spacing: 0.5px;
                  color: #ffffff;
                  text-decoration: none;
                  background: linear-gradient(135deg, #2563eb, #1d4ed8);
                  padding: 14px 28px;
                  border-radius: 8px;
                  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.15);
                  transition: transform 0.2s ease;'
           onmouseover='this.style.transform=\""scale(1.05)\""'
           onmouseout='this.style.transform=\""scale(1)\""' >
        Reset Password
        </a>
    </div>
    <p style='font-size: 14px; color: #6b7280; margin-bottom: 8px;'>
        This link will expire in 24 hours for your security.
    </p>
    <p style='font-size: 14px; color: #6b7280;'>
        — The JobBee Team
    </p>
</div>";

			var smtpClient = new SmtpClient(host, port);
			smtpClient.EnableSsl = true;
			smtpClient.UseDefaultCredentials = false;
			smtpClient.Credentials = new NetworkCredential(email, password);

			var message = new MailMessage
			{
				From = new MailAddress(email!),
				Subject = subject,
				Body = bodyHtml,
				IsBodyHtml = true
			};

			message.To.Add(receptor);
			message.BodyEncoding = System.Text.Encoding.UTF8;
			message.SubjectEncoding = System.Text.Encoding.UTF8;

			try
			{
				await smtpClient.SendMailAsync(message);
			}
			finally
			{
				message.Dispose();
				smtpClient.Dispose();
			}

		}

		public async Task SendEmailVerification(string receptor, string subject, string url)
		{
			var email = _configuration.GetValue<string>("EMAIL_CONFIGURATION:EMAIL");
			var password = _configuration.GetValue<string>("EMAIL_CONFIGURATION:PASSWORD");
			var host = _configuration.GetValue<string>("EMAIL_CONFIGURATION:HOST");
			var port = _configuration.GetValue<int>("EMAIL_CONFIGURATION:PORT");

			var bodyHtml = $@"<div style='font-family: Segoe UI, sans-serif; max-width: 600px; margin: 0 auto; padding: 24px; background-color: #ffffff; color: #333333; border: 1px solid #e5e7eb; border-radius: 10px; box-shadow: 0 4px 12px rgba(0, 0, 0, 0.05);'>
    <h2 style='color: #111827; margin-bottom: 16px;'>Welcome to <span style='color: #2563eb;'>JobBee</span>!</h2>
    <p style='font-size: 16px; line-height: 1.6; margin-bottom: 24px;'>
        Thank you for signing up with JobBee. Please verify your email address to complete your registration and start applying for jobs tailored just for you.
    </p>
    <div style='text-align: center; margin: 30px 0;'>
        <a href='{url}' target='_blank'
           style='display: inline-block;
                  font-size: 16px;
                  font-weight: 600;
                  letter-spacing: 0.5px;
                  color: #ffffff;
                  text-decoration: none;
                  background: linear-gradient(135deg, #2563eb, #1d4ed8);
                  padding: 14px 28px;
                  border-radius: 8px;
                  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.15);
                  transition: transform 0.2s ease;'
           onmouseover='this.style.transform=\""scale(1.05)\""'
           onmouseout='this.style.transform=\""scale(1)\""'>
            Verify Email
        </a>
    </div>
    <p style='font-size: 14px; color: #6b7280; margin-bottom: 8px;'>
        If you didn’t sign up for a JobBee account, you can safely ignore this email.
    </p>
    <p style='font-size: 14px; color: #6b7280;'>
        — The JobBee Team
    </p>
</div>";


			var smtpClient = new SmtpClient(host, port);
			smtpClient.EnableSsl = true;
			smtpClient.UseDefaultCredentials = false;
			smtpClient.Credentials = new NetworkCredential(email, password);

			var message = new MailMessage
			{
				From = new MailAddress(email!),
				Subject = subject,
				Body = bodyHtml,
				IsBodyHtml = true
			};

			message.To.Add(receptor);
			message.BodyEncoding = System.Text.Encoding.UTF8;
			message.SubjectEncoding = System.Text.Encoding.UTF8;

			try
			{
				await smtpClient.SendMailAsync(message);
			}
			finally
			{
				message.Dispose();
				smtpClient.Dispose();
			}
		}
	}
}
