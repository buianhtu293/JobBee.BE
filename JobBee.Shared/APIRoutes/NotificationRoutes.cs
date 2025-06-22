using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Shared.APIRoutes
{
	public class NotificationRoutes
	{
		public const string Index = "api/notifications";

		public static class ACTION
		{
			public const string GetListNotification = "list";
			public const string GetNotificationDetail = "{id}";
			public const string CreateNotification = "create";
			public const string UpdateNotification = "update";
			public const string DeleteNotification = "delete/{id}";
		}
	}
}
