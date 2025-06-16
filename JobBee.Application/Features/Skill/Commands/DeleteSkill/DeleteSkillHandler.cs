using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using MediatR;

namespace JobBee.Application.Features.Skill.Commands.DeleteSkill
{
	public class DeleteSkillHandler : IRequestHandler<DeleteSkillCommand, Unit>
	{
		private readonly IMapper _mapper;
		private readonly ISkillRepository _skillRepository;
		private readonly IUnitOfWork<Domain.Entities.Role, Guid> _unitOfWork;

		public DeleteSkillHandler(IMapper mapper,
			ISkillRepository skillRepository,
			IUnitOfWork<Domain.Entities.Role, Guid> unitOfWork)
		{
			_mapper = mapper;
			_skillRepository = skillRepository;
			_unitOfWork = unitOfWork;
		}
		public async Task<Unit> Handle(DeleteSkillCommand request, CancellationToken cancellationToken)
		{
			var skillToDelete = _skillRepository.GetById(request.Id);
			
			if (skillToDelete == null)
			{
				throw new NotFoundException(nameof(Domain.Entities.Skill), request.Id);
			}

			_skillRepository.Delete(skillToDelete);

			await _unitOfWork.SaveChangesAsync();

			return Unit.Value;

		}
	}
}
