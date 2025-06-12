using JobBee.Application.Models.Response;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace JobBee.Application.Features.EmployerPhoto
{
	public class CreateEmployerPhotoCommand : IRequest<ApiResponse<bool>>
	{
		public Guid EmployerId { get; set; }
		public IFormFile Logo { get; set; } = null!;
		public IFormFile Banner { get; set; } = null!;
	}
}
