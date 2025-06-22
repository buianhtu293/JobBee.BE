using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using MediatR;

namespace JobBee.Application.Features.SavedJob.Commands.DeleteSavedJob
{
	public class DeleteSavedJobHandler : IRequestHandler<DeleteSavedJobCommand, Unit>
	{
		private readonly IMapper _mapper;
		private readonly ISavedJobRepository _savedJobRepository;
		private readonly IUnitOfWork<Domain.Entities.SavedJob, Guid> _unitOfWork;

		public DeleteSavedJobHandler(IMapper mapper,
			ISavedJobRepository savedJobRepository,
			IUnitOfWork<Domain.Entities.SavedJob, Guid> unitOfWork)
		{
			_mapper = mapper;
			_savedJobRepository = savedJobRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<Unit> Handle(DeleteSavedJobCommand request, CancellationToken cancellationToken)
		{
			var savedJobToDelete = await _savedJobRepository.GetSavedJob(request.CandidateId, request.JobId);

			if (savedJobToDelete == null)
			{
				throw new NotFoundException(nameof(Domain.Entities.SavedJob), request.CandidateId);
			}

			_savedJobRepository.Delete(savedJobToDelete);

			await _unitOfWork.SaveChangesAsync();

			return Unit.Value;
		}
	}
}
