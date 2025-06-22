using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Contracts.Persistence;
using JobBee.Domain.Entities;
using JobBee.Persistence.DatabaseContext;

namespace JobBee.Persistence.Repositories
{
	public class NotificationRepository : GenericRepository<Notification, Guid>, INotificationRepository
	{
		public NotificationRepository(JobBeeContext context) : base(context)
		{
		}
	}
}
