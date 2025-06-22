using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Application.Features.SavedCandidate.Commands.CreateSavedCandidate
{
	public class CreateSavedCandidateDto
	{
		public Guid Id { get; set; }
		public Guid EmployerId { get; set; }
		public Guid CandidateId { get; set; }
		public DateTime? SavedAt { get; set; }
		public string? Notes { get; set; }
	}
}
