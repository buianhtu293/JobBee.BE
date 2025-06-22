using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBee.Application.Features.CandidateResume.Queries.GetAllCandidateResume
{
	public class CandidateResumeDto
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
