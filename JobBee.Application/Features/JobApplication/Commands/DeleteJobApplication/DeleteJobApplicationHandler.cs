using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using MediatR;

namespace JobBee.Application.Features.JobApplication.Commands.DeleteJobApplication
{
	public class DeleteJobApplicationHandler : IRequestHandler<DeleteJobApplicationCommand, Unit>
	{
		private readonly IMapper _mapper;
		private readonly IJobApplicationRepository _jobApplicationRepository;
		private readonly IUnitOfWork<Domain.Entities.JobApplication, Guid> _unitOfWork;

		public DeleteJobApplicationHandler(IMapper mapper,
			IJobApplicationRepository jobApplicationRepository,
			IUnitOfWork<Domain.Entities.JobApplication, Guid> unitOfWork)
		{
			_mapper = mapper;
			_jobApplicationRepository = jobApplicationRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<Unit> Handle(DeleteJobApplicationCommand request, CancellationToken cancellationToken)
		{
			var jobApplicationToDelete = _jobApplicationRepository.GetById(request.Id);

			if (jobApplicationToDelete == null)
			{
				throw new NotFoundException(nameof(Domain.Entities.JobApplication), request.Id);
			}

			_jobApplicationRepository.Delete(jobApplicationToDelete);

			await _unitOfWork.SaveChangesAsync();

			return Unit.Value;

		}
	}
}
