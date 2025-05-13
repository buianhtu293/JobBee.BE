using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Models.Email;

namespace JobBee.Application.Contracts.Email
{
	public interface IEmailSender
	{
		Task<bool> SendEmail(EmailMessage email);
	}
}
