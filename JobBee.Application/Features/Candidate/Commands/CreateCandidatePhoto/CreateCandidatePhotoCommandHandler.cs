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

namespace JobBee.Application.Features.Candidate.Commands.CreateCandidatePhoto
{
	public class CreateCandidatePhotoCommandHandler : IRequestHandler<CreateCandidatePhotoCommand, ApiResponse<bool>>
	{
		private readonly ICandidateRepository _candidateRepository;
		private readonly IUnitOfWork<Domain.Entities.Candidate, Guid> _unitOfWork;
		private readonly ICloudService _cloudService;

		public CreateCandidatePhotoCommandHandler(ICandidateRepository candidateRepository, 
			IUnitOfWork<Domain.Entities.Candidate, Guid> unitOfWork, 
			ICloudService cloudService)
		{
			_candidateRepository = candidateRepository;
			_unitOfWork = unitOfWork;
			_cloudService = cloudService;
		}

		public async Task<ApiResponse<bool>> Handle(CreateCandidatePhotoCommand request, CancellationToken cancellationToken)
		{
			var photo = request.ProfilePicture;
			var photoStream = photo.OpenReadStream();
			var photoUrl = await _cloudService.UploadFile(photo.ContentType, JobBee.Shared.Shared.Directory.Images, photoStream);

			var candidate = _candidateRepository.GetById(request.CandidateId);

			if (candidate == null)
			{
				throw new NotFoundException(nameof(candidate), request.CandidateId);
			}

			candidate.ProfilePicture = photoUrl;

			_candidateRepository.Update(candidate);

			await _unitOfWork.SaveChangesAsync();

			return new ApiResponse<bool>("Sucesss", 200, true);

		}
	}
}
