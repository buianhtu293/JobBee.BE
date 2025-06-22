using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.CloudService;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Application.Models.Response;
using JobBee.Domain.Entities;
using MediatR;

namespace JobBee.Application.Features.CandidateResume.Commands.CreateCandidateResume
{
	public class CreateCandidateResumeHandler : IRequestHandler<CreateCandidateResumeCommand, ApiResponse<bool>>
	{
		private readonly ICandidateResumeRepository _candidateResumeRepository;
		private readonly ICloudService _cloudService;
		private readonly IUnitOfWork<Domain.Entities.CandidateResume, Guid> _unitOfWork;

		public CreateCandidateResumeHandler(ICandidateResumeRepository candidateResumeRepository, 
			ICloudService cloudService, 
			IUnitOfWork<Domain.Entities.CandidateResume, Guid> unitOfWork)
		{
			_candidateResumeRepository = candidateResumeRepository;
			_cloudService = cloudService;
			_unitOfWork = unitOfWork;
		}

		public async Task<ApiResponse<bool>> Handle(CreateCandidateResumeCommand request, CancellationToken cancellationToken)
		{
			var resume = request.Resume;
			var resumeStream = resume.OpenReadStream();
			var resumeUrl = await _cloudService.UploadFile(resume.ContentType, JobBee.Shared.Shared.Directory.Videos, resumeStream);
			var resumeVideo = new Domain.Entities.CandidateResume()
			{
				Id = Guid.NewGuid(),
				CandidateId = request.CandidateId,
				FileName = resume.FileName,
				FilePath = resumeUrl,
				FileSize = 0,
				FileType = resume.ContentType,
				IsDefault = true
			};

			_candidateResumeRepository.Insert(resumeVideo);

			var cnt = await _unitOfWork.SaveChangesAsync();
			if (cnt <= 0)
			{
				throw new BadRequestException(nameof(CompanyPhoto));
			}
			return new ApiResponse<bool>("Sucesss", 200, true);
		}
	}
}
