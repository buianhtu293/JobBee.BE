using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.Skill.Commands.UpdateSkill
{
	public class UpdateSkillHandler : IRequestHandler<UpdateSkillCommand, ApiResponse<UpdateSkillDto>>
	{
		private readonly IMapper _mapper;
		private readonly ISkillRepository _skillRepository;
		private readonly IUnitOfWork<Domain.Entities.Role, Guid> _unitOfWork;

		public UpdateSkillHandler(IMapper mapper,
			ISkillRepository skillRepository,
			IUnitOfWork<Domain.Entities.Role, Guid> unitOfWork)
		{
			_mapper = mapper;
			_skillRepository = skillRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<ApiResponse<UpdateSkillDto>> Handle(UpdateSkillCommand request, CancellationToken cancellationToken)
		{
			var validator = new UpdateSkillValidator(_skillRepository);
			var validatorResult = await validator.ValidateAsync(request);

			if (validatorResult.Errors.Any())
			{
				throw new BadRequestException("Invalid Skill", validatorResult);
			}

			var skillToUpdate = _mapper.Map<Domain.Entities.Skill>(request);

			_skillRepository.Update(skillToUpdate);

			var skillUpdated = _mapper.Map<UpdateSkillDto>(skillToUpdate);
			var data = new ApiResponse<UpdateSkillDto>("Success", 200, skillUpdated);

			await _unitOfWork.SaveChangesAsync();

			return data;

		}
	}
}
