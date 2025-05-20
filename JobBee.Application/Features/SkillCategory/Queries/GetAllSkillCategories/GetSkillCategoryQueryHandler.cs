using AutoMapper;
using JobBee.Application.Contracts.Logging;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.SkillCategory.Queries.GetAllSkillCategories
{
	public class GetSkillCategoryQueryHandler : IRequestHandler<GetSkillCategoryQuery, ApiResponse<List<SkillCategoryDto>>>
	{
		private readonly IMapper _mapper;
		private readonly ISkillCategoryRepository _skillCategoryRepository;
		private readonly IAppLogger<GetSkillCategoryQueryHandler> _logger;

		public GetSkillCategoryQueryHandler(IMapper mapper,
			ISkillCategoryRepository skillCategoryRepository,
			IAppLogger<GetSkillCategoryQueryHandler> logger)
        {
			this._mapper = mapper;
			this._skillCategoryRepository = skillCategoryRepository;
			this._logger = logger;
		}
        public async Task<ApiResponse<List<SkillCategoryDto>>> Handle(GetSkillCategoryQuery request, CancellationToken cancellationToken)
		{
			//Query the database
			var skillCategories = await _skillCategoryRepository.GetAllListAsync();

			//Convert data objects to DTO object
			var skillCategoriesList = _mapper.Map<List<SkillCategoryDto>>(skillCategories);
			var data = new ApiResponse<List<SkillCategoryDto>>("Success", 200, skillCategoriesList);

			//Return list of DTO object
			_logger.LogInformation("Leave types were retrieved successfully");

			return data;
		}
	}
}
