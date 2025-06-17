using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Application.Models.Response;
using JobBee.Domain.Entities;
using MediatR;

namespace JobBee.Application.Features.CompanySize.Queries.GetCompanySizeDetail
{
	public class GetCompanySizeDetailHandler : IRequestHandler<GetCompanySizeDetailQuery, ApiResponse<CompanySizeDetailDto>>
	{
		private readonly IMapper _mapper;
		private readonly ICompanySizeRepository _companySizeRepository;

		public GetCompanySizeDetailHandler(IMapper mapper,
			ICompanySizeRepository companySizeRepository)
		{
			_mapper = mapper;
			_companySizeRepository = companySizeRepository;
		}

		public async Task<ApiResponse<CompanySizeDetailDto>> Handle(GetCompanySizeDetailQuery request, CancellationToken cancellationToken)
		{
			var companySize = _companySizeRepository.GetById(request.id);

			if (companySize == null)
			{
				throw new NotFoundException(nameof(companySize), request.id);
			}

			var companySizeDetail = _mapper.Map<CompanySizeDetailDto>(companySize);
			var data = new ApiResponse<CompanySizeDetailDto>("Success", 200, companySizeDetail);

			return data;
		}
	}
}
