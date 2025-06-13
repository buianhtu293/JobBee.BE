using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.Candidate.Commands.UpdateCandidate
{
	public class UpdateCandidateCommand : IRequest<ApiResponse<UpdateCandidateDto>>
	{
		public Guid Id { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? ProfilePicture { get; set; }
		public string? Phone { get; set; }
		public long BirthDate { get; set; }
		public string? Gender { get; set; }
		public string? Address { get; set; }
		public string? City { get; set; }
		public string? State { get; set; }
		public string? Country { get; set; }
		public string? PostalCode { get; set; }
		public string? Headline { get; set; }
		public string? Summary { get; set; }
		public decimal? CurrentSalary { get; set; }
		public decimal? SalaryExpectation { get; set; }
		public int? ExperienceYears { get; set; }
		public bool? IsAvailableForHire { get; set; }
	}
}
