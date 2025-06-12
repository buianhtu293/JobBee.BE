using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using MediatR;

namespace JobBee.Application.Features.CandidateEducation.Commands.DeleteCandidateEducation
{
	public class DeleteCandidateEducationHandler : IRequestHandler<DeleteCandidateEducationCommand, Unit>
	{
		private readonly IMapper _mapper;
		private readonly ICandidateEducationRepository _candidateEducationRepository;
		private readonly IUnitOfWork<Domain.Entities.CandidateEducation, Guid> _unitOfWork;

		public DeleteCandidateEducationHandler(IMapper mapper,
			ICandidateEducationRepository candidateEducationRepository,
			IUnitOfWork<Domain.Entities.CandidateEducation, Guid> unitOfWork)
		{
			_mapper = mapper;
			_candidateEducationRepository = candidateEducationRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<Unit> Handle(DeleteCandidateEducationCommand request, CancellationToken cancellationToken)
		{
			var candidateEducationToDelete = _candidateEducationRepository.GetById(request.Id);

			if (candidateEducationToDelete == null)
			{
				throw new NotFoundException(nameof(candidateEducationToDelete), request.Id);
			}

			_candidateEducationRepository.Delete(candidateEducationToDelete);

			await _unitOfWork.SaveChangesAsync();

			return Unit.Value;
		}
	}
}
