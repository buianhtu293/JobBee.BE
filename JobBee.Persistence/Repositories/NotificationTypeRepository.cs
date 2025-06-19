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
	public class NotificationTypeRepository : GenericRepository<NotificationType, Guid>, INotificationTypeRepository
	{
		public NotificationTypeRepository(JobBeeContext context) : base(context)
		{
		}
	}
}
