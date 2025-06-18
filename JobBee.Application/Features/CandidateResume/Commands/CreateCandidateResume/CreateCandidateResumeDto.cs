using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Application.Features.CandidateResume.Commands.CreateCandidateResume
{
	public class CreateCandidateResumeDto
	{
		public Guid Id { get; set; }
		public Guid CandidateId { get; set; }
		public string FileName { get; set; } = null!;
		public string FilePath { get; set; } = null!;
		public int FileSize { get; set; }
		public string FileType { get; set; } = null!;
		public bool? IsDefault { get; set; }
		public DateTime? CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
	}
}
