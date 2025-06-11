using JobBee.Application.Models.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Numerics;

namespace JobBee.Application.Features.Employer.Commands.CreateEmployer
{
	public class SocialMedial
	{
		public string Platform { get; set; } = null!;
		public string Link { get; set; } = null!;
	}

	public class CreateEmployerCommand : IRequest<ApiResponse<bool>>
	{
		public IFormFile Logo { get; set; } = null!;
		public IFormFile Banner { get; set; } = null!;
		public string CompnanyName { get; set; } = null!;
		public string AboutUs { get; set; } = null!;
		public Guid IndustryType { get; set; }
		public Guid TeamSize { get; set; }
		public int FoundedYear { get; set; }
		public string WebsiteUrl { get; set; } = null!;
		public IList<SocialMedial> SocialLink { get; set; } = new List<SocialMedial>();
		public string ContactPerson { get; set; } = null!;
		public string ContactEmail { get; set; } = null!;
		public string ContactPhone { get; set; } = null!;
		public string Address { get; set; } = null!;
		public string Commune { get; set; } = null!;
		public string District { get; set; } = null!;
		public string City { get; set; } = null!;
	}
}
