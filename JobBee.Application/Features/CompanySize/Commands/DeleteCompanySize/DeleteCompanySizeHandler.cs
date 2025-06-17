using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using MediatR;

namespace JobBee.Application.Features.CompanySize.Commands.DeleteCompanySize
{
	public class DeleteCompanySizeHandler : IRequestHandler<DeleteCompanySizeCommand, Unit>
	{
		private readonly IMapper _mapper;
		private readonly ICompanySizeRepository _companySizeRepository;
		private readonly IUnitOfWork<Domain.Entities.CompanySize, Guid> _unitOfWork;

		public DeleteCompanySizeHandler(IMapper mapper,
			ICompanySizeRepository companySizeRepository,
			IUnitOfWork<Domain.Entities.CompanySize, Guid> unitOfWork)
		{
			this._mapper = mapper;
			this._companySizeRepository = companySizeRepository;
			_unitOfWork = unitOfWork;
		}
		public async Task<Unit> Handle(DeleteCompanySizeCommand request, CancellationToken cancellationToken)
		{
			var companySizeToDelete = _companySizeRepository.GetById(request.Id);

			if (companySizeToDelete == null)
			{
				throw new NotFoundException(nameof(Domain.Entities.CompanySize), request.Id);
			}

			_companySizeRepository.Delete(companySizeToDelete);

			await _unitOfWork.SaveChangesAsync();

			return Unit.Value;
		}
	}
}
