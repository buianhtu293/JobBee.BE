using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Shared.APIRoutes
{
	public class NotificationTypeRoutes
	{
		public const string Index = "api/notificationTypes";

		public static class ACTION
		{
			public const string GetListNotificationType = "list";
			public const string GetNotificationTypeDetail = "{id}";
			public const string CreateNotificationType = "create";
			public const string UpdateNotificationType = "update";
			public const string DeleteNotificationType = "delete/{id}";
		}
	}
}
