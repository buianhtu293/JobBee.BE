using JobBee.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace JobBee.Persistence.DatabaseContext;

public partial class JobBeeContext : DbContext
{
	public JobBeeContext()
	{
	}

	public JobBeeContext(DbContextOptions<JobBeeContext> options)
		: base(options)
	{
	}

	public virtual DbSet<AdminSetting> AdminSettings { get; set; }

	public virtual DbSet<Candidate> Candidates { get; set; }

	public virtual DbSet<CandidateEducation> CandidateEducations { get; set; }

	public virtual DbSet<CandidateExperience> CandidateExperiences { get; set; }

	public virtual DbSet<CandidatePortfolio> CandidatePortfolios { get; set; }

	public virtual DbSet<CandidatePreference> CandidatePreferences { get; set; }

	public virtual DbSet<CandidateResume> CandidateResumes { get; set; }

	public virtual DbSet<CandidateSkill> CandidateSkills { get; set; }

	public virtual DbSet<CompanyPhoto> CompanyPhotos { get; set; }

	public virtual DbSet<CompanySize> CompanySizes { get; set; }

	public virtual DbSet<EducationLevel> EducationLevels { get; set; }

	public virtual DbSet<EmailLog> EmailLogs { get; set; }

	public virtual DbSet<EmailSetting> EmailSettings { get; set; }

	public virtual DbSet<EmailTemplate> EmailTemplates { get; set; }

	public virtual DbSet<Employer> Employers { get; set; }

	public virtual DbSet<EmployerBenefit> EmployerBenefits { get; set; }

	public virtual DbSet<EmployerReview> EmployerReviews { get; set; }

	public virtual DbSet<EmployerSocialMedium> EmployerSocialMedia { get; set; }

	public virtual DbSet<ExperienceLevel> ExperienceLevels { get; set; }

	public virtual DbSet<Industry> Industries { get; set; }

	public virtual DbSet<Job> Jobs { get; set; }

	public virtual DbSet<JobAlert> JobAlerts { get; set; }

	public virtual DbSet<JobApplication> JobApplications { get; set; }

	public virtual DbSet<JobCategory> JobCategories { get; set; }

	public virtual DbSet<JobSearchLog> JobSearchLogs { get; set; }

	public virtual DbSet<JobSkill> JobSkills { get; set; }

	public virtual DbSet<JobType> JobTypes { get; set; }

	public virtual DbSet<Notification> Notifications { get; set; }

	public virtual DbSet<NotificationType> NotificationTypes { get; set; }

	public virtual DbSet<Payment> Payments { get; set; }

	public virtual DbSet<ReportedContent> ReportedContents { get; set; }

	public virtual DbSet<Role> Roles { get; set; }

	public virtual DbSet<RoleClaim> RoleClaims { get; set; }

	public virtual DbSet<SavedCandidate> SavedCandidates { get; set; }

	public virtual DbSet<SavedJob> SavedJobs { get; set; }

	public virtual DbSet<Skill> Skills { get; set; }

	public virtual DbSet<SkillCategory> SkillCategories { get; set; }

	public virtual DbSet<Subscription> Subscriptions { get; set; }

	public virtual DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }

	public virtual DbSet<User> Users { get; set; }

	public virtual DbSet<UserActivityLog> UserActivityLogs { get; set; }

	public virtual DbSet<UserClaim> UserClaims { get; set; }

	public virtual DbSet<UserLogin> UserLogins { get; set; }

	public virtual DbSet<UserToken> UserTokens { get; set; }

	public virtual DbSet<WebsiteReview> WebsiteReviews { get; set; }

	//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	//	=> optionsBuilder.UseNpgsql("Name=ConnectionStrings:JobBeeDatabaseConnectionString");

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<AdminSetting>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("AdminSettings_pkey");

			entity.HasIndex(e => e.SettingName, "AdminSettings_SettingName_key").IsUnique();

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
			entity.Property(e => e.SettingName).HasMaxLength(100);
			entity.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone");
		});

		modelBuilder.Entity<Candidate>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("Candidates_pkey");

			entity.HasIndex(e => e.UserId, "Candidates_UserId_key").IsUnique();

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.City).HasMaxLength(100);
			entity.Property(e => e.Country).HasMaxLength(100);
			entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
			entity.Property(e => e.CurrentSalary).HasPrecision(12, 2);
			entity.Property(e => e.FirstName).HasMaxLength(100);
			entity.Property(e => e.Gender).HasMaxLength(20);
			entity.Property(e => e.Headline).HasMaxLength(255);
			entity.Property(e => e.LastName).HasMaxLength(100);
			entity.Property(e => e.Phone).HasMaxLength(20);
			entity.Property(e => e.PostalCode).HasMaxLength(20);
			entity.Property(e => e.ProfilePicture).HasMaxLength(255);
			entity.Property(e => e.SalaryExpectation).HasPrecision(12, 2);
			entity.Property(e => e.State).HasMaxLength(100);
			entity.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone");

			entity.HasOne(d => d.User).WithOne(p => p.Candidate)
				.HasForeignKey<Candidate>(d => d.UserId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("Candidates_UserId_fkey");
		});

		modelBuilder.Entity<CandidateEducation>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("CandidateEducation_pkey");

			entity.ToTable("CandidateEducation");

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
			entity.Property(e => e.FieldOfStudy).HasMaxLength(255);
			entity.Property(e => e.InstitutionName).HasMaxLength(255);
			entity.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone");

			entity.HasOne(d => d.Candidate).WithMany(p => p.CandidateEducations)
				.HasForeignKey(d => d.CandidateId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("CandidateEducation_CandidateId_fkey");

			entity.HasOne(d => d.EducationLevel).WithMany(p => p.CandidateEducations)
				.HasForeignKey(d => d.EducationLevelId)
				.HasConstraintName("CandidateEducation_EducationLevelId_fkey");
		});

		modelBuilder.Entity<CandidateExperience>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("CandidateExperience_pkey");

			entity.ToTable("CandidateExperience");

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.CompanyName).HasMaxLength(255);
			entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
			entity.Property(e => e.Position).HasMaxLength(255);
			entity.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone");

			entity.HasOne(d => d.Candidate).WithMany(p => p.CandidateExperiences)
				.HasForeignKey(d => d.CandidateId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("CandidateExperience_CandidateId_fkey");
		});

		modelBuilder.Entity<CandidatePortfolio>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("CandidatePortfolio_pkey");

			entity.ToTable("CandidatePortfolio");

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
			entity.Property(e => e.ImageUrl).HasMaxLength(255);
			entity.Property(e => e.ProjectUrl).HasMaxLength(255);
			entity.Property(e => e.Title).HasMaxLength(255);
			entity.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone");

			entity.HasOne(d => d.Candidate).WithMany(p => p.CandidatePortfolios)
				.HasForeignKey(d => d.CandidateId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("CandidatePortfolio_CandidateId_fkey");
		});

		modelBuilder.Entity<CandidatePreference>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("CandidatePreferences_pkey");

			entity.HasIndex(e => e.CandidateId, "CandidatePreferences_CandidateId_key").IsUnique();

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
			entity.Property(e => e.JobType).HasMaxLength(50);
			entity.Property(e => e.MinSalary).HasPrecision(12, 2);
			entity.Property(e => e.PreferredLocation).HasMaxLength(255);
			entity.Property(e => e.RemotePreference).HasMaxLength(50);
			entity.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone");

			entity.HasOne(d => d.Candidate).WithOne(p => p.CandidatePreference)
				.HasForeignKey<CandidatePreference>(d => d.CandidateId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("CandidatePreferences_CandidateId_fkey");
		});

		modelBuilder.Entity<CandidateResume>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("CandidateResumes_pkey");

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
			entity.Property(e => e.FileName).HasMaxLength(255);
			entity.Property(e => e.FilePath).HasMaxLength(255);
			entity.Property(e => e.FileType).HasMaxLength(50);
			entity.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone");

			entity.HasOne(d => d.Candidate).WithMany(p => p.CandidateResumes)
				.HasForeignKey(d => d.CandidateId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("CandidateResumes_CandidateId_fkey");
		});

		modelBuilder.Entity<CandidateSkill>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("CandidateSkills_pkey");

			entity.HasIndex(e => new { e.CandidateId, e.SkillId }, "CandidateSkills_CandidateId_SkillId_key").IsUnique();

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");

			entity.HasOne(d => d.Candidate).WithMany(p => p.CandidateSkills)
				.HasForeignKey(d => d.CandidateId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("CandidateSkills_CandidateId_fkey");

			entity.HasOne(d => d.Skill).WithMany(p => p.CandidateSkills)
				.HasForeignKey(d => d.SkillId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("CandidateSkills_SkillId_fkey");
		});

		modelBuilder.Entity<CompanyPhoto>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("CompanyPhotos_pkey");

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.Caption).HasMaxLength(255);
			entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
			entity.Property(e => e.PhotoUrl).HasMaxLength(255);

			entity.HasOne(d => d.Employer).WithMany(p => p.CompanyPhotos)
				.HasForeignKey(d => d.EmployerId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("CompanyPhotos_EmployerId_fkey");
		});

		modelBuilder.Entity<CompanySize>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("CompanySizes_pkey");

			entity.HasIndex(e => e.SizeRange, "CompanySizes_SizeRange_key").IsUnique();

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.SizeRange).HasMaxLength(50);
		});

		modelBuilder.Entity<EducationLevel>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("EducationLevels_pkey");

			entity.HasIndex(e => e.LevelName, "EducationLevels_LevelName_key").IsUnique();

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.LevelName).HasMaxLength(100);
		});

		modelBuilder.Entity<EmailLog>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("EmailLogs_pkey");

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.RecipientEmail).HasMaxLength(255);
			entity.Property(e => e.SentAt).HasColumnType("timestamp without time zone");
			entity.Property(e => e.Status).HasMaxLength(50);
			entity.Property(e => e.Subject).HasMaxLength(255);

			entity.HasOne(d => d.Template).WithMany(p => p.EmailLogs)
				.HasForeignKey(d => d.TemplateId)
				.HasConstraintName("EmailLogs_TemplateId_fkey");
		});

		modelBuilder.Entity<EmailSetting>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("EmailSettings_pkey");

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
			entity.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone");

			entity.HasOne(d => d.User).WithMany(p => p.EmailSettings)
				.HasForeignKey(d => d.UserId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("EmailSettings_UserId_fkey");
		});

		modelBuilder.Entity<EmailTemplate>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("EmailTemplates_pkey");

			entity.HasIndex(e => e.TemplateName, "EmailTemplates_TemplateName_key").IsUnique();

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
			entity.Property(e => e.Subject).HasMaxLength(255);
			entity.Property(e => e.TemplateName).HasMaxLength(100);
			entity.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone");
		});

		modelBuilder.Entity<Employer>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("Employers_pkey");

			entity.HasIndex(e => e.UserId, "Employers_UserId_key").IsUnique();

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.CompanyLogo).HasMaxLength(255);
			entity.Property(e => e.CompanyName).HasMaxLength(255);
			entity.Property(e => e.ContactEmail).HasMaxLength(255);
			entity.Property(e => e.ContactPersonName).HasMaxLength(255);
			entity.Property(e => e.ContactPhone).HasMaxLength(20);
			entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
			entity.Property(e => e.HeadquartersCity).HasMaxLength(100);
			entity.Property(e => e.HeadquartersCountry).HasMaxLength(100);
			entity.Property(e => e.HeadquartersState).HasMaxLength(100);
			entity.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone");
			entity.Property(e => e.WebsiteUrl).HasMaxLength(255);

			entity.HasOne(d => d.CompanySize).WithMany(p => p.Employers)
				.HasForeignKey(d => d.CompanySizeId)
				.HasConstraintName("Employers_CompanySizeId_fkey");

			entity.HasOne(d => d.Industry).WithMany(p => p.Employers)
				.HasForeignKey(d => d.IndustryId)
				.HasConstraintName("Employers_IndustryId_fkey");

			entity.HasOne(d => d.User).WithOne(p => p.Employer)
				.HasForeignKey<Employer>(d => d.UserId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("Employers_UserId_fkey");
		});

		modelBuilder.Entity<EmployerBenefit>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("EmployerBenefits_pkey");

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.BenefitName).HasMaxLength(255);
			entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
			entity.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone");

			entity.HasOne(d => d.Employer).WithMany(p => p.EmployerBenefits)
				.HasForeignKey(d => d.EmployerId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("EmployerBenefits_EmployerId_fkey");
		});

		modelBuilder.Entity<EmployerReview>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("EmployerReviews_pkey");

			entity.HasIndex(e => new { e.EmployerId, e.CandidateId }, "EmployerReviews_EmployerId_CandidateId_key").IsUnique();

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
			entity.Property(e => e.Status)
				.HasMaxLength(50)
				.HasDefaultValueSql("'Pending'::character varying");
			entity.Property(e => e.Title).HasMaxLength(255);
			entity.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone");

			entity.HasOne(d => d.Candidate).WithMany(p => p.EmployerReviews)
				.HasForeignKey(d => d.CandidateId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("EmployerReviews_CandidateId_fkey");

			entity.HasOne(d => d.Employer).WithMany(p => p.EmployerReviews)
				.HasForeignKey(d => d.EmployerId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("EmployerReviews_EmployerId_fkey");
		});

		modelBuilder.Entity<EmployerSocialMedium>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("EmployerSocialMedia_pkey");

			entity.HasIndex(e => new { e.EmployerId, e.PlatformName }, "EmployerSocialMedia_EmployerId_PlatformName_key").IsUnique();

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
			entity.Property(e => e.PlatformName).HasMaxLength(50);
			entity.Property(e => e.ProfileUrl).HasMaxLength(255);
			entity.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone");

			entity.HasOne(d => d.Employer).WithMany(p => p.EmployerSocialMedia)
				.HasForeignKey(d => d.EmployerId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("EmployerSocialMedia_EmployerId_fkey");
		});

		modelBuilder.Entity<ExperienceLevel>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("ExperienceLevels_pkey");

			entity.HasIndex(e => e.LevelName, "ExperienceLevels_LevelName_key").IsUnique();

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.LevelName).HasMaxLength(50);
		});

		modelBuilder.Entity<Industry>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("Industries_pkey");

			entity.HasIndex(e => e.IndustryName, "Industries_IndustryName_key").IsUnique();

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.IndustryName).HasMaxLength(255);
		});

		modelBuilder.Entity<Job>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("Jobs_pkey");

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.ApplicationsCount).HasDefaultValue(0);
			entity.Property(e => e.Currency).HasMaxLength(10);
			entity.Property(e => e.ExpiresAt).HasColumnType("timestamp without time zone");
			entity.Property(e => e.LocationCity).HasMaxLength(100);
			entity.Property(e => e.LocationCountry).HasMaxLength(100);
			entity.Property(e => e.LocationState).HasMaxLength(100);
			entity.Property(e => e.MaxSalary).HasPrecision(12, 2);
			entity.Property(e => e.MinSalary).HasPrecision(12, 2);
			entity.Property(e => e.PostedAt).HasColumnType("timestamp without time zone");
			entity.Property(e => e.SalaryPeriod).HasMaxLength(20);
			entity.Property(e => e.Title).HasMaxLength(255);
			entity.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone");
			entity.Property(e => e.ViewsCount).HasDefaultValue(0);

			entity.HasOne(d => d.Employer).WithMany(p => p.Jobs)
				.HasForeignKey(d => d.EmployerId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("Jobs_EmployerId_fkey");

			entity.HasOne(d => d.ExperienceLevel).WithMany(p => p.Jobs)
				.HasForeignKey(d => d.ExperienceLevelId)
				.HasConstraintName("Jobs_ExperienceLevelId_fkey");

			entity.HasOne(d => d.JobCategory).WithMany(p => p.Jobs)
				.HasForeignKey(d => d.JobCategoryId)
				.HasConstraintName("Jobs_JobCategoryId_fkey");

			entity.HasOne(d => d.JobType).WithMany(p => p.Jobs)
				.HasForeignKey(d => d.JobTypeId)
				.HasConstraintName("Jobs_JobTypeId_fkey");

			entity.HasOne(d => d.MinEducation).WithMany(p => p.Jobs)
				.HasForeignKey(d => d.MinEducationId)
				.HasConstraintName("Jobs_MinEducationId_fkey");
		});

		modelBuilder.Entity<JobAlert>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("JobAlerts_pkey");

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.AlertName).HasMaxLength(255);
			entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
			entity.Property(e => e.Frequency).HasMaxLength(20);
			entity.Property(e => e.Location).HasMaxLength(255);
			entity.Property(e => e.MinSalary).HasPrecision(12, 2);
			entity.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone");

			entity.HasOne(d => d.Candidate).WithMany(p => p.JobAlerts)
				.HasForeignKey(d => d.CandidateId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("JobAlerts_CandidateId_fkey");

			entity.HasOne(d => d.JobCategory).WithMany(p => p.JobAlerts)
				.HasForeignKey(d => d.JobCategoryId)
				.HasConstraintName("JobAlerts_JobCategoryId_fkey");

			entity.HasOne(d => d.JobType).WithMany(p => p.JobAlerts)
				.HasForeignKey(d => d.JobTypeId)
				.HasConstraintName("JobAlerts_JobTypeId_fkey");
		});

		modelBuilder.Entity<JobApplication>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("JobApplications_pkey");

			entity.HasIndex(e => new { e.JobId, e.CandidateId }, "JobApplications_JobId_CandidateId_key").IsUnique();

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.AppliedAt).HasColumnType("timestamp without time zone");
			entity.Property(e => e.Status)
				.HasMaxLength(50)
				.HasDefaultValueSql("'Pending'::character varying");
			entity.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone");

			entity.HasOne(d => d.Candidate).WithMany(p => p.JobApplications)
				.HasForeignKey(d => d.CandidateId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("JobApplications_CandidateId_fkey");

			entity.HasOne(d => d.Job).WithMany(p => p.JobApplications)
				.HasForeignKey(d => d.JobId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("JobApplications_JobId_fkey");

			entity.HasOne(d => d.Resume).WithMany(p => p.JobApplications)
				.HasForeignKey(d => d.ResumeId)
				.HasConstraintName("JobApplications_ResumeId_fkey");
		});

		modelBuilder.Entity<JobCategory>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("JobCategories_pkey");

			entity.HasIndex(e => e.CategoryName, "JobCategories_CategoryName_key").IsUnique();

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.CategoryName).HasMaxLength(255);
			entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");

			entity.HasOne(d => d.ParentCategory).WithMany(p => p.InverseParentCategory)
				.HasForeignKey(d => d.ParentCategoryId)
				.HasConstraintName("JobCategories_ParentCategoryId_fkey");
		});

		modelBuilder.Entity<JobSearchLog>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("JobSearchLogs_pkey");

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.Location).HasMaxLength(255);
			entity.Property(e => e.MaxSalary).HasPrecision(12, 2);
			entity.Property(e => e.MinSalary).HasPrecision(12, 2);
			entity.Property(e => e.SearchDate).HasColumnType("timestamp without time zone");

			entity.HasOne(d => d.JobCategory).WithMany(p => p.JobSearchLogs)
				.HasForeignKey(d => d.JobCategoryId)
				.HasConstraintName("JobSearchLogs_JobCategoryId_fkey");

			entity.HasOne(d => d.JobType).WithMany(p => p.JobSearchLogs)
				.HasForeignKey(d => d.JobTypeId)
				.HasConstraintName("JobSearchLogs_JobTypeId_fkey");

			entity.HasOne(d => d.User).WithMany(p => p.JobSearchLogs)
				.HasForeignKey(d => d.UserId)
				.HasConstraintName("JobSearchLogs_UserId_fkey");
		});

		modelBuilder.Entity<JobSkill>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("JobSkills_pkey");

			entity.HasIndex(e => new { e.JobId, e.SkillId }, "JobSkills_JobId_SkillId_key").IsUnique();

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");

			entity.HasOne(d => d.Job).WithMany(p => p.JobSkills)
				.HasForeignKey(d => d.JobId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("JobSkills_JobId_fkey");

			entity.HasOne(d => d.Skill).WithMany(p => p.JobSkills)
				.HasForeignKey(d => d.SkillId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("JobSkills_SkillId_fkey");
		});

		modelBuilder.Entity<JobType>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("JobTypes_pkey");

			entity.HasIndex(e => e.TypeName, "JobTypes_TypeName_key").IsUnique();

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.TypeName).HasMaxLength(50);
		});

		modelBuilder.Entity<Notification>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("Notifications_pkey");

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
			entity.Property(e => e.RelatedEntityType).HasMaxLength(50);
			entity.Property(e => e.Title).HasMaxLength(255);

			entity.HasOne(d => d.NotificationType).WithMany(p => p.Notifications)
				.HasForeignKey(d => d.NotificationTypeId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("Notifications_NotificationTypeId_fkey");

			entity.HasOne(d => d.User).WithMany(p => p.Notifications)
				.HasForeignKey(d => d.UserId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("Notifications_UserId_fkey");
		});

		modelBuilder.Entity<NotificationType>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("NotificationTypes_pkey");

			entity.HasIndex(e => e.TypeName, "NotificationTypes_TypeName_key").IsUnique();

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
			entity.Property(e => e.TypeName).HasMaxLength(100);
		});

		modelBuilder.Entity<Payment>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("Payments_pkey");

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.Amount).HasPrecision(10, 2);
			entity.Property(e => e.Currency).HasMaxLength(10);
			entity.Property(e => e.PaymentDate).HasColumnType("timestamp without time zone");
			entity.Property(e => e.PaymentMethod).HasMaxLength(50);
			entity.Property(e => e.Status).HasMaxLength(50);
			entity.Property(e => e.TransactionId).HasMaxLength(255);

			entity.HasOne(d => d.Subscription).WithMany(p => p.Payments)
				.HasForeignKey(d => d.SubscriptionId)
				.HasConstraintName("Payments_SubscriptionId_fkey");

			entity.HasOne(d => d.User).WithMany(p => p.Payments)
				.HasForeignKey(d => d.UserId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("Payments_UserId_fkey");
		});

		modelBuilder.Entity<ReportedContent>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("ReportedContent_pkey");

			entity.ToTable("ReportedContent");

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.ContentType).HasMaxLength(50);
			entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
			entity.Property(e => e.Reason).HasMaxLength(255);
			entity.Property(e => e.Status)
				.HasMaxLength(50)
				.HasDefaultValueSql("'Pending'::character varying");
			entity.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone");

			entity.HasOne(d => d.ReporterUser).WithMany(p => p.ReportedContents)
				.HasForeignKey(d => d.ReporterUserId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("ReportedContent_ReporterUserId_fkey");
		});

		modelBuilder.Entity<Role>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("Roles_pkey");

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.Name).HasMaxLength(256);
			entity.Property(e => e.NormalizedName).HasMaxLength(256);
		});

		modelBuilder.Entity<RoleClaim>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("RoleClaims_pkey");

			entity.HasOne(d => d.Role).WithMany(p => p.RoleClaims)
				.HasForeignKey(d => d.RoleId)
				.HasConstraintName("RoleClaims_RoleId_fkey");
		});

		modelBuilder.Entity<SavedCandidate>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("SavedCandidates_pkey");

			entity.HasIndex(e => new { e.EmployerId, e.CandidateId }, "SavedCandidates_EmployerId_CandidateId_key").IsUnique();

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.SavedAt).HasColumnType("timestamp without time zone");

			entity.HasOne(d => d.Candidate).WithMany(p => p.SavedCandidates)
				.HasForeignKey(d => d.CandidateId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("SavedCandidates_CandidateId_fkey");

			entity.HasOne(d => d.Employer).WithMany(p => p.SavedCandidates)
				.HasForeignKey(d => d.EmployerId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("SavedCandidates_EmployerId_fkey");
		});

		modelBuilder.Entity<SavedJob>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("SavedJobs_pkey");

			entity.HasIndex(e => new { e.CandidateId, e.JobId }, "SavedJobs_CandidateId_JobId_key").IsUnique();

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.SavedAt).HasColumnType("timestamp without time zone");

			entity.HasOne(d => d.Candidate).WithMany(p => p.SavedJobs)
				.HasForeignKey(d => d.CandidateId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("SavedJobs_CandidateId_fkey");

			entity.HasOne(d => d.Job).WithMany(p => p.SavedJobs)
				.HasForeignKey(d => d.JobId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("SavedJobs_JobId_fkey");
		});

		modelBuilder.Entity<Skill>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("Skills_pkey");

			entity.HasIndex(e => e.SkillName, "Skills_SkillName_key").IsUnique();

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.SkillName).HasMaxLength(100);

			entity.HasOne(d => d.Category).WithMany(p => p.Skills)
				.HasForeignKey(d => d.CategoryId)
				.HasConstraintName("Skills_CategoryId_fkey");
		});

		modelBuilder.Entity<SkillCategory>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("SkillCategories_pkey");

			entity.HasIndex(e => e.CategoryName, "SkillCategories_CategoryName_key").IsUnique();

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.CategoryName).HasMaxLength(100);
		});

		modelBuilder.Entity<Subscription>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("Subscriptions_pkey");

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
			entity.Property(e => e.EndDate).HasColumnType("timestamp without time zone");
			entity.Property(e => e.PaymentMethod).HasMaxLength(50);
			entity.Property(e => e.RenewalDate).HasColumnType("timestamp without time zone");
			entity.Property(e => e.StartDate).HasColumnType("timestamp without time zone");
			entity.Property(e => e.Status).HasMaxLength(50);
			entity.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone");

			entity.HasOne(d => d.Plan).WithMany(p => p.Subscriptions)
				.HasForeignKey(d => d.PlanId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("Subscriptions_PlanId_fkey");

			entity.HasOne(d => d.User).WithMany(p => p.Subscriptions)
				.HasForeignKey(d => d.UserId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("Subscriptions_UserId_fkey");
		});

		modelBuilder.Entity<SubscriptionPlan>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("SubscriptionPlans_pkey");

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.BillingCycle).HasMaxLength(20);
			entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
			entity.Property(e => e.Currency).HasMaxLength(10);
			entity.Property(e => e.PlanName).HasMaxLength(100);
			entity.Property(e => e.PlanType).HasMaxLength(50);
			entity.Property(e => e.Price).HasPrecision(10, 2);
			entity.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone");
		});

		modelBuilder.Entity<User>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("Users_pkey");

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.Email).HasMaxLength(256);
			entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
			entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
			entity.Property(e => e.UserName).HasMaxLength(256);

			entity.HasMany(d => d.Roles).WithMany(p => p.Users)
				.UsingEntity<Dictionary<string, object>>(
					"UserRole",
					r => r.HasOne<Role>().WithMany()
						.HasForeignKey("RoleId")
						.HasConstraintName("UserRoles_RoleId_fkey"),
					l => l.HasOne<User>().WithMany()
						.HasForeignKey("UserId")
						.HasConstraintName("UserRoles_UserId_fkey"),
					j =>
					{
						j.HasKey("UserId", "RoleId").HasName("UserRoles_pkey");
						j.ToTable("UserRoles");
					});
		});

		modelBuilder.Entity<UserActivityLog>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("UserActivityLogs_pkey");

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.ActivityType).HasMaxLength(50);
			entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
			entity.Property(e => e.IpAddress).HasMaxLength(45);

			entity.HasOne(d => d.User).WithMany(p => p.UserActivityLogs)
				.HasForeignKey(d => d.UserId)
				.HasConstraintName("UserActivityLogs_UserId_fkey");
		});

		modelBuilder.Entity<UserClaim>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("UserClaims_pkey");

			entity.HasOne(d => d.User).WithMany(p => p.UserClaims)
				.HasForeignKey(d => d.UserId)
				.HasConstraintName("UserClaims_UserId_fkey");
		});

		modelBuilder.Entity<UserLogin>(entity =>
		{
			entity.HasKey(e => new { e.LoginProvider, e.ProviderKey }).HasName("UserLogins_pkey");

			entity.Property(e => e.LoginProvider).HasMaxLength(128);
			entity.Property(e => e.ProviderKey).HasMaxLength(128);
			entity.Property(e => e.ProviderDisplayName).HasMaxLength(256);

			entity.HasOne(d => d.User).WithMany(p => p.UserLogins)
				.HasForeignKey(d => d.UserId)
				.HasConstraintName("UserLogins_UserId_fkey");
		});

		modelBuilder.Entity<UserToken>(entity =>
		{
			entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name }).HasName("UserTokens_pkey");

			entity.Property(e => e.LoginProvider).HasMaxLength(128);
			entity.Property(e => e.Name).HasMaxLength(128);

			entity.HasOne(d => d.User).WithMany(p => p.UserTokens)
				.HasForeignKey(d => d.UserId)
				.HasConstraintName("UserTokens_UserId_fkey");
		});

		modelBuilder.Entity<WebsiteReview>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("WebsiteReviews_pkey");

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
			entity.Property(e => e.Status)
				.HasMaxLength(50)
				.HasDefaultValueSql("'Pending'::character varying");
			entity.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone");

			entity.HasOne(d => d.User).WithMany(p => p.WebsiteReviews)
				.HasForeignKey(d => d.UserId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("WebsiteReviews_UserId_fkey");
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
