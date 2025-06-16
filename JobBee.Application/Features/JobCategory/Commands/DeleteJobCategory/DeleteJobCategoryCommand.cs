using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace JobBee.Application.Features.JobCategory.Commands.DeleteJobCategory
{
	public class DeleteJobCategoryCommand : IRequest<Unit>
	{
		public Guid Id { get; set; }
	}
}
