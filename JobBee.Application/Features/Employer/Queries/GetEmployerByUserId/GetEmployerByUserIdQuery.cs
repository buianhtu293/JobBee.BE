using JobBee.Application.Features.Employer.Queries.GetEmployerDetail;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.Employer.Queries.GetEmployerByUserId
{
	public class GetEmployerByUserIdQuery : IRequest<ApiResponse<Guid>>
	{
		public Guid Id { get; set; }
	}
}
