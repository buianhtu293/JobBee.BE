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

namespace JobBee.Application.Features.ExperienceLevel.Commands.UpdateExperienceLevel
{
	public class UpdateExperienceLevelHandler : IRequestHandler<UpdateExperienceLevelCommand, ApiResponse<UpdateExperienceLevelDto>>
	{
		private readonly IMapper _mapper;
		private readonly IExperienceLevelRepository _experienceLevelRepository;
		private readonly IUnitOfWork<Domain.Entities.ExperienceLevel, Guid> _unitOfWork;

		public UpdateExperienceLevelHandler(IMapper mapper,
			IExperienceLevelRepository experienceLevelRepository,
			IUnitOfWork<Domain.Entities.ExperienceLevel, Guid> unitOfWork)
		{
			_mapper = mapper;
			_experienceLevelRepository = experienceLevelRepository;
			_unitOfWork = unitOfWork;
		}
		public async Task<ApiResponse<UpdateExperienceLevelDto>> Handle(UpdateExperienceLevelCommand request, CancellationToken cancellationToken)
		{
			var validator = new UpdateExperienceLevelValidator(_experienceLevelRepository);
			var validatorResult = await validator.ValidateAsync(request);

			if (validatorResult.Errors.Any())
			{
				throw new BadRequestException("Invalid Experience Level", validatorResult);
			}

			var experienceLevelToUpdate = _mapper.Map<Domain.Entities.ExperienceLevel>(request);

			_experienceLevelRepository.Update(experienceLevelToUpdate);

			var experienceLevelUpdated = _mapper.Map<UpdateExperienceLevelDto>(experienceLevelToUpdate);
			var data = new ApiResponse<UpdateExperienceLevelDto>("Success", 200, experienceLevelUpdated);

			await _unitOfWork.SaveChangesAsync();

			return data;
		}
	}
}
