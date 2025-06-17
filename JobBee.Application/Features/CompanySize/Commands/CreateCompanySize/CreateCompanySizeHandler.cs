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

namespace JobBee.Application.Features.CompanySize.Commands.CreateCompanySize
{
	public class CreateCompanySizeHandler : IRequestHandler<CreateCompanySizeCommand, ApiResponse<CreateCompanySizeDto>>
	{
		private readonly IMapper _mapper;
		private readonly ICompanySizeRepository _companySizeRepository;
		private readonly IUnitOfWork<Domain.Entities.CompanySize, Guid> _unitOfWork;

		public CreateCompanySizeHandler(IMapper mapper, 
			ICompanySizeRepository companySizeRepository, 
			IUnitOfWork<Domain.Entities.CompanySize, Guid> unitOfWork)
		{
			this._mapper = mapper;
			this._companySizeRepository = companySizeRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<ApiResponse<CreateCompanySizeDto>> Handle(CreateCompanySizeCommand request, CancellationToken cancellationToken)
		{
			var validator = new CreateCompanySizeValidator(_companySizeRepository);
			var validatorResult = await validator.ValidateAsync(request);

			if (validatorResult.Errors.Any())
			{
				throw new BadRequestException("Invalid Company Size", validatorResult);
			}

			var companySizeToCreate = _mapper.Map<Domain.Entities.CompanySize>(request);
			companySizeToCreate.Id = Guid.NewGuid();

			_companySizeRepository.Insert(companySizeToCreate);

			var companySizeCreated = _mapper.Map<CreateCompanySizeDto>(companySizeToCreate);
			var data = new ApiResponse<CreateCompanySizeDto>("Success", 200, companySizeCreated);

			await _unitOfWork.SaveChangesAsync();

			return data;
		}
	}
}
