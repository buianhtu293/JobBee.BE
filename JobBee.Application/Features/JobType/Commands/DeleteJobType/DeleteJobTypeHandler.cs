using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using MediatR;

namespace JobBee.Application.Features.JobType.Commands.DeleteJobType
{
	public class DeleteJobTypeHandler : IRequestHandler<DeleteJobTypeCommand, Unit>
	{
		private readonly IMapper _mapper;
		private readonly IJobTypeRepository _jobTypeRepository;
		private readonly IUnitOfWork<Domain.Entities.JobType, Guid> _unitOfWork;

		public DeleteJobTypeHandler(IMapper mapper,
			IJobTypeRepository jobTypeRepository,
			IUnitOfWork<Domain.Entities.JobType, Guid> unitOfWork)
		{
			_mapper = mapper;
			_jobTypeRepository = jobTypeRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<Unit> Handle(DeleteJobTypeCommand request, CancellationToken cancellationToken)
		{
			var jobTypeToDelete = _jobTypeRepository.GetById(request.Id);

			if (jobTypeToDelete == null)
			{
				throw new NotFoundException(nameof(Domain.Entities.JobType), request.Id);
			}

			_jobTypeRepository.Delete(jobTypeToDelete);

			await _unitOfWork.SaveChangesAsync();

			return Unit.Value;
		}
	}
}
