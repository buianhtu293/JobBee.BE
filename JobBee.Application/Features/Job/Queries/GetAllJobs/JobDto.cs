using JobBee.Application.Features.Company;
using OpenSearch.Client;

namespace JobBee.Application.Features.Job.Queries.GetAllJobs
{
	public class JobDto
	{
		[PropertyName("id")]
		public string Id { get; set; }

		[PropertyName("title")]
		public string Title { get; set; }

		[PropertyName("employer_name")]
		public string EmployerName { get; set; }

		[PropertyName("company_logo")]
		public string CompanyLogo { get; set; }

		[PropertyName("job_category")]
		public string JobCategory { get; set; }

		[PropertyName("job_type")]
		public string JobType { get; set; }

		[PropertyName("job_status")]
		public string JobStatus { get; set; }

		[PropertyName("experience_level")]
		public string ExperienceLevel { get; set; }

		[PropertyName("min_education_level")]
		public string MinEducationLevel { get; set; }

		[PropertyName("location_city")]
		public string LocationCity { get; set; }

		[PropertyName("location_state")]
		public string LocationState { get; set; }

		[PropertyName("location_country")]
		public string LocationCountry { get; set; }

		[PropertyName("min_salary")]
		public double MinSalary { get; set; }

		[PropertyName("max_salary")]
		public double MaxSalary { get; set; }

		[PropertyName("salary_period")]
		public string SalaryPeriod { get; set; }

		[PropertyName("salary_negotiable")]
		public bool SalaryNegotiable { get; set; }

		[PropertyName("is_remote")]
		public bool IsRemote { get; set; }

		[PropertyName("is_featured")]
		public bool IsFeatured { get; set; }

		[PropertyName("views_count")]
		public int ViewsCount { get; set; }

		[PropertyName("applications_count")]
		public int ApplicationsCount { get; set; }

		[PropertyName("posted_at")]
		public DateTime PostedAt { get; set; }

		[PropertyName("updated_at")]
		public DateTime UpdatedAt { get; set; }

		[PropertyName("expires_at")]
		public long? ExpiresAt { get; set; }

		[PropertyName("application_deadline")]
		public long? ApplicationDeadline { get; set; }
	}
}
