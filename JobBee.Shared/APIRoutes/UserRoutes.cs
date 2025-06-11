using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Shared.APIRoutes
{
	public class UserRoutes
	{
		public const string Index = "api/users";

		public static class ACTION
		{
			public const string GetListUsers = "list";
			public const string GetDetail = "{id}";
			public const string Register = "register";
			public const string Login = "login";
			public const string Delete = "{id}";
			public const string Verify = "verify";
			public const string Resend = "resend";
		}
	}
}
