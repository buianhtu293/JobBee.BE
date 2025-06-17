using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.CompanySize.Queries.GetAllCompanySize
{
	public class GetAllCompanySizeHandler : IRequestHandler<GetAllCompanySizeQuery, ApiResponse<List<CompanySizeDto>>>
	{
		private readonly IMapper _mapper;
		private readonly ICompanySizeRepository _companySizeRepository;

		public GetAllCompanySizeHandler(IMapper mapper, 
			ICompanySizeRepository companySizeRepository)
		{
			_mapper = mapper;
			_companySizeRepository = companySizeRepository;
		}

		public async Task<ApiResponse<List<CompanySizeDto>>> Handle(GetAllCompanySizeQuery request, CancellationToken cancellationToken)
		{
			var companySizes = await _companySizeRepository.GetAllListAsync();

			var companySizeList = _mapper.Map<List<CompanySizeDto>>(companySizes);
			var data = new ApiResponse<List<CompanySizeDto>>("Success", 200, companySizeList);

			return data;
		}
	}
}
