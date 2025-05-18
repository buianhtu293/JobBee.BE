using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Logging;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
	public class GetLeaveTypeQueryHandler : IRequestHandler<GetLeaveTypeQuery, ApiResponse<List<LeaveTypeDto>>>
	{
		private readonly IMapper _mapper;
		private readonly ILeaveTypeRepository _leaveTypeRepository;
		private readonly IAppLogger<GetLeaveTypeQueryHandler> _logger;

        public GetLeaveTypeQueryHandler(IMapper mapper, 
			ILeaveTypeRepository leaveTypeRepository,
			IAppLogger<GetLeaveTypeQueryHandler> logger)
        {
			this._mapper = mapper;
            this._leaveTypeRepository = leaveTypeRepository;
			this._logger = logger;
        }

        public async Task<ApiResponse<List<LeaveTypeDto>>> Handle(GetLeaveTypeQuery request, CancellationToken cancellationToken)
		{
			//Query the database
			var leaveTypes = await _leaveTypeRepository.GetAllListAsync();

			//Convert data objects to DTO objects
			var leaveTypeList = _mapper.Map<List<LeaveTypeDto>>(leaveTypes);
			var data = new ApiResponse<List<LeaveTypeDto>>("Success", 200, leaveTypeList);

			//Return list of DTO object
			_logger.LogInformation("Leave types were retrieved successfully");

			return data;
		}
	}
}
