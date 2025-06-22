using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using MediatR;

namespace JobBee.Application.Features.SavedCandidate.Commands.DeleteSavedCandidate
{
	public class DeleteSavedCandidateHandler : IRequestHandler<DeleteSavedCandidateCommand, Unit>
	{
		private readonly IMapper _mapper;
		private readonly ISavedCandidateRepository _savedCandidateRepository;
		private IUnitOfWork<Domain.Entities.SavedCandidate, Guid> _unitOfWork;

		public DeleteSavedCandidateHandler(IMapper mapper,
			ISavedCandidateRepository savedCandidateRepository,
			IUnitOfWork<Domain.Entities.SavedCandidate, Guid> unitOfWork)
		{
			_mapper = mapper;
			_savedCandidateRepository = savedCandidateRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<Unit> Handle(DeleteSavedCandidateCommand request, CancellationToken cancellationToken)
		{
			var savedJobToDelete = await _savedCandidateRepository.GetSavedCandidate(request.EmployerId, request.CandidateId);
			
			if (savedJobToDelete == null)
			{
				throw new NotFoundException(nameof(Domain.Entities.SavedCandidate), request.EmployerId);
			}

			_savedCandidateRepository.Delete(savedJobToDelete);

			await _unitOfWork.SaveChangesAsync();

			return Unit.Value;
		}
	}
}
