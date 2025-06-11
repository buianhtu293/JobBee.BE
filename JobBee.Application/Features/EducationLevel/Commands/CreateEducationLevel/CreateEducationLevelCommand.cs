using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Application.Models.Response;
using MediatR;

namespace JobBee.Application.Features.EducationLevel.Commands.CreateEducationLevel
{
    public class CreateEducationLevelCommand : IRequest<ApiResponse<CreatEducationLevelDto>>
    {
        public string LevelName { get; set; } = null!;
    }
}
