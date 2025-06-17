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

namespace JobBee.Application.Features.Industry.Commands.UpdateIndustry
{
	public class UpdateIndustryHandler : IRequestHandler<UpdateIndustryCommand, ApiResponse<UpdateIndustryDto>>
	{
		private readonly IMapper _mapper;
		private readonly IIndustryRepository _industryRepository;
		private readonly IUnitOfWork<Domain.Entities.Industry, Guid> _unitOfWork;

		public UpdateIndustryHandler(IMapper mapper,
			IIndustryRepository industryRepository,
			IUnitOfWork<Domain.Entities.Industry, Guid> unitOfWork)
		{
			_mapper = mapper;
			_industryRepository = industryRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<ApiResponse<UpdateIndustryDto>> Handle(UpdateIndustryCommand request, CancellationToken cancellationToken)
		{
			var validator = new UpdateIndustryValidator(_industryRepository);
			var validatorResult = await validator.ValidateAsync(request);

			if (validatorResult.Errors.Any())
			{
				throw new BadRequestException("Invalid Skill", validatorResult);
			}

			var industryToUpdate = _mapper.Map<Domain.Entities.Industry>(request);

			_industryRepository.Update(industryToUpdate);

			var industryUpdated = _mapper.Map<UpdateIndustryDto>(industryToUpdate);
			var data = new ApiResponse<UpdateIndustryDto>("Success", 200, industryUpdated);

			await _unitOfWork.SaveChangesAsync();

			return data;
		}
	}
}
