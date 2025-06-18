using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.CloudService;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.CandidateResume.Commands.DeleteCandidateResume
{
	public class DeleteCandidateResumeHandler : IRequestHandler<DeleteCandidateResumeCommand, Unit>
	{
		private readonly ICandidateResumeRepository _candidateResumeRepository;
		private readonly ICloudService _cloudService;
		private readonly IUnitOfWork<Domain.Entities.CandidateResume, Guid> _unitOfWork;

		public DeleteCandidateResumeHandler(ICandidateResumeRepository candidateResumeRepository,
			ICloudService cloudService,
			IUnitOfWork<Domain.Entities.CandidateResume, Guid> unitOfWork)
		{
			_candidateResumeRepository = candidateResumeRepository;
			_cloudService = cloudService;
			_unitOfWork = unitOfWork;
		}

		public async Task<Unit> Handle(DeleteCandidateResumeCommand request, CancellationToken cancellationToken)
		{
			var candidateResumeToDelete = _candidateResumeRepository.GetById(request.Id);

			if (candidateResumeToDelete == null)
			{
				throw new NotFoundException(nameof(Domain.Entities.CandidateResume), request.Id);
			}

			_candidateResumeRepository.Delete(candidateResumeToDelete);
			await _cloudService.DeleteFile(candidateResumeToDelete.FilePath);

			await _unitOfWork.SaveChangesAsync();

			return Unit.Value;

		}
	}
}
