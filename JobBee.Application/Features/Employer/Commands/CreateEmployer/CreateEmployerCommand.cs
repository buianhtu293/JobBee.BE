using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.Employer.Commands.CreateEmployer
{
	public class SocialMedial
	{
		public string Platform { get; set; } = null!;
		public string Link { get; set; } = null!;
	}

	public class CreateEmployerCommand : IRequest<ApiResponse<Guid>>
	{
		public Guid UserId { get; set; }
		public string CompnanyName { get; set; } = null!;
		public string AboutUs { get; set; } = null!;
		public Guid IndustryType { get; set; }
		public Guid TeamSize { get; set; }
		public int FoundedYear { get; set; }
		public string WebsiteUrl { get; set; } = null!;
		public IList<SocialMedial> SocialMedials { get; set; } = new List<SocialMedial>();
		public string ContactPerson { get; set; } = null!;
		public string ContactEmail { get; set; } = null!;
		public string ContactPhone { get; set; } = null!;
		public string Address { get; set; } = null!;
		public string Commune { get; set; } = null!;
		public string District { get; set; } = null!;
		public string City { get; set; } = null!;
	}
}
