using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Logging;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using MediatR;

namespace JobBee.Application.Features.LeaveType.Commands.UpdateLeaveType
{
	public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
	{
		private readonly IMapper _mapper;
		private readonly ILeaveTypeRepository _leaveTypeRepository;
		private readonly IAppLogger<UpdateLeaveTypeCommandHandler> _logger;

		public UpdateLeaveTypeCommandHandler(IMapper mapper, 
			ILeaveTypeRepository leaveTypeRepository,
			IAppLogger<UpdateLeaveTypeCommandHandler> logger)
        {
			this._mapper = mapper;
			this._leaveTypeRepository = leaveTypeRepository;
			this._logger = logger;
		}

        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
		{
			//Validate incomming data
			var validator = new UpdateLeaveTypeCommandValidator(_leaveTypeRepository);
			var validationResult = await validator.ValidateAsync(request);

			if (validationResult.Errors.Any())
			{
				_logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(LeaveType), request.Id);
				throw new BadRequestException("Invalid Leave type", validationResult);
			}

			//Convert to doamin entity object
			var leaveTypeToUpdate = _mapper.Map<Domain.LeaveType>(request);

			//Update to database
			await _leaveTypeRepository.UpdateAsync(leaveTypeToUpdate);

			//Return record id
			return Unit.Value;
		}
	}
}
