using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using MediatR;

namespace JobBee.Application.Features.ExperienceLevel.Commands.DeleteExperienceLevel
{
	public class DeleteExperienceLevelHandler : IRequestHandler<DeleteExperienceLevelCommand, Unit>
	{
		private readonly IMapper _mapper;
		private readonly IExperienceLevelRepository _experienceLevelRepository;
		private readonly IUnitOfWork<Domain.Entities.ExperienceLevel, Guid> _unitOfWork;

		public DeleteExperienceLevelHandler(IMapper mapper,
			IExperienceLevelRepository experienceLevelRepository,
			IUnitOfWork<Domain.Entities.ExperienceLevel, Guid> unitOfWork)
		{
			_mapper = mapper;
			_experienceLevelRepository = experienceLevelRepository;
			_unitOfWork = unitOfWork;
		}
		public async Task<Unit> Handle(DeleteExperienceLevelCommand request, CancellationToken cancellationToken)
		{
			var experienceLevelToDelete = _experienceLevelRepository.GetById(request.Id);

			if (experienceLevelToDelete == null)
			{
				throw new NotFoundException(nameof(Domain.Entities.ExperienceLevel), request.Id);
			}

			_experienceLevelRepository.Delete(experienceLevelToDelete);

			await _unitOfWork.SaveChangesAsync();

			return Unit.Value;
		}
	}
}
