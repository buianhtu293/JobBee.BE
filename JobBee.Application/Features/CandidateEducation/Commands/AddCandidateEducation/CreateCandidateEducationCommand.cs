using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.Runtime.Internal;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.CandidateEducation.Commands.AddCandidateEducation
{
	public class CreateCandidateEducationCommand : IRequest<ApiResponse<CreateCandidateEducationDto>>
	{
		public Guid CandidateId { get; set; }

		public string InstitutionName { get; set; } = null!;

		public Guid? EducationLevelId { get; set; }

		public string? FieldOfStudy { get; set; }

		public long StartDate { get; set; }

		public long EndDate { get; set; }

		public bool? IsCurrent { get; set; }

		public string? Description { get; set; }
	}
}
