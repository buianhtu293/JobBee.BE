using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Application.Features.CandidateEducation.Queries.GetAllCandidateEducation
{
	public class CandidateEducationDto
	{
		public Guid Id { get; set; }

		public Guid CandidateId { get; set; }

		public string InstitutionName { get; set; } = null!;

		public Guid? EducationLevelId { get; set; }

		public string? FieldOfStudy { get; set; }

		public DateOnly? StartDate { get; set; }

		public DateOnly? EndDate { get; set; }

		public bool? IsCurrent { get; set; }

		public string? Description { get; set; }

		public DateTime? CreatedAt { get; set; }

		public DateTime? UpdatedAt { get; set; }
	}
}
