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

namespace JobBee.Application.Features.Industry.Commands.CreateIndustry
{
	public class CreateIndustryHandler : IRequestHandler<CreateIndustryCommand, ApiResponse<CreateIndustryDto>>
	{
		private readonly IMapper _mapper;
		private readonly IIndustryRepository _industryRepository;
		private readonly IUnitOfWork<Domain.Entities.Industry, Guid> _unitOfWork;

		public CreateIndustryHandler(IMapper mapper, 
			IIndustryRepository industryRepository, 
			IUnitOfWork<Domain.Entities.Industry, Guid> unitOfWork)
		{
			_mapper = mapper;
			_industryRepository = industryRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<ApiResponse<CreateIndustryDto>> Handle(CreateIndustryCommand request, CancellationToken cancellationToken)
		{
			var validator = new CreateIndustryValidator(_industryRepository);
			var validatorResult = await validator.ValidateAsync(request);

			if (validatorResult.Errors.Any())
			{
				throw new BadRequestException("Invalid Industry", validatorResult);
			}

			var industryToCreate = _mapper.Map<Domain.Entities.Industry>(request);
			industryToCreate.Id = Guid.NewGuid();

			_industryRepository.Insert(industryToCreate);

			var industryCreated = _mapper.Map<CreateIndustryDto>(industryToCreate);
			var data = new ApiResponse<CreateIndustryDto>("Success", 200, industryCreated);

			await _unitOfWork.SaveChangesAsync();

			return data;

		}
	}
}
