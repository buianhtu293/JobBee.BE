using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Models.Response;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace JobBee.Application.Features.Candidate.Commands.CreateCandidatePhoto
{
	public class CreateCandidatePhotoCommand : IRequest<ApiResponse<bool>>
	{
		public Guid CandidateId { get; set; }
		public IFormFile ProfilePicture { get; set; }
	}
}
