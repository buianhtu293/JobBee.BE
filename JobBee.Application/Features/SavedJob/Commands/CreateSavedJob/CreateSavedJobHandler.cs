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

namespace JobBee.Application.Features.SavedJob.Commands.CreateSavedJob
{
	public class CreateSavedJobHandler : IRequestHandler<CreateSavedJobCommand, ApiResponse<CreateSavedJobDto>>
	{
		private readonly IMapper _mapper;
		private readonly ISavedJobRepository _savedJobRepository;
		private readonly IUnitOfWork<Domain.Entities.SavedJob, Guid> _unitOfWork;

		public CreateSavedJobHandler(IMapper mapper, 
			ISavedJobRepository savedJobRepository, 
			IUnitOfWork<Domain.Entities.SavedJob, Guid> unitOfWork)
		{
			_mapper = mapper;
			_savedJobRepository = savedJobRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<ApiResponse<CreateSavedJobDto>> Handle(CreateSavedJobCommand request, CancellationToken cancellationToken)
		{
			var validator = new CreateSavedJobValidator(_savedJobRepository);
			var validatorResult = await validator.ValidateAsync(request);

			if (validatorResult.Errors.Any())
			{
				throw new BadRequestException("Invalid Saved Job", validatorResult);
			}

			var savedJobToCreate = _mapper.Map<Domain.Entities.SavedJob>(request);
			savedJobToCreate.Id = Guid.NewGuid();
			savedJobToCreate.SavedAt = DateTime.Now;

			_savedJobRepository.Insert(savedJobToCreate);

			var savedJobCreated = _mapper.Map<CreateSavedJobDto>(savedJobToCreate);
			var data = new ApiResponse<CreateSavedJobDto>("Success", 200, savedJobCreated);

			await _unitOfWork.SaveChangesAsync();

			return data;

		}
	}
}
