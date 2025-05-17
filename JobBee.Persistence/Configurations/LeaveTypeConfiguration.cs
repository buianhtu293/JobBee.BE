using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using JobBee.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobBee.Persistence.Configurations
{
	public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
	{
		public void Configure(EntityTypeBuilder<LeaveType> builder)
		{
			//builder.HasData(
			//	new LeaveType
			//	{
			//		Id = new Guid(),
			//		Name = "Vacation",
			//		DefaultDays = 10,
			//		DateCreated = DateTime.Now,
			//		DateModified = DateTime.Now
			//	}
			//	);

			//builder.Property(q => q.Name)
			//	.IsRequired()
			//	.HasMaxLength(100);
		}
	}
}
