using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.EmailService;
using JobBee.Application.Exceptions;
using MediatR;

namespace JobBee.Application.Features.JobAlert.Commands.DeleteJobAlert
{
	public class DeleteJobAlertHandler : IRequestHandler<DeleteJobAlertCommand, Unit>
	{
		private readonly IMapper _mapper;
		private readonly IJobAlertRepository _jobAlertRepository;
		private readonly IUnitOfWork<Domain.Entities.JobAlert, Guid> _unitOfWork;

		public DeleteJobAlertHandler(IMapper mapper, 
			IJobAlertRepository jobAlertRepository, 
			IUnitOfWork<Domain.Entities.JobAlert, Guid> unitOfWork)
		{
			_mapper = mapper;
			_jobAlertRepository = jobAlertRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<Unit> Handle(DeleteJobAlertCommand request, CancellationToken cancellationToken)
		{
			var jobAlertToDelete = await _jobAlertRepository.GetJobAlert(request.CandidateId, request.JobId);

			if (jobAlertToDelete == null)
			{
				throw new NotFoundException(nameof(Domain.Entities.JobAlert), request.CandidateId);
			}

			_jobAlertRepository.Delete(jobAlertToDelete);

			await _unitOfWork.SaveChangesAsync();

			return Unit.Value;
		}
	}
}
