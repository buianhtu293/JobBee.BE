using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Logging;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using JobBee.Domain;
using MediatR;

namespace JobBee.Application.Features.LeaveType.Commands.CreateLeaveType
{
	public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
	{
		private readonly IMapper _mapper;
		private readonly ILeaveTypeRepository _leaveTypeRepository;
		private readonly IAppLogger<GetLeaveTypeQueryHandler> _logger;

		public CreateLeaveTypeCommandHandler(IMapper mapper, 
			ILeaveTypeRepository leaveTypeRepository,
			IAppLogger<GetLeaveTypeQueryHandler> logger)
        {
			this._mapper = mapper;
			this._leaveTypeRepository = leaveTypeRepository;
		}

        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
		{
			//Validate incomming data
			var validator = new CreateLeaveTypeCommandValidator(_leaveTypeRepository);
			var validationResult = await validator.ValidateAsync(request);

			if (validationResult.Errors.Any())
			{
				//_logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(LeaveType));
				throw new BadRequestException("Invalid LeaveType", validationResult);
			}

			//Convert to doamin entity object
			var leaveTypeToCreate = _mapper.Map<Domain.LeaveType>(request);

			//Add to database
			await _leaveTypeRepository.CreateAsync(leaveTypeToCreate);

			//Return record id
			return leaveTypeToCreate.Id;
		}
	}
}
