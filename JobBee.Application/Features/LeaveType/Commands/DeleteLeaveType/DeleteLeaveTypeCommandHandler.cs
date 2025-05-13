using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using MediatR;

namespace JobBee.Application.Features.LeaveType.Commands.DeleteLeaveType
{
	public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
	{
		private readonly ILeaveTypeRepository _leaveTypeRepository;

		public DeleteLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
		{
			this._leaveTypeRepository = leaveTypeRepository;
		}

		public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
		{
			//Retrieve domain entity object
			var leaveTypeToDelete = await _leaveTypeRepository.GetByIdAsync(request.Id);

			//Verify that record exists
			if(leaveTypeToDelete == null)
			{
				throw new NotFoundException(nameof(leaveTypeToDelete), request.Id);
			}

			//Remove to database
			await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);

			//Return record id
			return Unit.Value;
		}
	}
}
