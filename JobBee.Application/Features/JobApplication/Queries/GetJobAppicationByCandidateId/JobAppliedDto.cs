using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Application.Features.JobApplication.Queries.GetJobAppicationByCandidateId
{
	public class JobAppliedDto
	{
		public Guid Id { get; set; }
		public Guid EmployerId { get; set; }
		public string? CompanyName { get; set; }
		public string Title { get; set; } = null!;
		public Guid? JobCategoryId { get; set; }
		public string? CategoryName { get; set; }
		public Guid? JobTypeId { get; set; }
		public string? TypeName { get; set; }
		public Guid? ExperienceLevelId { get; set; }
		public string? ExperienceLevelName { get; set; }
		public Guid? MinEducationId { get; set; }
		public string? EducationName { get; set; }
		public string Description { get; set; } = null!;
		public string? Responsibilities { get; set; }
		public string? Requirements { get; set; }
		public decimal? MinSalary { get; set; }
		public decimal? MaxSalary { get; set; }
		public string? SalaryPeriod { get; set; }
		public string? Currency { get; set; }
		public bool? IsSalaryNegotiable { get; set; }
		public string? LocationCity { get; set; }
		public string? LocationState { get; set; }
		public string? LocationCountry { get; set; }
		public bool? IsRemote { get; set; }
		public bool? AllowsWorkFromHome { get; set; }
		public long? ApplicationDeadline { get; set; }
		public bool? IsFeatured { get; set; }
		public bool? IsActive { get; set; }
		public int? ViewsCount { get; set; }
		public int? ApplicationsCount { get; set; }
		public DateTime? PostedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
		public long? ExpiresAt { get; set; }
	}
}
