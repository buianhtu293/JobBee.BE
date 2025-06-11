using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Application.EmailService
{
	public interface IEmailService
	{
		Task SendEmail(string receptor, string subject, string body);
		Task SendEmailVerification(string receptor, string subject, string url);
		Task SendEmailPassword(string receptor, string subject, string url);
	}
}
