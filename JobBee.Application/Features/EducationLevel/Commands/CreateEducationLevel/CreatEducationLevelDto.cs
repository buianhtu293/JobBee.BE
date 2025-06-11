using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Application.Features.EducationLevel.Commands.CreateEducationLevel
{
    public class CreatEducationLevelDto
    {
        public Guid Id { get; set; }
        public string LevelName { get; set; } = null!;
    }
}
