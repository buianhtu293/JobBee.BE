using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Logging;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Application.Features.SkillCategory.Queries.GetAllSkillCategories;
using MediatR;

namespace JobBee.Application.Features.SkillCategory.Commands.UpdateSkillCategory
{
	public class UpdateSkillCategoryCommandHandler : IRequestHandler<UpdateSkillCategoryCommand, Unit>
	{
		private readonly IMapper _mapper;
		private readonly ISkillCategoryRepository _skillCategoryRepository;
		private readonly IAppLogger<GetSkillCategoryQueryHandler> _logger;
		private readonly IUnitOfWork<Domain.Entities.SkillCategory, Guid> _unitOfWork;

		public UpdateSkillCategoryCommandHandler(IMapper mapper,
			ISkillCategoryRepository skillCategoryRepository,
			IAppLogger<GetSkillCategoryQueryHandler> logger,
			IUnitOfWork<Domain.Entities.SkillCategory, Guid> unitOfWork)
		{
			this._mapper = mapper;
			this._skillCategoryRepository = skillCategoryRepository;
			this._logger = logger;
			_unitOfWork = unitOfWork;
		}
		public async Task<Unit> Handle(UpdateSkillCategoryCommand request, CancellationToken cancellationToken)
		{
			var validator = new UpdateSkillCategoryCommandValidator(_skillCategoryRepository);
			var validationResult = await validator.ValidateAsync(request);

			if(validationResult.Errors.Any())
			{
				throw new BadRequestException("Invalid Skill Category", validationResult);
			}

			var skillCategoryToUpdate = _mapper.Map<Domain.Entities.SkillCategory>(request);

			_skillCategoryRepository.Update(skillCategoryToUpdate);

			await _unitOfWork.SaveChangesAsync();

			return Unit.Value;
		}
	}
}
