using JobBee.Domain.Entities;
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

	public virtual DbSet<AdminSetting> admin_settings { get; set; }
	public virtual DbSet<Candidate> candidates { get; set; }
	public virtual DbSet<CandidateEducation> candidate_educations { get; set; }
	public virtual DbSet<CandidateExperience> candidate_experiences { get; set; }
	public virtual DbSet<CandidatePortfolio> candidate_portfolios { get; set; }
	public virtual DbSet<CandidatePreference> candidate_preferences { get; set; }
	public virtual DbSet<CandidateResume> candidate_resumes { get; set; }
	public virtual DbSet<CandidateSkill> candidate_skills { get; set; }
	public virtual DbSet<CompanyPhoto> company_photos { get; set; }
	public virtual DbSet<CompanySize> company_sizes { get; set; }
	public virtual DbSet<EducationLevel> education_levels { get; set; }
	public virtual DbSet<EmailLog> email_logs { get; set; }
	public virtual DbSet<EmailSetting> email_settings { get; set; }
	public virtual DbSet<EmailTemplate> email_templates { get; set; }
	public virtual DbSet<Employer> employers { get; set; }
	public virtual DbSet<EmployerBenefit> employer_benefits { get; set; }
	public virtual DbSet<EmployerReview> employer_reviews { get; set; }
	public virtual DbSet<EmployerSocialMedia> employer_social_media { get; set; }
	public virtual DbSet<ExperienceLevel> experience_levels { get; set; }
	public virtual DbSet<Industry> industries { get; set; }
	public virtual DbSet<Job> jobs { get; set; }
	public virtual DbSet<JobAlert> job_alerts { get; set; }
	public virtual DbSet<JobApplication> job_applications { get; set; }
	public virtual DbSet<JobCategory> job_categories { get; set; }
	public virtual DbSet<JobSearchLog> job_search_logs { get; set; }
	public virtual DbSet<JobSkill> job_skills { get; set; }
	public virtual DbSet<JobType> job_types { get; set; }
	public virtual DbSet<Notification> notifications { get; set; }
	public virtual DbSet<NotificationType> notification_types { get; set; }
	public virtual DbSet<Payment> payments { get; set; }
	public virtual DbSet<ReportedContent> reported_content { get; set; }
	public virtual DbSet<Role> roles { get; set; }
	public virtual DbSet<RoleClaim> role_claims { get; set; }
	public virtual DbSet<SavedCandidate> saved_candidates { get; set; }
	public virtual DbSet<SavedJob> saved_jobs { get; set; }
	public virtual DbSet<Skill> skills { get; set; }
	public virtual DbSet<SkillCategory> skill_categories { get; set; }
	public virtual DbSet<Subscription> subscriptions { get; set; }
	public virtual DbSet<SubscriptionPlan> subscription_plans { get; set; }
	public virtual DbSet<User> users { get; set; }
	public virtual DbSet<UserActivityLog> user_activity_logs { get; set; }
	public virtual DbSet<UserClaim> user_claims { get; set; }
	public virtual DbSet<UserLogin> user_logins { get; set; }
	public virtual DbSet<UserToken> user_tokens { get; set; }
	public virtual DbSet<WebsiteReview> website_reviews { get; set; }

	//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	//    => optionsBuilder.UseNpgsql("Name=ConnectionStrings:JobBeeDatabaseConnectionString");

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<AdminSetting>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("admin_settings_pkey");
			entity.ToTable("admin_settings");

			entity.HasIndex(e => e.SettingName, "admin_settings_setting_name_key").IsUnique();

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
			entity.Property(e => e.SettingName).HasMaxLength(100);
			entity.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone");
		});

		modelBuilder.Entity<Candidate>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("candidates_pkey");
			entity.ToTable("candidates");

			entity.HasIndex(e => e.UserId, "candidates_user_id_key").IsUnique();

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
				.HasConstraintName("candidates_user_id_fkey");
		});

		modelBuilder.Entity<CandidateEducation>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("candidate_educations_pkey");
			entity.ToTable("candidate_educations");

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
			entity.Property(e => e.FieldOfStudy).HasMaxLength(255);
			entity.Property(e => e.InstitutionName).HasMaxLength(255);
			entity.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone");

			entity.HasOne(d => d.Candidate).WithMany(p => p.CandidateEducations)
				.HasForeignKey(d => d.CandidateId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("candidate_educations_candidate_id_fkey");

			entity.HasOne(d => d.EducationLevel).WithMany(p => p.CandidateEducations)
				.HasForeignKey(d => d.EducationLevelId)
				.HasConstraintName("candidate_educations_education_level_id_fkey");
		});

		modelBuilder.Entity<CandidateExperience>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("candidate_experiences_pkey");
			entity.ToTable("candidate_experiences");

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.CompanyName).HasMaxLength(255);
			entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
			entity.Property(e => e.Position).HasMaxLength(255);
			entity.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone");

			entity.HasOne(d => d.Candidate).WithMany(p => p.CandidateExperiences)
				.HasForeignKey(d => d.CandidateId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("candidate_experiences_candidate_id_fkey");
		});

		modelBuilder.Entity<CandidatePortfolio>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("candidate_portfolios_pkey");
			entity.ToTable("candidate_portfolios");

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
			entity.Property(e => e.ImageUrl).HasMaxLength(255);
			entity.Property(e => e.ProjectUrl).HasMaxLength(255);
			entity.Property(e => e.Title).HasMaxLength(255);
			entity.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone");

			entity.HasOne(d => d.Candidate).WithMany(p => p.CandidatePortfolios)
				.HasForeignKey(d => d.CandidateId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("candidate_portfolios_candidate_id_fkey");
		});

		modelBuilder.Entity<CandidatePreference>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("candidate_preferences_pkey");
			entity.ToTable("candidate_preferences");

			entity.HasIndex(e => e.CandidateId, "candidate_preferences_candidate_id_key").IsUnique();

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
				.HasConstraintName("candidate_preferences_candidate_id_fkey");
		});

		modelBuilder.Entity<CandidateResume>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("candidate_resumes_pkey");
			entity.ToTable("candidate_resumes");

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
			entity.Property(e => e.FileName).HasMaxLength(255);
			entity.Property(e => e.FilePath).HasMaxLength(255);
			entity.Property(e => e.FileType).HasMaxLength(50);
			entity.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone");

			entity.HasOne(d => d.Candidate).WithMany(p => p.CandidateResumes)
				.HasForeignKey(d => d.CandidateId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("candidate_resumes_candidate_id_fkey");
		});

		modelBuilder.Entity<CandidateSkill>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("candidate_skills_pkey");
			entity.ToTable("candidate_skills");

			entity.HasIndex(e => new { e.CandidateId, e.SkillId }, "candidate_skills_candidate_id_skill_id_key").IsUnique();

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");

			entity.HasOne(d => d.Candidate).WithMany(p => p.CandidateSkills)
				.HasForeignKey(d => d.CandidateId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("candidate_skills_candidate_id_fkey");

			entity.HasOne(d => d.Skill).WithMany(p => p.CandidateSkills)
				.HasForeignKey(d => d.SkillId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("candidate_skills_skill_id_fkey");
		});

		modelBuilder.Entity<CompanyPhoto>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("company_photos_pkey");
			entity.ToTable("company_photos");

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.Caption).HasMaxLength(255);
			entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
			entity.Property(e => e.PhotoUrl).HasMaxLength(255);

			entity.HasOne(d => d.Employer).WithMany(p => p.CompanyPhotos)
				.HasForeignKey(d => d.EmployerId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("company_photos_employer_id_fkey");
		});

		modelBuilder.Entity<CompanySize>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("company_sizes_pkey");
			entity.ToTable("company_sizes");

			entity.HasIndex(e => e.SizeRange, "company_sizes_size_range_key").IsUnique();

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.SizeRange).HasMaxLength(50);
		});

		modelBuilder.Entity<EducationLevel>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("education_levels_pkey");
			entity.ToTable("education_levels");

			entity.HasIndex(e => e.LevelName, "education_levels_level_name_key").IsUnique();

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.LevelName).HasMaxLength(100);
		});

		modelBuilder.Entity<EmailLog>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("email_logs_pkey");
			entity.ToTable("email_logs");

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.RecipientEmail).HasMaxLength(255);
			entity.Property(e => e.SentAt).HasColumnType("timestamp without time zone");
			entity.Property(e => e.Status).HasMaxLength(50);
			entity.Property(e => e.Subject).HasMaxLength(255);

			entity.HasOne(d => d.Template).WithMany(p => p.EmailLogs)
				.HasForeignKey(d => d.TemplateId)
				.HasConstraintName("email_logs_template_id_fkey");
		});

		modelBuilder.Entity<EmailSetting>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("email_settings_pkey");
			entity.ToTable("email_settings");

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
			entity.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone");

			entity.HasOne(d => d.User).WithMany(p => p.EmailSettings)
				.HasForeignKey(d => d.UserId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("email_settings_user_id_fkey");
		});

		modelBuilder.Entity<EmailTemplate>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("email_templates_pkey");
			entity.ToTable("email_templates");

			entity.HasIndex(e => e.TemplateName, "email_templates_template_name_key").IsUnique();

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
			entity.Property(e => e.Subject).HasMaxLength(255);
			entity.Property(e => e.TemplateName).HasMaxLength(100);
			entity.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone");
		});

		modelBuilder.Entity<Employer>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("employers_pkey");
			entity.ToTable("employers");

			entity.HasIndex(e => e.UserId, "employers_user_id_key").IsUnique();

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
				.HasConstraintName("employers_company_size_id_fkey");

			entity.HasOne(d => d.Industry).WithMany(p => p.Employers)
				.HasForeignKey(d => d.IndustryId)
				.HasConstraintName("employers_industry_id_fkey");

			entity.HasOne(d => d.User).WithOne(p => p.Employer)
				.HasForeignKey<Employer>(d => d.UserId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("employers_user_id_fkey");
		});

		modelBuilder.Entity<EmployerBenefit>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("employer_benefits_pkey");
			entity.ToTable("employer_benefits");

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.BenefitName).HasMaxLength(255);
			entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
			entity.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone");

			entity.HasOne(d => d.Employer).WithMany(p => p.EmployerBenefits)
				.HasForeignKey(d => d.EmployerId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("employer_benefits_employer_id_fkey");
		});

		modelBuilder.Entity<EmployerReview>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("employer_reviews_pkey");
			entity.ToTable("employer_reviews");

			entity.HasIndex(e => new { e.EmployerId, e.CandidateId }, "employer_reviews_employer_id_candidate_id_key").IsUnique();

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
				.HasConstraintName("employer_reviews_candidate_id_fkey");

			entity.HasOne(d => d.Employer).WithMany(p => p.EmployerReviews)
				.HasForeignKey(d => d.EmployerId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("employer_reviews_employer_id_fkey");
		});

		modelBuilder.Entity<EmployerSocialMedia>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("employer_social_media_pkey");
			entity.ToTable("employer_social_media");

			entity.HasIndex(e => new { e.EmployerId, e.PlatformName }, "employer_social_media_employer_id_platform_name_key").IsUnique();

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
			entity.Property(e => e.PlatformName).HasMaxLength(50);
			entity.Property(e => e.ProfileUrl).HasMaxLength(255);
			entity.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone");

			entity.HasOne(d => d.Employer).WithMany(p => p.EmployerSocialMedia)
				.HasForeignKey(d => d.EmployerId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("employer_social_media_employer_id_fkey");
		});

		modelBuilder.Entity<ExperienceLevel>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("experience_levels_pkey");
			entity.ToTable("experience_levels");

			entity.HasIndex(e => e.LevelName, "experience_levels_level_name_key").IsUnique();

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.LevelName).HasMaxLength(50);
		});

		modelBuilder.Entity<Industry>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("industries_pkey");
			entity.ToTable("industries");

			entity.HasIndex(e => e.IndustryName, "industries_industry_name_key").IsUnique();

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.IndustryName).HasMaxLength(255);
		});

		modelBuilder.Entity<Job>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("jobs_pkey");
			entity.ToTable("jobs");

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.ApplicationsCount).HasDefaultValue(0);
			entity.Property(e => e.Currency).HasMaxLength(10);
			
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
				.HasConstraintName("jobs_employer_id_fkey");

			entity.HasOne(d => d.ExperienceLevel).WithMany(p => p.Jobs)
				.HasForeignKey(d => d.ExperienceLevelId)
				.HasConstraintName("jobs_experience_level_id_fkey");

			entity.HasOne(d => d.JobCategory).WithMany(p => p.Jobs)
				.HasForeignKey(d => d.JobCategoryId)
				.HasConstraintName("jobs_job_category_id_fkey");

			entity.HasOne(d => d.JobType).WithMany(p => p.Jobs)
				.HasForeignKey(d => d.JobTypeId)
				.HasConstraintName("jobs_job_type_id_fkey");

			entity.HasOne(d => d.MinEducation).WithMany(p => p.Jobs)
				.HasForeignKey(d => d.MinEducationId)
				.HasConstraintName("jobs_min_education_id_fkey");
		});

		modelBuilder.Entity<JobAlert>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("job_alerts_pkey");
			entity.ToTable("job_alerts");

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.AlertName).HasMaxLength(255);
			entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");

			entity.HasOne(d => d.Candidate).WithMany(p => p.JobAlerts)
				.HasForeignKey(d => d.CandidateId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("job_alerts_candidate_id_fkey");
		});

		modelBuilder.Entity<JobApplication>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("job_applications_pkey");
			entity.ToTable("job_applications");

			entity.HasIndex(e => new { e.JobId, e.CandidateId }, "job_applications_job_id_candidate_id_key").IsUnique();

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.AppliedAt).HasColumnType("timestamp without time zone");
			entity.Property(e => e.Status)
				.HasMaxLength(50)
				.HasDefaultValueSql("'Pending'::character varying");
			entity.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone");

			entity.HasOne(d => d.Candidate).WithMany(p => p.JobApplications)
				.HasForeignKey(d => d.CandidateId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("job_applications_candidate_id_fkey");

			entity.HasOne(d => d.Job).WithMany(p => p.JobApplications)
				.HasForeignKey(d => d.JobId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("job_applications_job_id_fkey");

			entity.HasOne(d => d.Resume).WithMany(p => p.JobApplications)
				.HasForeignKey(d => d.ResumeId)
				.HasConstraintName("job_applications_resume_id_fkey");
		});

		modelBuilder.Entity<JobCategory>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("job_categories_pkey");
			entity.ToTable("job_categories");

			entity.HasIndex(e => e.CategoryName, "job_categories_category_name_key").IsUnique();

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.CategoryName).HasMaxLength(255);
			entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");

			entity.HasOne(d => d.ParentCategory).WithMany(p => p.InverseParentCategory)
				.HasForeignKey(d => d.ParentCategoryId)
				.HasConstraintName("job_categories_parent_category_id_fkey");
		});

		modelBuilder.Entity<JobSearchLog>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("job_search_logs_pkey");
			entity.ToTable("job_search_logs");

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.Location).HasMaxLength(255);
			entity.Property(e => e.MaxSalary).HasPrecision(12, 2);
			entity.Property(e => e.MinSalary).HasPrecision(12, 2);
			entity.Property(e => e.SearchDate).HasColumnType("timestamp without time zone");

			entity.HasOne(d => d.JobCategory).WithMany(p => p.JobSearchLogs)
				.HasForeignKey(d => d.JobCategoryId)
				.HasConstraintName("job_search_logs_job_category_id_fkey");

			entity.HasOne(d => d.JobType).WithMany(p => p.JobSearchLogs)
				.HasForeignKey(d => d.JobTypeId)
				.HasConstraintName("job_search_logs_job_type_id_fkey");

			entity.HasOne(d => d.User).WithMany(p => p.JobSearchLogs)
				.HasForeignKey(d => d.UserId)
				.HasConstraintName("job_search_logs_user_id_fkey");
		});

		modelBuilder.Entity<JobSkill>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("job_skills_pkey");
			entity.ToTable("job_skills");

			entity.HasIndex(e => new { e.JobId, e.SkillId }, "job_skills_job_id_skill_id_key").IsUnique();

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");

			entity.HasOne(d => d.Job).WithMany(p => p.JobSkills)
				.HasForeignKey(d => d.JobId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("job_skills_job_id_fkey");

			entity.HasOne(d => d.Skill).WithMany(p => p.JobSkills)
				.HasForeignKey(d => d.SkillId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("job_skills_skill_id_fkey");
		});

		modelBuilder.Entity<JobType>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("job_types_pkey");
			entity.ToTable("job_types");

			entity.HasIndex(e => e.TypeName, "job_types_type_name_key").IsUnique();

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.TypeName).HasMaxLength(50);
		});

		modelBuilder.Entity<Notification>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("notifications_pkey");
			entity.ToTable("notifications");

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
			entity.Property(e => e.RelatedEntityType).HasMaxLength(50);
			entity.Property(e => e.Title).HasMaxLength(255);

			entity.HasOne(d => d.NotificationType).WithMany(p => p.Notifications)
				.HasForeignKey(d => d.NotificationTypeId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("notifications_notification_type_id_fkey");

			entity.HasOne(d => d.User).WithMany(p => p.Notifications)
				.HasForeignKey(d => d.UserId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("notifications_user_id_fkey");
		});

		modelBuilder.Entity<NotificationType>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("notification_types_pkey");
			entity.ToTable("notification_types");

			entity.HasIndex(e => e.TypeName, "notification_types_type_name_key").IsUnique();

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
			entity.Property(e => e.TypeName).HasMaxLength(100);
		});

		modelBuilder.Entity<Payment>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("payments_pkey");
			entity.ToTable("payments");

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.Amount).HasPrecision(10, 2);
			entity.Property(e => e.Currency).HasMaxLength(10);
			entity.Property(e => e.PaymentDate).HasColumnType("timestamp without time zone");
			entity.Property(e => e.PaymentMethod).HasMaxLength(50);
			entity.Property(e => e.Status).HasMaxLength(50);
			entity.Property(e => e.TransactionId).HasMaxLength(255);

			entity.HasOne(d => d.Subscription).WithMany(p => p.Payments)
				.HasForeignKey(d => d.SubscriptionId)
				.HasConstraintName("payments_subscription_id_fkey");

			entity.HasOne(d => d.User).WithMany(p => p.Payments)
				.HasForeignKey(d => d.UserId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("payments_user_id_fkey");
		});

		modelBuilder.Entity<ReportedContent>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("reported_content_pkey");
			entity.ToTable("reported_content");

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
				.HasConstraintName("reported_content_reporter_user_id_fkey");
		});

		modelBuilder.Entity<Role>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("roles_pkey");
			entity.ToTable("roles");

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.Name).HasMaxLength(256);
			entity.Property(e => e.NormalizedName).HasMaxLength(256);
		});

		modelBuilder.Entity<RoleClaim>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("role_claims_pkey");
			entity.ToTable("role_claims");

			entity.HasOne(d => d.Role).WithMany(p => p.RoleClaims)
				.HasForeignKey(d => d.RoleId)
				.HasConstraintName("role_claims_role_id_fkey");
		});

		modelBuilder.Entity<SavedCandidate>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("saved_candidates_pkey");
			entity.ToTable("saved_candidates");

			entity.HasIndex(e => new { e.EmployerId, e.CandidateId }, "saved_candidates_employer_id_candidate_id_key").IsUnique();

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.SavedAt).HasColumnType("timestamp without time zone");

			entity.HasOne(d => d.Candidate).WithMany(p => p.SavedCandidates)
				.HasForeignKey(d => d.CandidateId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("saved_candidates_candidate_id_fkey");

			entity.HasOne(d => d.Employer).WithMany(p => p.SavedCandidates)
				.HasForeignKey(d => d.EmployerId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("saved_candidates_employer_id_fkey");
		});

		modelBuilder.Entity<SavedJob>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("saved_jobs_pkey");
			entity.ToTable("saved_jobs");

			entity.HasIndex(e => new { e.CandidateId, e.JobId }, "saved_jobs_candidate_id_job_id_key").IsUnique();

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.SavedAt).HasColumnType("timestamp without time zone");

			entity.HasOne(d => d.Candidate).WithMany(p => p.SavedJobs)
				.HasForeignKey(d => d.CandidateId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("saved_jobs_candidate_id_fkey");

			entity.HasOne(d => d.Job).WithMany(p => p.SavedJobs)
				.HasForeignKey(d => d.JobId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("saved_jobs_job_id_fkey");
		});

		modelBuilder.Entity<Skill>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("skills_pkey");
			entity.ToTable("skills");

			entity.HasIndex(e => e.SkillName, "skills_skill_name_key").IsUnique();

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.SkillName).HasMaxLength(100);

			entity.HasOne(d => d.Category).WithMany(p => p.Skills)
				.HasForeignKey(d => d.CategoryId)
				.HasConstraintName("skills_category_id_fkey");
		});

		modelBuilder.Entity<SkillCategory>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("skill_categories_pkey");
			entity.ToTable("skill_categories");

			entity.HasIndex(e => e.CategoryName, "skill_categories_category_name_key").IsUnique();

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.CategoryName).HasMaxLength(100);
		});

		modelBuilder.Entity<Subscription>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("subscriptions_pkey");
			entity.ToTable("subscriptions");

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
				.HasConstraintName("subscriptions_plan_id_fkey");

			entity.HasOne(d => d.User).WithMany(p => p.Subscriptions)
				.HasForeignKey(d => d.UserId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("subscriptions_user_id_fkey");
		});

		modelBuilder.Entity<SubscriptionPlan>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("subscription_plans_pkey");
			entity.ToTable("subscription_plans");

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
			entity.HasKey(e => e.Id).HasName("users_pkey");
			entity.ToTable("users");

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.Email).HasMaxLength(256);
			entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
			entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
			entity.Property(e => e.UserName).HasMaxLength(256);

			entity.HasMany(d => d.Roles).WithMany(p => p.Users)
				.UsingEntity<Dictionary<string, object>>(
					"user_roles",
					r => r.HasOne<Role>().WithMany()
						.HasForeignKey("RoleId")
						.HasConstraintName("user_roles_role_id_fkey"),
					l => l.HasOne<User>().WithMany()
						.HasForeignKey("UserId")
						.HasConstraintName("user_roles_user_id_fkey"),
					j =>
					{
						j.HasKey("UserId", "RoleId").HasName("user_roles_pkey");
						j.ToTable("user_roles");
					});
		});

		modelBuilder.Entity<UserActivityLog>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("user_activity_logs_pkey");
			entity.ToTable("user_activity_logs");

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.ActivityType).HasMaxLength(50);
			entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
			entity.Property(e => e.IpAddress).HasMaxLength(45);

			entity.HasOne(d => d.User).WithMany(p => p.UserActivityLogs)
				.HasForeignKey(d => d.UserId)
				.HasConstraintName("user_activity_logs_user_id_fkey");
		});

		modelBuilder.Entity<UserClaim>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("user_claims_pkey");
			entity.ToTable("user_claims");

			entity.HasOne(d => d.User).WithMany(p => p.UserClaims)
				.HasForeignKey(d => d.UserId)
				.HasConstraintName("user_claims_user_id_fkey");
		});

		modelBuilder.Entity<UserLogin>(entity =>
		{
			entity.HasKey(e => new { e.LoginProvider, e.ProviderKey }).HasName("user_logins_pkey");
			entity.ToTable("user_logins");

			entity.Property(e => e.LoginProvider).HasMaxLength(128);
			entity.Property(e => e.ProviderKey).HasMaxLength(128);
			entity.Property(e => e.ProviderDisplayName).HasMaxLength(256);

			entity.HasOne(d => d.User).WithMany(p => p.UserLogins)
				.HasForeignKey(d => d.UserId)
				.HasConstraintName("user_logins_user_id_fkey");
		});

		modelBuilder.Entity<UserToken>(entity =>
		{
			entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name }).HasName("user_tokens_pkey");
			entity.ToTable("user_tokens");

			entity.Property(e => e.LoginProvider).HasMaxLength(128);
			entity.Property(e => e.Name).HasMaxLength(128);

			entity.HasOne(d => d.User).WithMany(p => p.UserTokens)
				.HasForeignKey(d => d.UserId)
				.HasConstraintName("user_tokens_user_id_fkey");
		});

		modelBuilder.Entity<WebsiteReview>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("website_reviews_pkey");
			entity.ToTable("website_reviews");

			entity.Property(e => e.Id).ValueGeneratedNever();
			entity.Property(e => e.CreatedAt).HasColumnType("timestamp without time zone");
			entity.Property(e => e.Status)
				.HasMaxLength(50)
				.HasDefaultValueSql("'Pending'::character varying");
			entity.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone");

			entity.HasOne(d => d.User).WithMany(p => p.WebsiteReviews)
				.HasForeignKey(d => d.UserId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("website_reviews_user_id_fkey");
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}