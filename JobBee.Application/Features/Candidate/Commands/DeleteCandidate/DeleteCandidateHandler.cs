using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using MediatR;

namespace JobBee.Application.Features.Candidate.Commands.DeleteCandidate
{
	public class DeleteCandidateHandler : IRequestHandler<DeleteCandidateCommand, Unit>
	{
		private readonly IMapper _mapper;
		private readonly ICandidateRepository _candidateRepository;
		private readonly IUnitOfWork<Domain.Entities.Candidate, Guid> _unitOfWork;

		public DeleteCandidateHandler(IMapper mapper,
			ICandidateRepository candidateRepository,
			IUnitOfWork<Domain.Entities.Candidate, Guid> unitOfWork)
		{
			_mapper = mapper;
			_candidateRepository = candidateRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<Unit> Handle(DeleteCandidateCommand request, CancellationToken cancellationToken)
		{
			var candidateToDelete = _candidateRepository.GetById(request.Id);

			if (candidateToDelete == null)
			{
				throw new NotFoundException(nameof(candidateToDelete), request.Id);
			}

			_candidateRepository.Delete(candidateToDelete);

			await _unitOfWork.SaveChangesAsync();

			return Unit.Value;

		}
	}
}
