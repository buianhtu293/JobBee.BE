using AutoMapper;
using JobBee.Application.Contracts.Logging;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Application.Features.SkillCategory.Queries.GetAllSkillCategories;
using MediatR;

namespace JobBee.Application.Features.SkillCategory.Commands.DeleteSkillCategory
{
	public class DeleteSkillCategoryCommandHandler : IRequestHandler<DeleteSkillcategoryCommand, Unit>
	{
		private readonly IMapper _mapper;
		private readonly ISkillCategoryRepository _skillCategoryRepository;
		private readonly IAppLogger<GetSkillCategoryQueryHandler> _logger;
		private readonly IUnitOfWork<Domain.Entities.SkillCategory, Guid> _unitOfWork;

		public DeleteSkillCategoryCommandHandler(IMapper mapper,
			ISkillCategoryRepository skillCategoryRepository,
			IAppLogger<GetSkillCategoryQueryHandler> logger,
			IUnitOfWork<Domain.Entities.SkillCategory, Guid> unitOfWork)
		{
			this._mapper = mapper;
			this._skillCategoryRepository = skillCategoryRepository;
			this._logger = logger;
			_unitOfWork = unitOfWork;
		}

		public async Task<Unit> Handle(DeleteSkillcategoryCommand request, CancellationToken cancellationToken)
		{
			var skillCategoryDelete = _skillCategoryRepository.GetById(request.Id);

			if (skillCategoryDelete == null)
			{
				throw new NotFoundException(nameof(Domain.Entities.SkillCategory), request.Id);
			}

			_skillCategoryRepository.Delete(skillCategoryDelete);

			await _unitOfWork.SaveChangesAsync();

			return Unit.Value;
		}
	}
}
