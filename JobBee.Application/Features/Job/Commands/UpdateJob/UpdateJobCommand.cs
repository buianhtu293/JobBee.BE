using JobBee.Application.Models.Response;
using MediatR;
using System.Text.Json.Serialization;

namespace JobBee.Application.Features.Job.Commands.UpdateJob
{
	public class UpdateJobCommand : IRequest<ApiResponse<bool>>
	{
		[JsonIgnore]
		public Guid UserId { get; set; }
		[JsonIgnore]
		public Guid JobId { get; set; }
		public string Title { get; set; } = null!;
		public Guid JobCategoryId { get; set; }
		public Guid JobTypeId { get; set; }
		public Guid ExperienceLevelId { get; set; }
		public Guid MinEducationId { get; set; }
		public string Description { get; set; } = null!;
		public string Responsibilities { get; set; } = null!;
		public string Requirements { get; set; } = null!;
		public decimal MinSalary { get; set; }
		public decimal MaxSalary { get; set; }
		public string SalaryPeriod { get; set; } = null!;
		public string Currency { get; set; } = null!;
		public bool IsSalaryNegotiable { get; set; }
		public string LocationCity { get; set; } = null!;
		public string LocationState { get; set; } = null!;
		public string LocationCountry { get; set; } = null!;
		public bool IsRemote { get; set; }
		public bool AllowsWorkFromHome { get; set; }
		public long ApplicationDeadline { get; set; }
		public bool IsFeatured { get; set; }
	}
}
