using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.Runtime.Internal;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.CandidateEducation.Commands.UpdateCandidateEducation
{
	public class UpdateCandidateEducationCommand : IRequest<ApiResponse<UpdateCandidateEducationDto>>
	{
		public Guid Id { get; set; }

		public string InstitutionName { get; set; } = null!;

		public Guid? EducationLevelId { get; set; }

		public string? FieldOfStudy { get; set; }

		public DateOnly? StartDate { get; set; }

		public DateOnly? EndDate { get; set; }

		public bool? IsCurrent { get; set; }

		public string? Description { get; set; }
	}
}
