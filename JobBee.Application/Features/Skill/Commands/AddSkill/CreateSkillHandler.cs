using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.Skill.Commands.AddSkill
{
	public class CreateSkillHandler : IRequestHandler<CreateSkillCommand, ApiResponse<CreateSkillDto>>
	{
		private readonly IMapper _mapper;
		private readonly ISkillRepository _skillRepository;
		private readonly IUnitOfWork<Domain.Entities.Role, Guid> _unitOfWork;

		public CreateSkillHandler(IMapper mapper, 
			ISkillRepository skillRepository, 
			IUnitOfWork<Domain.Entities.Role, Guid> unitOfWork)
		{
			_mapper = mapper;
			_skillRepository = skillRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<ApiResponse<CreateSkillDto>> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
		{
			var validator = new CreateSkillValidator(_skillRepository);
			var validatorResult = await validator .ValidateAsync(request);

			if (validatorResult.Errors.Any())
			{
				throw new BadRequestException("Invalid Skill", validatorResult);
			}

			var skillToCreate = _mapper.Map<Domain.Entities.Skill>(request);
			skillToCreate.Id = Guid.NewGuid();

			_skillRepository.Insert(skillToCreate);

			var skillCreated = _mapper.Map<CreateSkillDto>(skillToCreate);
			var data = new ApiResponse<CreateSkillDto>("Success", 200, skillCreated);

			await _unitOfWork.SaveChangesAsync();

			return data;
		}
	}
}
