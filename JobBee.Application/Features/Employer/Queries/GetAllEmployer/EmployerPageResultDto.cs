using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Application.Features.Employer.Queries.GetAllEmployer
{
	public class EmployerPageResultDto
	{
		public Guid Id { get; set; }
		public Guid UserId { get; set; }
		public string UserName { get; set; }
		public string CompanyName { get; set; } = null!;
		public string? CompanyLogo { get; set; }
		public Guid? IndustryId { get; set; }
		public string IndustryName { get; set; }
		public Guid? CompanySizeId { get; set; }
		public string SizeRange { get; set; }
		public int? FoundedYear { get; set; }
		public string? CompanyDescription { get; set; }
		public string? WebsiteUrl { get; set; }
		public string? HeadquartersAddress { get; set; }
		public string? HeadquartersCity { get; set; }
		public string? HeadquartersState { get; set; }
		public string? HeadquartersCountry { get; set; }
		public string? ContactPersonName { get; set; }
		public string? ContactEmail { get; set; }
		public string? ContactPhone { get; set; }
		public bool? IsVerified { get; set; }
		public string? VerificationDocuments { get; set; }
		public DateTime? CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
	}
}
