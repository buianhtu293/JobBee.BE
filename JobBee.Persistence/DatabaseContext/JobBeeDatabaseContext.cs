using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobBee.Domain;
using JobBee.Domain.Common;
using JobBee.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace JobBee.Persistence.DatabaseContext
{
	public class JobBeeDatabaseContext : DbContext
	{
        public JobBeeDatabaseContext(DbContextOptions<JobBeeDatabaseContext> options) : base(options)
        {
            
        }

        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
		public DbSet<LeaveRequest> LeaveRequests { get; set; }
		public DbSet<Test> Tests { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(JobBeeDatabaseContext).Assembly);

			//modelBuilder.ApplyConfiguration(new LeaveTypeConfiguration());

			base.OnModelCreating(modelBuilder);
		}

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			foreach(var entry in base.ChangeTracker.Entries<BaseEntity<Guid>>()
				.Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
			{
				entry.Entity.DateModified = DateTime.UtcNow;

				if (entry.State == EntityState.Added)
				{
					entry.Entity.DateCreated = DateTime.UtcNow;
				}
			}

			return base.SaveChangesAsync(cancellationToken);
		}
	}
}
