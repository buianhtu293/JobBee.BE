using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Contracts.Email;
using JobBee.Application.Models.Email;
using Microsoft.Extensions.Options;
using SendGrid.Helpers.Mail;
using SendGrid;

namespace JobBee.Infrastructure.EmailService
{
	public class EmailSender : IEmailSender
	{
		public EmailSettings _emailSettings { get; }
		public EmailSender(IOptions<EmailSettings> emailSettings)
		{
			_emailSettings = emailSettings.Value;
		}
		public async Task<bool> SendEmail(EmailMessage email)
		{
			var client = new SendGridClient(_emailSettings.ApiKey);
			var to = new EmailAddress(email.To);
			var from = new EmailAddress
			{
				Email = _emailSettings.FromAddress,
				Name = _emailSettings.FromName
			};

			var message = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);
			var response = await client.SendEmailAsync(message);

			return response.IsSuccessStatusCode;
		}
	}
}
