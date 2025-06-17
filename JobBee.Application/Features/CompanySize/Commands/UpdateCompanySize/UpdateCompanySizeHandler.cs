using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.CompanySize.Commands.UpdateCompanySize
{
	public class UpdateCompanySizeHandler : IRequestHandler<UpdateCompanySizeCommand, ApiResponse<UpdateCompanySizeDto>>
	{
		private readonly IMapper _mapper;
		private readonly ICompanySizeRepository _companySizeRepository;
		private readonly IUnitOfWork<Domain.Entities.CompanySize, Guid> _unitOfWork;

		public UpdateCompanySizeHandler(IMapper mapper,
			ICompanySizeRepository companySizeRepository,
			IUnitOfWork<Domain.Entities.CompanySize, Guid> unitOfWork)
		{
			this._mapper = mapper;
			this._companySizeRepository = companySizeRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<ApiResponse<UpdateCompanySizeDto>> Handle(UpdateCompanySizeCommand request, CancellationToken cancellationToken)
		{
			var validator = new UpdateCompanySizeValidator(_companySizeRepository);
			var validatorResult = await validator.ValidateAsync(request);

			if (validatorResult.Errors.Any())
			{
				throw new BadRequestException("Invalid Skill", validatorResult);
			}

			var companySizeToUpdate = _mapper.Map<Domain.Entities.CompanySize>(request);

			_companySizeRepository.Update(companySizeToUpdate);

			var companySizeUpdated = _mapper.Map<UpdateCompanySizeDto>(companySizeToUpdate);
			var data = new ApiResponse<UpdateCompanySizeDto>("Success", 200, companySizeUpdated);

			await _unitOfWork.SaveChangesAsync();

			return data;
		}
	}
}
