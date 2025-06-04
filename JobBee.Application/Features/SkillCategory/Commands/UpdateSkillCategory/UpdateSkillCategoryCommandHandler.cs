using AutoMapper;
using JobBee.Application.Contracts.Logging;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Application.Features.SkillCategory.Queries.GetAllSkillCategories;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.SkillCategory.Commands.UpdateSkillCategory
{
	public class UpdateSkillCategoryCommandHandler : IRequestHandler<UpdateSkillCategoryCommand, ApiResponse<SkillCategoryDto>>
	{
		private readonly IMapper _mapper;
		private readonly ISkillCategoryRepository _skillCategoryRepository;
		private readonly IAppLogger<UpdateSkillCategoryCommandHandler> _logger;
		private readonly IUnitOfWork<Domain.Entities.SkillCategory, Guid> _unitOfWork;

		public UpdateSkillCategoryCommandHandler(IMapper mapper,
			ISkillCategoryRepository skillCategoryRepository,
			IAppLogger<UpdateSkillCategoryCommandHandler> logger,
			IUnitOfWork<Domain.Entities.SkillCategory, Guid> unitOfWork)
		{
			this._mapper = mapper;
			this._skillCategoryRepository = skillCategoryRepository;
			this._logger = logger;
			_unitOfWork = unitOfWork;
		}
		public async Task<ApiResponse<SkillCategoryDto>> Handle(UpdateSkillCategoryCommand request, CancellationToken cancellationToken)
		{
			var validator = new UpdateSkillCategoryCommandValidator(_skillCategoryRepository);
			var validationResult = await validator.ValidateAsync(request);

			if(validationResult.Errors.Any())
			{
				throw new BadRequestException("Invalid Skill Category", validationResult);
			}

			var skillCategoryToUpdate = _mapper.Map<Domain.Entities.SkillCategory>(request);

			_skillCategoryRepository.Update(skillCategoryToUpdate);

			var skillCategoryUpdated = _mapper.Map<SkillCategoryDto>(skillCategoryToUpdate);
			var data = new ApiResponse<SkillCategoryDto>("Success", 200, skillCategoryUpdated);

			await _unitOfWork.SaveChangesAsync();

			return data;
		}
	}
}
