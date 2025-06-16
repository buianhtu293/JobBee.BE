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

namespace JobBee.Application.Features.ExperienceLevel.Commands.CreateExperienceLevel
{
	public class CreateExperienceLevelHandler : IRequestHandler<CreateExperienceLevelCommand, ApiResponse<CreateExperienceLevelDto>>
	{
		private readonly IMapper _mapper;
		private readonly IExperienceLevelRepository _experienceLevelRepository;
		private readonly IUnitOfWork<Domain.Entities.ExperienceLevel, Guid> _unitOfWork;

		public CreateExperienceLevelHandler(IMapper mapper, 
			IExperienceLevelRepository experienceLevelRepository, 
			IUnitOfWork<Domain.Entities.ExperienceLevel, Guid> unitOfWork)
		{
			_mapper = mapper;
			_experienceLevelRepository = experienceLevelRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<ApiResponse<CreateExperienceLevelDto>> Handle(CreateExperienceLevelCommand request, CancellationToken cancellationToken)
		{
			var validator = new CreateExperienceLevelValidator(_experienceLevelRepository);
			var validatorResult = await validator.ValidateAsync(request);

			if (validatorResult.Errors.Any())
			{
				throw new BadRequestException("Invalid Experience Level", validatorResult);
			}

			var experienceLevelToCreate = _mapper.Map<Domain.Entities.ExperienceLevel>(request);
			experienceLevelToCreate.Id = Guid.NewGuid();

			_experienceLevelRepository.Insert(experienceLevelToCreate);

			var experienceLevelCreated = _mapper.Map<CreateExperienceLevelDto>(experienceLevelToCreate);
			var data = new ApiResponse<CreateExperienceLevelDto>("Success", 200, experienceLevelCreated);

			await _unitOfWork.SaveChangesAsync();

			return data;
		}
	}
}
