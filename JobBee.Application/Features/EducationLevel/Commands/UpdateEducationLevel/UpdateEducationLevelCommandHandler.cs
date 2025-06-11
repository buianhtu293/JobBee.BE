using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.EducationLevel.Commands.UpdateEducationLevel
{
	public class UpdateEducationLevelCommandHandler : IRequestHandler<UpdateEducationLevelCommand, ApiResponse<UpdateEducationLevelDto>>
	{
		private readonly IMapper _mapper;
		private readonly IEducationLevelRepository _educationLevel;
		private readonly IUnitOfWork<Domain.Entities.EducationLevel, Guid> _unitOfWork;

		public UpdateEducationLevelCommandHandler(IMapper mapper,
			IEducationLevelRepository educationLevel,
			IUnitOfWork<Domain.Entities.EducationLevel, Guid> unitOfWork)
		{
			_mapper = mapper;
			_educationLevel = educationLevel;
			_unitOfWork = unitOfWork;
		}
		public async Task<ApiResponse<UpdateEducationLevelDto>> Handle(UpdateEducationLevelCommand request, CancellationToken cancellationToken)
		{
			var validator = new UpdateEducationLevelCommandValidator(_educationLevel);
			var validatorResult = await validator.ValidateAsync(request);

			if (validatorResult.Errors.Any())
			{
				throw new BadRequestException("Invalid Education Level", validatorResult);
			}

			var educationLevelToUpdate = _mapper.Map<Domain.Entities.EducationLevel>(request);
			_educationLevel.Update(educationLevelToUpdate);

			var educationLevelUpdated = _mapper.Map<UpdateEducationLevelDto>(educationLevelToUpdate);
			var data = new ApiResponse<UpdateEducationLevelDto>("Success", 200, educationLevelUpdated);

			await _unitOfWork.SaveChangesAsync();

			return data;
		}
	}
}
