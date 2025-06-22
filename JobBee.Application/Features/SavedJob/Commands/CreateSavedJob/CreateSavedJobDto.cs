using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Application.Features.SavedJob.Commands.CreateSavedJob
{
	public class CreateSavedJobDto
	{
		public Guid Id { get; set; }
		public Guid CandidateId { get; set; }
		public Guid JobId { get; set; }
		public DateTime? SavedAt { get; set; }
	}
}
