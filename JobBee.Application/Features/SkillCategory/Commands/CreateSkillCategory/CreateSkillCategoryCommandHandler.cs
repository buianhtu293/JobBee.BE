using AutoMapper;
using JobBee.Application.Contracts.Logging;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Application.Features.SkillCategory.Queries.GetAllSkillCategories;
using JobBee.Application.Models.Response;
using JobBee.Domain.Entities;
using MediatR;

namespace JobBee.Application.Features.SkillCategory.Commands.CreateSkillCategory
{
	public class CreateSkillCategoryCommandHandler : IRequestHandler<CreateSkillCategoryCommand, ApiResponse<SkillCategoryDto>>
	{
		private readonly IMapper _mapper;
		private readonly ISkillCategoryRepository _skillCategoryRepository;
		private readonly IAppLogger<GetSkillCategoryQueryHandler> _logger;
		private readonly IUnitOfWork<Domain.Entities.SkillCategory, Guid> _unitOfWork;

		public CreateSkillCategoryCommandHandler(IMapper mapper,
			ISkillCategoryRepository skillCategoryRepository,
			IAppLogger<GetSkillCategoryQueryHandler> logger,
			IUnitOfWork<Domain.Entities.SkillCategory, Guid> unitOfWork)
		{
			this._mapper = mapper;
			this._skillCategoryRepository = skillCategoryRepository;
			this._logger = logger;
			_unitOfWork = unitOfWork;
		}

		public async Task<ApiResponse<SkillCategoryDto>> Handle(CreateSkillCategoryCommand request, CancellationToken cancellationToken)
		{
			var validator = new CreateSkillCategoryCommandValidator(_skillCategoryRepository);
			var validationResult = await validator.ValidateAsync(request);

			if (validationResult.Errors.Any())
			{
				throw new BadRequestException("Invalid skill category", validationResult);
			}

			var skillCategoryToCreate = _mapper.Map<Domain.Entities.SkillCategory>(request);
			skillCategoryToCreate.Id = Guid.NewGuid();

			_skillCategoryRepository.Insert(skillCategoryToCreate);

			var skillCategoryCreated = _mapper.Map<SkillCategoryDto>(skillCategoryToCreate);
			var data = new ApiResponse<SkillCategoryDto>("Success", 201, skillCategoryCreated);

			_unitOfWork.SaveChangesAsync();

			return data;
		}
	}
}
