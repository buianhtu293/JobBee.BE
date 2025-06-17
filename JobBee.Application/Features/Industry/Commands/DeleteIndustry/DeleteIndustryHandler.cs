using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using MediatR;

namespace JobBee.Application.Features.Industry.Commands.DeleteIndustry
{
	public class DeleteIndustryHandler : IRequestHandler<DeleteIndustryCommand, Unit>
	{
		private readonly IMapper _mapper;
		private readonly IIndustryRepository _industryRepository;
		private readonly IUnitOfWork<Domain.Entities.Industry, Guid> _unitOfWork;

		public DeleteIndustryHandler(IMapper mapper,
			IIndustryRepository industryRepository,
			IUnitOfWork<Domain.Entities.Industry, Guid> unitOfWork)
		{
			_mapper = mapper;
			_industryRepository = industryRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<Unit> Handle(DeleteIndustryCommand request, CancellationToken cancellationToken)
		{
			var industryToDelete = _industryRepository.GetById(request.Id);

			if (industryToDelete == null)
			{
				throw new NotFoundException(nameof(Domain.Entities.Industry), request.Id);
			}

			_industryRepository.Delete(industryToDelete);

			await _unitOfWork.SaveChangesAsync();

			return Unit.Value;
		}
	}
}
