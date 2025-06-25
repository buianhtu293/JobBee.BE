using JobBee.Application.Features.Company;
using System.Text.Json.Serialization;

namespace JobBee.Application.Features.Job.Queries.GetAllJobs
{
	public class JobDto
	{
		[JsonPropertyName("id")]
		public string Id { get; set; }

		[JsonPropertyName("title")]
		public string Title { get; set; }

		[JsonPropertyName("employer_name")]
		public string EmployerName { get; set; }

		[JsonPropertyName("company_logo")]
		public string CompanyLogo { get; set; }

		[JsonPropertyName("job_category")]
		public string JobCategory { get; set; }

		[JsonPropertyName("job_type")]
		public string JobType { get; set; }

		[JsonPropertyName("job_status")]
		public string JobStatus { get; set; }

		[JsonPropertyName("experience_level")]
		public string ExperienceLevel { get; set; }

		[JsonPropertyName("min_education_level")]
		public string MinEducationLevel { get; set; }

		[JsonPropertyName("location_city")]
		public string LocationCity { get; set; }

		[JsonPropertyName("location_state")]
		public string LocationState { get; set; }

		[JsonPropertyName("location_country")]
		public string LocationCountry { get; set; }

		[JsonPropertyName("min_salary")]
		public double MinSalary { get; set; }

		[JsonPropertyName("max_salary")]
		public double MaxSalary { get; set; }

		[JsonPropertyName("salary_period")]
		public string SalaryPeriod { get; set; }

		[JsonPropertyName("salary_negotiable")]
		public bool SalaryNegotiable { get; set; }

		[JsonPropertyName("is_remote")]
		public bool IsRemote { get; set; }

		[JsonPropertyName("is_featured")]
		public bool IsFeatured { get; set; }

		[JsonPropertyName("views_count")]
		public int ViewsCount { get; set; }

		[JsonPropertyName("applications_count")]
		public int ApplicationsCount { get; set; }

		[JsonPropertyName("posted_at")]
		public DateTime PostedAt { get; set; }

		[JsonPropertyName("updated_at")]
		public DateTime UpdatedAt { get; set; }

		[JsonPropertyName("expires_at")]
		public long? ExpiresAt { get; set; }

		[JsonPropertyName("application_deadline")]
		public long? ApplicationDeadline { get; set; }
	}
}
