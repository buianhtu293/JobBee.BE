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

namespace JobBee.Application.Features.EducationLevel.Commands.CreateEducationLevel
{
    public class CreateEducationLevelCommandHandler : IRequestHandler<CreateEducationLevelCommand, ApiResponse<CreatEducationLevelDto>>
    {
        private readonly IMapper _mapper;
        private readonly IEducationLevelRepository _educationLevel;
        private readonly IUnitOfWork<Domain.Entities.EducationLevel, Guid> _unitOfWork;

        public CreateEducationLevelCommandHandler(IMapper mapper,
            IEducationLevelRepository educationLevel,
            IUnitOfWork<Domain.Entities.EducationLevel, Guid> unitOfWork)
        {
            _mapper = mapper;
            _educationLevel = educationLevel;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<CreatEducationLevelDto>> Handle(CreateEducationLevelCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateEducationLevelCommandValidator(_educationLevel);
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.Errors.Any())
            {
                throw new BadRequestException("Invalid Education Level", validatorResult);
            }

            var educationLevelToCreate = _mapper.Map<Domain.Entities.EducationLevel>(request);
            educationLevelToCreate.Id = Guid.NewGuid();

            _educationLevel.Insert(educationLevelToCreate);

            var educationLevelCreated = _mapper.Map<CreatEducationLevelDto>(educationLevelToCreate);
            var data = new ApiResponse<CreatEducationLevelDto>("Success", 201, educationLevelCreated);

            await _unitOfWork.SaveChangesAsync();

            return data;

        }
    }
}
