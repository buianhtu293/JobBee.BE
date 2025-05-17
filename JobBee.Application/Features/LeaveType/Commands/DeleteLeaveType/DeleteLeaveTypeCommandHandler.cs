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
		private readonly IMapper mapper;
		private readonly ILeaveTypeRepository _leaveTypeRepository;
		private readonly IUnitOfWork<Domain.LeaveType, Guid> _unitOfWork;

		public DeleteLeaveTypeCommandHandler(IMapper mapper, 
			ILeaveTypeRepository leaveTypeRepository,
			IUnitOfWork<Domain.LeaveType, Guid> unitOfWork)
		{
			this.mapper = mapper;
			this._leaveTypeRepository = leaveTypeRepository;
			this._unitOfWork = unitOfWork;
		}

		public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
		{
			//Retrieve domain entity object
			var leaveTypeToDelete = _leaveTypeRepository.GetById(request.Id);

			//Verify that record exists
			if(leaveTypeToDelete == null)
			{
				throw new NotFoundException(nameof(leaveTypeToDelete), request.Id);
			}

			//Remove to database
			_leaveTypeRepository.Delete(leaveTypeToDelete);

			//Save Change
			await _unitOfWork.SaveChangesAsync();

			//Return record id
			return Unit.Value;
		}
	}
}
