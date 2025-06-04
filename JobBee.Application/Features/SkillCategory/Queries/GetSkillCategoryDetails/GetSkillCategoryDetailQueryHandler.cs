using AutoMapper;
using JobBee.Application.Contracts.Logging;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.SkillCategory.Queries.GetSkillCategoryDetails
{
	public class GetSkillCategoryDetailQueryHandler : IRequestHandler<GetSkillCategoryDetailQuery, ApiResponse<SkillCategoryDetailDto>>
	{
		private readonly IMapper _mapper;
		private readonly ISkillCategoryRepository _skillCategoryRepository;
		private readonly IAppLogger<GetSkillCategoryDetailQueryHandler> _logger;

		public GetSkillCategoryDetailQueryHandler(IMapper mapper,
			ISkillCategoryRepository skillCategoryRepository,
			IAppLogger<GetSkillCategoryDetailQueryHandler> logger)
		{
			this._mapper = mapper;
			this._skillCategoryRepository = skillCategoryRepository;
			this._logger = logger;
		}

		public async Task<ApiResponse<SkillCategoryDetailDto>> Handle(GetSkillCategoryDetailQuery request, CancellationToken cancellationToken)
		{
			var skillCategory = _skillCategoryRepository.GetById(request.id);

			if (skillCategory == null)
			{
				throw new NotFoundException(nameof(skillCategory), request.id);
			}

			var skillCategoryDetail = _mapper.Map<SkillCategoryDetailDto>(skillCategory);
			var data = new ApiResponse<SkillCategoryDetailDto>("Success", 200, skillCategoryDetail);

			return data;
		}
	}
}
