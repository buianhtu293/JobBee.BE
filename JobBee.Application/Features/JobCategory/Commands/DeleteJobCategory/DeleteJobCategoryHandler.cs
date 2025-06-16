using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using MediatR;

namespace JobBee.Application.Features.JobCategory.Commands.DeleteJobCategory
{
	public class DeleteJobCategoryHandler : IRequestHandler<DeleteJobCategoryCommand, Unit>
	{
		private readonly IMapper _mapper;
		private readonly IJobCategoryRepository _jobCategoryRepository;
		private readonly IUnitOfWork<Domain.Entities.JobCategory, Guid> _unitOfWork;

		public DeleteJobCategoryHandler(IMapper mapper,
			IJobCategoryRepository jobCategoryRepository,
			IUnitOfWork<Domain.Entities.JobCategory, Guid> unitOfWork)
		{
			_mapper = mapper;
			_jobCategoryRepository = jobCategoryRepository;
			_unitOfWork = unitOfWork;
		}
		public async Task<Unit> Handle(DeleteJobCategoryCommand request, CancellationToken cancellationToken)
		{
			var jobCategoryToDelete = _jobCategoryRepository.GetById(request.Id);

			if (jobCategoryToDelete == null)
			{
				throw new NotFoundException(nameof(Domain.Entities.JobCategory), request.Id);
			}

			_jobCategoryRepository.Delete(jobCategoryToDelete);

			await _unitOfWork.SaveChangesAsync();

			return Unit.Value;

		}
	}
}
