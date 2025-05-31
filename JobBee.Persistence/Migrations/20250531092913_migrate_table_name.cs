using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace JobBee.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migrate_table_name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Candidates_UserId_fkey",
                table: "Candidates");

            migrationBuilder.DropForeignKey(
                name: "Employers_CompanySizeId_fkey",
                table: "Employers");

            migrationBuilder.DropForeignKey(
                name: "Employers_IndustryId_fkey",
                table: "Employers");

            migrationBuilder.DropForeignKey(
                name: "Employers_UserId_fkey",
                table: "Employers");

            migrationBuilder.DropForeignKey(
                name: "Jobs_EmployerId_fkey",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "Jobs_ExperienceLevelId_fkey",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "Jobs_JobCategoryId_fkey",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "Jobs_JobTypeId_fkey",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "Jobs_MinEducationId_fkey",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "Notifications_NotificationTypeId_fkey",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "Notifications_UserId_fkey",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "Payments_SubscriptionId_fkey",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "Payments_UserId_fkey",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "Skills_CategoryId_fkey",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "Subscriptions_PlanId_fkey",
                table: "Subscriptions");

            migrationBuilder.DropForeignKey(
                name: "Subscriptions_UserId_fkey",
                table: "Subscriptions");

            migrationBuilder.DropTable(
                name: "AdminSettings");

            migrationBuilder.DropTable(
                name: "CandidateEducation");

            migrationBuilder.DropTable(
                name: "CandidateExperience");

            migrationBuilder.DropTable(
                name: "CandidatePortfolio");

            migrationBuilder.DropTable(
                name: "CandidatePreferences");

            migrationBuilder.DropTable(
                name: "CandidateSkills");

            migrationBuilder.DropTable(
                name: "CompanyPhotos");

            migrationBuilder.DropTable(
                name: "CompanySizes");

            migrationBuilder.DropTable(
                name: "EmailLogs");

            migrationBuilder.DropTable(
                name: "EmailSettings");

            migrationBuilder.DropTable(
                name: "EmployerBenefits");

            migrationBuilder.DropTable(
                name: "EmployerReviews");

            migrationBuilder.DropTable(
                name: "EmployerSocialMedia");

            migrationBuilder.DropTable(
                name: "ExperienceLevels");

            migrationBuilder.DropTable(
                name: "JobAlerts");

            migrationBuilder.DropTable(
                name: "JobApplications");

            migrationBuilder.DropTable(
                name: "JobSearchLogs");

            migrationBuilder.DropTable(
                name: "JobSkills");

            migrationBuilder.DropTable(
                name: "NotificationTypes");

            migrationBuilder.DropTable(
                name: "ReportedContent");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "SavedCandidates");

            migrationBuilder.DropTable(
                name: "SavedJobs");

            migrationBuilder.DropTable(
                name: "SkillCategories");

            migrationBuilder.DropTable(
                name: "SubscriptionPlans");

            migrationBuilder.DropTable(
                name: "UserActivityLogs");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "WebsiteReviews");

            migrationBuilder.DropTable(
                name: "EducationLevels");

            migrationBuilder.DropTable(
                name: "EmailTemplates");

            migrationBuilder.DropTable(
                name: "CandidateResumes");

            migrationBuilder.DropTable(
                name: "JobCategories");

            migrationBuilder.DropTable(
                name: "JobTypes");

            migrationBuilder.DropPrimaryKey(
                name: "Users_pkey",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "Subscriptions_pkey",
                table: "Subscriptions");

            migrationBuilder.DropPrimaryKey(
                name: "Skills_pkey",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "Roles_pkey",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "Payments_pkey",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "Notifications_pkey",
                table: "Notifications");

            migrationBuilder.DropPrimaryKey(
                name: "Jobs_pkey",
                table: "Jobs");

            migrationBuilder.DropPrimaryKey(
                name: "Industries_pkey",
                table: "Industries");

            migrationBuilder.DropPrimaryKey(
                name: "Employers_pkey",
                table: "Employers");

            migrationBuilder.DropPrimaryKey(
                name: "Candidates_pkey",
                table: "Candidates");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Subscriptions",
                newName: "subscriptions");

            migrationBuilder.RenameTable(
                name: "Skills",
                newName: "skills");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "roles");

            migrationBuilder.RenameTable(
                name: "Payments",
                newName: "payments");

            migrationBuilder.RenameTable(
                name: "Notifications",
                newName: "notifications");

            migrationBuilder.RenameTable(
                name: "Jobs",
                newName: "jobs");

            migrationBuilder.RenameTable(
                name: "Industries",
                newName: "industries");

            migrationBuilder.RenameTable(
                name: "Employers",
                newName: "employers");

            migrationBuilder.RenameTable(
                name: "Candidates",
                newName: "candidates");

            migrationBuilder.RenameIndex(
                name: "IX_Subscriptions_UserId",
                table: "subscriptions",
                newName: "IX_subscriptions_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Subscriptions_PlanId",
                table: "subscriptions",
                newName: "IX_subscriptions_PlanId");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_CategoryId",
                table: "skills",
                newName: "IX_skills_CategoryId");

            migrationBuilder.RenameIndex(
                name: "Skills_SkillName_key",
                table: "skills",
                newName: "skills_skill_name_key");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_UserId",
                table: "payments",
                newName: "IX_payments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_SubscriptionId",
                table: "payments",
                newName: "IX_payments_SubscriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_UserId",
                table: "notifications",
                newName: "IX_notifications_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_NotificationTypeId",
                table: "notifications",
                newName: "IX_notifications_NotificationTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_MinEducationId",
                table: "jobs",
                newName: "IX_jobs_MinEducationId");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_JobTypeId",
                table: "jobs",
                newName: "IX_jobs_JobTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_JobCategoryId",
                table: "jobs",
                newName: "IX_jobs_JobCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_ExperienceLevelId",
                table: "jobs",
                newName: "IX_jobs_ExperienceLevelId");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_EmployerId",
                table: "jobs",
                newName: "IX_jobs_EmployerId");

            migrationBuilder.RenameIndex(
                name: "Industries_IndustryName_key",
                table: "industries",
                newName: "industries_industry_name_key");

            migrationBuilder.RenameIndex(
                name: "IX_Employers_IndustryId",
                table: "employers",
                newName: "IX_employers_IndustryId");

            migrationBuilder.RenameIndex(
                name: "IX_Employers_CompanySizeId",
                table: "employers",
                newName: "IX_employers_CompanySizeId");

            migrationBuilder.RenameIndex(
                name: "Employers_UserId_key",
                table: "employers",
                newName: "employers_user_id_key");

            migrationBuilder.RenameIndex(
                name: "Candidates_UserId_key",
                table: "candidates",
                newName: "candidates_user_id_key");

            migrationBuilder.AddPrimaryKey(
                name: "users_pkey",
                table: "users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "subscriptions_pkey",
                table: "subscriptions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "skills_pkey",
                table: "skills",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "roles_pkey",
                table: "roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "payments_pkey",
                table: "payments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "notifications_pkey",
                table: "notifications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "jobs_pkey",
                table: "jobs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "industries_pkey",
                table: "industries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "employers_pkey",
                table: "employers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "candidates_pkey",
                table: "candidates",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "admin_settings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SettingName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    SettingValue = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("admin_settings_pkey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "candidate_experiences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CandidateId = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Position = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    IsCurrent = table.Column<bool>(type: "boolean", nullable: true),
                    Responsibilities = table.Column<string>(type: "text", nullable: true),
                    Achievements = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("candidate_experiences_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "candidate_experiences_candidate_id_fkey",
                        column: x => x.CandidateId,
                        principalTable: "candidates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "candidate_portfolios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CandidateId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ProjectUrl = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    ImageUrl = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("candidate_portfolios_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "candidate_portfolios_candidate_id_fkey",
                        column: x => x.CandidateId,
                        principalTable: "candidates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "candidate_preferences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CandidateId = table.Column<Guid>(type: "uuid", nullable: false),
                    JobType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    RemotePreference = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    MinSalary = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: true),
                    PreferredLocation = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    RelocationWillingness = table.Column<bool>(type: "boolean", nullable: true),
                    TravelWillingness = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("candidate_preferences_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "candidate_preferences_candidate_id_fkey",
                        column: x => x.CandidateId,
                        principalTable: "candidates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "candidate_resumes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CandidateId = table.Column<Guid>(type: "uuid", nullable: false),
                    FileName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    FilePath = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    FileSize = table.Column<int>(type: "integer", nullable: false),
                    FileType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("candidate_resumes_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "candidate_resumes_candidate_id_fkey",
                        column: x => x.CandidateId,
                        principalTable: "candidates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "candidate_skills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CandidateId = table.Column<Guid>(type: "uuid", nullable: false),
                    SkillId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProficiencyLevel = table.Column<int>(type: "integer", nullable: true),
                    YearsExperience = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("candidate_skills_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "candidate_skills_candidate_id_fkey",
                        column: x => x.CandidateId,
                        principalTable: "candidates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "candidate_skills_skill_id_fkey",
                        column: x => x.SkillId,
                        principalTable: "skills",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "company_photos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployerId = table.Column<Guid>(type: "uuid", nullable: false),
                    PhotoUrl = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Caption = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("company_photos_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "company_photos_employer_id_fkey",
                        column: x => x.EmployerId,
                        principalTable: "employers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "company_sizes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SizeRange = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("company_sizes_pkey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "education_levels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LevelName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("education_levels_pkey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "email_settings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    JobAlerts = table.Column<bool>(type: "boolean", nullable: true),
                    ApplicationUpdates = table.Column<bool>(type: "boolean", nullable: true),
                    ProfileViews = table.Column<bool>(type: "boolean", nullable: true),
                    JobRecommendations = table.Column<bool>(type: "boolean", nullable: true),
                    MarketingEmails = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("email_settings_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "email_settings_user_id_fkey",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "email_templates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TemplateName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Subject = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Body = table.Column<string>(type: "text", nullable: false),
                    Variables = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("email_templates_pkey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "employer_benefits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployerId = table.Column<Guid>(type: "uuid", nullable: false),
                    BenefitName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    BenefitDescription = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("employer_benefits_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "employer_benefits_employer_id_fkey",
                        column: x => x.EmployerId,
                        principalTable: "employers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "employer_reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployerId = table.Column<Guid>(type: "uuid", nullable: false),
                    CandidateId = table.Column<Guid>(type: "uuid", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    ReviewText = table.Column<string>(type: "text", nullable: true),
                    Pros = table.Column<string>(type: "text", nullable: true),
                    Cons = table.Column<string>(type: "text", nullable: true),
                    IsAnonymous = table.Column<bool>(type: "boolean", nullable: true),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, defaultValueSql: "'Pending'::character varying"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("employer_reviews_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "employer_reviews_candidate_id_fkey",
                        column: x => x.CandidateId,
                        principalTable: "candidates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "employer_reviews_employer_id_fkey",
                        column: x => x.EmployerId,
                        principalTable: "employers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "employer_social_media",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployerId = table.Column<Guid>(type: "uuid", nullable: false),
                    PlatformName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ProfileUrl = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("employer_social_media_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "employer_social_media_employer_id_fkey",
                        column: x => x.EmployerId,
                        principalTable: "employers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "experience_levels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LevelName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("experience_levels_pkey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "job_categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ParentCategoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("job_categories_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "job_categories_parent_category_id_fkey",
                        column: x => x.ParentCategoryId,
                        principalTable: "job_categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "job_skills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    JobId = table.Column<Guid>(type: "uuid", nullable: false),
                    SkillId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsRequired = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("job_skills_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "job_skills_job_id_fkey",
                        column: x => x.JobId,
                        principalTable: "jobs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "job_skills_skill_id_fkey",
                        column: x => x.SkillId,
                        principalTable: "skills",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "job_types",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("job_types_pkey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "notification_types",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Template = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("notification_types_pkey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "reported_content",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ReporterUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContentType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ContentId = table.Column<int>(type: "integer", nullable: false),
                    Reason = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Details = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, defaultValueSql: "'Pending'::character varying"),
                    AdminNotes = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("reported_content_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "reported_content_reporter_user_id_fkey",
                        column: x => x.ReporterUserId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "role_claims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("role_claims_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "role_claims_role_id_fkey",
                        column: x => x.RoleId,
                        principalTable: "roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "saved_candidates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployerId = table.Column<Guid>(type: "uuid", nullable: false),
                    CandidateId = table.Column<Guid>(type: "uuid", nullable: false),
                    SavedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("saved_candidates_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "saved_candidates_candidate_id_fkey",
                        column: x => x.CandidateId,
                        principalTable: "candidates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "saved_candidates_employer_id_fkey",
                        column: x => x.EmployerId,
                        principalTable: "employers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "saved_jobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CandidateId = table.Column<Guid>(type: "uuid", nullable: false),
                    JobId = table.Column<Guid>(type: "uuid", nullable: false),
                    SavedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("saved_jobs_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "saved_jobs_candidate_id_fkey",
                        column: x => x.CandidateId,
                        principalTable: "candidates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "saved_jobs_job_id_fkey",
                        column: x => x.JobId,
                        principalTable: "jobs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "skill_categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("skill_categories_pkey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "subscription_plans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PlanName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PlanType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    Currency = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    BillingCycle = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    JobPostingLimit = table.Column<int>(type: "integer", nullable: true),
                    FeaturedJobLimit = table.Column<int>(type: "integer", nullable: true),
                    CandidateSearchLimit = table.Column<int>(type: "integer", nullable: true),
                    ResumeAccessLimit = table.Column<int>(type: "integer", nullable: true),
                    ProfileVisibility = table.Column<bool>(type: "boolean", nullable: true),
                    PriorityListing = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("subscription_plans_pkey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user_activity_logs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    ActivityType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IpAddress = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    UserAgent = table.Column<string>(type: "text", nullable: true),
                    Details = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_activity_logs_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "user_activity_logs_user_id_fkey",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "user_claims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_claims_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "user_claims_user_id_fkey",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_logins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_logins_pkey", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "user_logins_user_id_fkey",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_roles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_roles_pkey", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "user_roles_role_id_fkey",
                        column: x => x.RoleId,
                        principalTable: "roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "user_roles_user_id_fkey",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_tokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_tokens_pkey", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "user_tokens_user_id_fkey",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "website_reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    ReviewText = table.Column<string>(type: "text", nullable: true),
                    IsFeatured = table.Column<bool>(type: "boolean", nullable: true),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, defaultValueSql: "'Pending'::character varying"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("website_reviews_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "website_reviews_user_id_fkey",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "job_applications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    JobId = table.Column<Guid>(type: "uuid", nullable: false),
                    CandidateId = table.Column<Guid>(type: "uuid", nullable: false),
                    ResumeId = table.Column<Guid>(type: "uuid", nullable: true),
                    CoverLetter = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValueSql: "'Pending'::character varying"),
                    EmployerNotes = table.Column<string>(type: "text", nullable: true),
                    AppliedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("job_applications_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "job_applications_candidate_id_fkey",
                        column: x => x.CandidateId,
                        principalTable: "candidates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "job_applications_job_id_fkey",
                        column: x => x.JobId,
                        principalTable: "jobs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "job_applications_resume_id_fkey",
                        column: x => x.ResumeId,
                        principalTable: "candidate_resumes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "candidate_educations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CandidateId = table.Column<Guid>(type: "uuid", nullable: false),
                    InstitutionName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    EducationLevelId = table.Column<Guid>(type: "uuid", nullable: true),
                    FieldOfStudy = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    IsCurrent = table.Column<bool>(type: "boolean", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("candidate_educations_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "candidate_educations_candidate_id_fkey",
                        column: x => x.CandidateId,
                        principalTable: "candidates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "candidate_educations_education_level_id_fkey",
                        column: x => x.EducationLevelId,
                        principalTable: "education_levels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "email_logs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RecipientEmail = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Subject = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    TemplateId = table.Column<Guid>(type: "uuid", nullable: true),
                    SentAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ErrorMessage = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("email_logs_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "email_logs_template_id_fkey",
                        column: x => x.TemplateId,
                        principalTable: "email_templates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "job_alerts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CandidateId = table.Column<Guid>(type: "uuid", nullable: false),
                    AlertName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    JobCategoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    JobTypeId = table.Column<Guid>(type: "uuid", nullable: true),
                    Location = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    MinSalary = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: true),
                    Keywords = table.Column<string>(type: "text", nullable: true),
                    Frequency = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("job_alerts_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "job_alerts_candidate_id_fkey",
                        column: x => x.CandidateId,
                        principalTable: "candidates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "job_alerts_job_category_id_fkey",
                        column: x => x.JobCategoryId,
                        principalTable: "job_categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "job_alerts_job_type_id_fkey",
                        column: x => x.JobTypeId,
                        principalTable: "job_types",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "job_search_logs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    SearchKeyword = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    JobCategoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    JobTypeId = table.Column<Guid>(type: "uuid", nullable: true),
                    MinSalary = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: true),
                    MaxSalary = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: true),
                    ResultsCount = table.Column<int>(type: "integer", nullable: true),
                    SearchDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("job_search_logs_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "job_search_logs_job_category_id_fkey",
                        column: x => x.JobCategoryId,
                        principalTable: "job_categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "job_search_logs_job_type_id_fkey",
                        column: x => x.JobTypeId,
                        principalTable: "job_types",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "job_search_logs_user_id_fkey",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "admin_settings_setting_name_key",
                table: "admin_settings",
                column: "SettingName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_candidate_educations_CandidateId",
                table: "candidate_educations",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_candidate_educations_EducationLevelId",
                table: "candidate_educations",
                column: "EducationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_candidate_experiences_CandidateId",
                table: "candidate_experiences",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_candidate_portfolios_CandidateId",
                table: "candidate_portfolios",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "candidate_preferences_candidate_id_key",
                table: "candidate_preferences",
                column: "CandidateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_candidate_resumes_CandidateId",
                table: "candidate_resumes",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "candidate_skills_candidate_id_skill_id_key",
                table: "candidate_skills",
                columns: new[] { "CandidateId", "SkillId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_candidate_skills_SkillId",
                table: "candidate_skills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_company_photos_EmployerId",
                table: "company_photos",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "company_sizes_size_range_key",
                table: "company_sizes",
                column: "SizeRange",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "education_levels_level_name_key",
                table: "education_levels",
                column: "LevelName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_email_logs_TemplateId",
                table: "email_logs",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_email_settings_UserId",
                table: "email_settings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "email_templates_template_name_key",
                table: "email_templates",
                column: "TemplateName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_employer_benefits_EmployerId",
                table: "employer_benefits",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "employer_reviews_employer_id_candidate_id_key",
                table: "employer_reviews",
                columns: new[] { "EmployerId", "CandidateId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_employer_reviews_CandidateId",
                table: "employer_reviews",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "employer_social_media_employer_id_platform_name_key",
                table: "employer_social_media",
                columns: new[] { "EmployerId", "PlatformName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "experience_levels_level_name_key",
                table: "experience_levels",
                column: "LevelName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_job_alerts_CandidateId",
                table: "job_alerts",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_job_alerts_JobCategoryId",
                table: "job_alerts",
                column: "JobCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_job_alerts_JobTypeId",
                table: "job_alerts",
                column: "JobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_job_applications_CandidateId",
                table: "job_applications",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_job_applications_ResumeId",
                table: "job_applications",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "job_applications_job_id_candidate_id_key",
                table: "job_applications",
                columns: new[] { "JobId", "CandidateId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_job_categories_ParentCategoryId",
                table: "job_categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "job_categories_category_name_key",
                table: "job_categories",
                column: "CategoryName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_job_search_logs_JobCategoryId",
                table: "job_search_logs",
                column: "JobCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_job_search_logs_JobTypeId",
                table: "job_search_logs",
                column: "JobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_job_search_logs_UserId",
                table: "job_search_logs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_job_skills_SkillId",
                table: "job_skills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "job_skills_job_id_skill_id_key",
                table: "job_skills",
                columns: new[] { "JobId", "SkillId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "job_types_type_name_key",
                table: "job_types",
                column: "TypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "notification_types_type_name_key",
                table: "notification_types",
                column: "TypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_reported_content_ReporterUserId",
                table: "reported_content",
                column: "ReporterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_role_claims_RoleId",
                table: "role_claims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_saved_candidates_CandidateId",
                table: "saved_candidates",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "saved_candidates_employer_id_candidate_id_key",
                table: "saved_candidates",
                columns: new[] { "EmployerId", "CandidateId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_saved_jobs_JobId",
                table: "saved_jobs",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "saved_jobs_candidate_id_job_id_key",
                table: "saved_jobs",
                columns: new[] { "CandidateId", "JobId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "skill_categories_category_name_key",
                table: "skill_categories",
                column: "CategoryName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_activity_logs_UserId",
                table: "user_activity_logs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_claims_UserId",
                table: "user_claims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_logins_UserId",
                table: "user_logins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_roles_RoleId",
                table: "user_roles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_website_reviews_UserId",
                table: "website_reviews",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "candidates_user_id_fkey",
                table: "candidates",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "employers_company_size_id_fkey",
                table: "employers",
                column: "CompanySizeId",
                principalTable: "company_sizes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "employers_industry_id_fkey",
                table: "employers",
                column: "IndustryId",
                principalTable: "industries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "employers_user_id_fkey",
                table: "employers",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "jobs_employer_id_fkey",
                table: "jobs",
                column: "EmployerId",
                principalTable: "employers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "jobs_experience_level_id_fkey",
                table: "jobs",
                column: "ExperienceLevelId",
                principalTable: "experience_levels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "jobs_job_category_id_fkey",
                table: "jobs",
                column: "JobCategoryId",
                principalTable: "job_categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "jobs_job_type_id_fkey",
                table: "jobs",
                column: "JobTypeId",
                principalTable: "job_types",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "jobs_min_education_id_fkey",
                table: "jobs",
                column: "MinEducationId",
                principalTable: "education_levels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "notifications_notification_type_id_fkey",
                table: "notifications",
                column: "NotificationTypeId",
                principalTable: "notification_types",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "notifications_user_id_fkey",
                table: "notifications",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "payments_subscription_id_fkey",
                table: "payments",
                column: "SubscriptionId",
                principalTable: "subscriptions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "payments_user_id_fkey",
                table: "payments",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "skills_category_id_fkey",
                table: "skills",
                column: "CategoryId",
                principalTable: "skill_categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "subscriptions_plan_id_fkey",
                table: "subscriptions",
                column: "PlanId",
                principalTable: "subscription_plans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "subscriptions_user_id_fkey",
                table: "subscriptions",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "candidates_user_id_fkey",
                table: "candidates");

            migrationBuilder.DropForeignKey(
                name: "employers_company_size_id_fkey",
                table: "employers");

            migrationBuilder.DropForeignKey(
                name: "employers_industry_id_fkey",
                table: "employers");

            migrationBuilder.DropForeignKey(
                name: "employers_user_id_fkey",
                table: "employers");

            migrationBuilder.DropForeignKey(
                name: "jobs_employer_id_fkey",
                table: "jobs");

            migrationBuilder.DropForeignKey(
                name: "jobs_experience_level_id_fkey",
                table: "jobs");

            migrationBuilder.DropForeignKey(
                name: "jobs_job_category_id_fkey",
                table: "jobs");

            migrationBuilder.DropForeignKey(
                name: "jobs_job_type_id_fkey",
                table: "jobs");

            migrationBuilder.DropForeignKey(
                name: "jobs_min_education_id_fkey",
                table: "jobs");

            migrationBuilder.DropForeignKey(
                name: "notifications_notification_type_id_fkey",
                table: "notifications");

            migrationBuilder.DropForeignKey(
                name: "notifications_user_id_fkey",
                table: "notifications");

            migrationBuilder.DropForeignKey(
                name: "payments_subscription_id_fkey",
                table: "payments");

            migrationBuilder.DropForeignKey(
                name: "payments_user_id_fkey",
                table: "payments");

            migrationBuilder.DropForeignKey(
                name: "skills_category_id_fkey",
                table: "skills");

            migrationBuilder.DropForeignKey(
                name: "subscriptions_plan_id_fkey",
                table: "subscriptions");

            migrationBuilder.DropForeignKey(
                name: "subscriptions_user_id_fkey",
                table: "subscriptions");

            migrationBuilder.DropTable(
                name: "admin_settings");

            migrationBuilder.DropTable(
                name: "candidate_educations");

            migrationBuilder.DropTable(
                name: "candidate_experiences");

            migrationBuilder.DropTable(
                name: "candidate_portfolios");

            migrationBuilder.DropTable(
                name: "candidate_preferences");

            migrationBuilder.DropTable(
                name: "candidate_skills");

            migrationBuilder.DropTable(
                name: "company_photos");

            migrationBuilder.DropTable(
                name: "company_sizes");

            migrationBuilder.DropTable(
                name: "email_logs");

            migrationBuilder.DropTable(
                name: "email_settings");

            migrationBuilder.DropTable(
                name: "employer_benefits");

            migrationBuilder.DropTable(
                name: "employer_reviews");

            migrationBuilder.DropTable(
                name: "employer_social_media");

            migrationBuilder.DropTable(
                name: "experience_levels");

            migrationBuilder.DropTable(
                name: "job_alerts");

            migrationBuilder.DropTable(
                name: "job_applications");

            migrationBuilder.DropTable(
                name: "job_search_logs");

            migrationBuilder.DropTable(
                name: "job_skills");

            migrationBuilder.DropTable(
                name: "notification_types");

            migrationBuilder.DropTable(
                name: "reported_content");

            migrationBuilder.DropTable(
                name: "role_claims");

            migrationBuilder.DropTable(
                name: "saved_candidates");

            migrationBuilder.DropTable(
                name: "saved_jobs");

            migrationBuilder.DropTable(
                name: "skill_categories");

            migrationBuilder.DropTable(
                name: "subscription_plans");

            migrationBuilder.DropTable(
                name: "user_activity_logs");

            migrationBuilder.DropTable(
                name: "user_claims");

            migrationBuilder.DropTable(
                name: "user_logins");

            migrationBuilder.DropTable(
                name: "user_roles");

            migrationBuilder.DropTable(
                name: "user_tokens");

            migrationBuilder.DropTable(
                name: "website_reviews");

            migrationBuilder.DropTable(
                name: "education_levels");

            migrationBuilder.DropTable(
                name: "email_templates");

            migrationBuilder.DropTable(
                name: "candidate_resumes");

            migrationBuilder.DropTable(
                name: "job_categories");

            migrationBuilder.DropTable(
                name: "job_types");

            migrationBuilder.DropPrimaryKey(
                name: "users_pkey",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "subscriptions_pkey",
                table: "subscriptions");

            migrationBuilder.DropPrimaryKey(
                name: "skills_pkey",
                table: "skills");

            migrationBuilder.DropPrimaryKey(
                name: "roles_pkey",
                table: "roles");

            migrationBuilder.DropPrimaryKey(
                name: "payments_pkey",
                table: "payments");

            migrationBuilder.DropPrimaryKey(
                name: "notifications_pkey",
                table: "notifications");

            migrationBuilder.DropPrimaryKey(
                name: "jobs_pkey",
                table: "jobs");

            migrationBuilder.DropPrimaryKey(
                name: "industries_pkey",
                table: "industries");

            migrationBuilder.DropPrimaryKey(
                name: "employers_pkey",
                table: "employers");

            migrationBuilder.DropPrimaryKey(
                name: "candidates_pkey",
                table: "candidates");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "subscriptions",
                newName: "Subscriptions");

            migrationBuilder.RenameTable(
                name: "skills",
                newName: "Skills");

            migrationBuilder.RenameTable(
                name: "roles",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "payments",
                newName: "Payments");

            migrationBuilder.RenameTable(
                name: "notifications",
                newName: "Notifications");

            migrationBuilder.RenameTable(
                name: "jobs",
                newName: "Jobs");

            migrationBuilder.RenameTable(
                name: "industries",
                newName: "Industries");

            migrationBuilder.RenameTable(
                name: "employers",
                newName: "Employers");

            migrationBuilder.RenameTable(
                name: "candidates",
                newName: "Candidates");

            migrationBuilder.RenameIndex(
                name: "IX_subscriptions_UserId",
                table: "Subscriptions",
                newName: "IX_Subscriptions_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_subscriptions_PlanId",
                table: "Subscriptions",
                newName: "IX_Subscriptions_PlanId");

            migrationBuilder.RenameIndex(
                name: "IX_skills_CategoryId",
                table: "Skills",
                newName: "IX_Skills_CategoryId");

            migrationBuilder.RenameIndex(
                name: "skills_skill_name_key",
                table: "Skills",
                newName: "Skills_SkillName_key");

            migrationBuilder.RenameIndex(
                name: "IX_payments_UserId",
                table: "Payments",
                newName: "IX_Payments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_payments_SubscriptionId",
                table: "Payments",
                newName: "IX_Payments_SubscriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_notifications_UserId",
                table: "Notifications",
                newName: "IX_Notifications_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_notifications_NotificationTypeId",
                table: "Notifications",
                newName: "IX_Notifications_NotificationTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_jobs_MinEducationId",
                table: "Jobs",
                newName: "IX_Jobs_MinEducationId");

            migrationBuilder.RenameIndex(
                name: "IX_jobs_JobTypeId",
                table: "Jobs",
                newName: "IX_Jobs_JobTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_jobs_JobCategoryId",
                table: "Jobs",
                newName: "IX_Jobs_JobCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_jobs_ExperienceLevelId",
                table: "Jobs",
                newName: "IX_Jobs_ExperienceLevelId");

            migrationBuilder.RenameIndex(
                name: "IX_jobs_EmployerId",
                table: "Jobs",
                newName: "IX_Jobs_EmployerId");

            migrationBuilder.RenameIndex(
                name: "industries_industry_name_key",
                table: "Industries",
                newName: "Industries_IndustryName_key");

            migrationBuilder.RenameIndex(
                name: "IX_employers_IndustryId",
                table: "Employers",
                newName: "IX_Employers_IndustryId");

            migrationBuilder.RenameIndex(
                name: "IX_employers_CompanySizeId",
                table: "Employers",
                newName: "IX_Employers_CompanySizeId");

            migrationBuilder.RenameIndex(
                name: "employers_user_id_key",
                table: "Employers",
                newName: "Employers_UserId_key");

            migrationBuilder.RenameIndex(
                name: "candidates_user_id_key",
                table: "Candidates",
                newName: "Candidates_UserId_key");

            migrationBuilder.AddPrimaryKey(
                name: "Users_pkey",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "Subscriptions_pkey",
                table: "Subscriptions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "Skills_pkey",
                table: "Skills",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "Roles_pkey",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "Payments_pkey",
                table: "Payments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "Notifications_pkey",
                table: "Notifications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "Jobs_pkey",
                table: "Jobs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "Industries_pkey",
                table: "Industries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "Employers_pkey",
                table: "Employers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "Candidates_pkey",
                table: "Candidates",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AdminSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    SettingName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    SettingValue = table.Column<string>(type: "text", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("AdminSettings_pkey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CandidateExperience",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CandidateId = table.Column<Guid>(type: "uuid", nullable: false),
                    Achievements = table.Column<string>(type: "text", nullable: true),
                    CompanyName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    IsCurrent = table.Column<bool>(type: "boolean", nullable: true),
                    Position = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Responsibilities = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CandidateExperience_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "CandidateExperience_CandidateId_fkey",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CandidatePortfolio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CandidateId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    ProjectUrl = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CandidatePortfolio_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "CandidatePortfolio_CandidateId_fkey",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CandidatePreferences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CandidateId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    JobType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    MinSalary = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: true),
                    PreferredLocation = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    RelocationWillingness = table.Column<bool>(type: "boolean", nullable: true),
                    RemotePreference = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    TravelWillingness = table.Column<int>(type: "integer", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CandidatePreferences_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "CandidatePreferences_CandidateId_fkey",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CandidateResumes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CandidateId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    FileName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    FilePath = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    FileSize = table.Column<int>(type: "integer", nullable: false),
                    FileType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CandidateResumes_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "CandidateResumes_CandidateId_fkey",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CandidateSkills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CandidateId = table.Column<Guid>(type: "uuid", nullable: false),
                    SkillId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ProficiencyLevel = table.Column<int>(type: "integer", nullable: true),
                    YearsExperience = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CandidateSkills_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "CandidateSkills_CandidateId_fkey",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "CandidateSkills_SkillId_fkey",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompanyPhotos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Caption = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PhotoUrl = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CompanyPhotos_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "CompanyPhotos_EmployerId_fkey",
                        column: x => x.EmployerId,
                        principalTable: "Employers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompanySizes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SizeRange = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CompanySizes_pkey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EducationLevels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LevelName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("EducationLevels_pkey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ApplicationUpdates = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    JobAlerts = table.Column<bool>(type: "boolean", nullable: true),
                    JobRecommendations = table.Column<bool>(type: "boolean", nullable: true),
                    MarketingEmails = table.Column<bool>(type: "boolean", nullable: true),
                    ProfileViews = table.Column<bool>(type: "boolean", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("EmailSettings_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "EmailSettings_UserId_fkey",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmailTemplates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Body = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Subject = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    TemplateName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Variables = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("EmailTemplates_pkey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployerBenefits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployerId = table.Column<Guid>(type: "uuid", nullable: false),
                    BenefitDescription = table.Column<string>(type: "text", nullable: true),
                    BenefitName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("EmployerBenefits_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "EmployerBenefits_EmployerId_fkey",
                        column: x => x.EmployerId,
                        principalTable: "Employers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployerReviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CandidateId = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Cons = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsAnonymous = table.Column<bool>(type: "boolean", nullable: true),
                    Pros = table.Column<string>(type: "text", nullable: true),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    ReviewText = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, defaultValueSql: "'Pending'::character varying"),
                    Title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("EmployerReviews_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "EmployerReviews_CandidateId_fkey",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "EmployerReviews_EmployerId_fkey",
                        column: x => x.EmployerId,
                        principalTable: "Employers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployerSocialMedia",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployerId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PlatformName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ProfileUrl = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("EmployerSocialMedia_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "EmployerSocialMedia_EmployerId_fkey",
                        column: x => x.EmployerId,
                        principalTable: "Employers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExperienceLevels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LevelName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ExperienceLevels_pkey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ParentCategoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    CategoryName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("JobCategories_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "JobCategories_ParentCategoryId_fkey",
                        column: x => x.ParentCategoryId,
                        principalTable: "JobCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JobSkills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    JobId = table.Column<Guid>(type: "uuid", nullable: false),
                    SkillId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsRequired = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("JobSkills_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "JobSkills_JobId_fkey",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "JobSkills_SkillId_fkey",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JobTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("JobTypes_pkey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotificationTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Template = table.Column<string>(type: "text", nullable: true),
                    TypeName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("NotificationTypes_pkey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportedContent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ReporterUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    AdminNotes = table.Column<string>(type: "text", nullable: true),
                    ContentId = table.Column<int>(type: "integer", nullable: false),
                    ContentType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Details = table.Column<string>(type: "text", nullable: true),
                    Reason = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, defaultValueSql: "'Pending'::character varying"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ReportedContent_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "ReportedContent_ReporterUserId_fkey",
                        column: x => x.ReporterUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("RoleClaims_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "RoleClaims_RoleId_fkey",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SavedCandidates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CandidateId = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    SavedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SavedCandidates_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "SavedCandidates_CandidateId_fkey",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "SavedCandidates_EmployerId_fkey",
                        column: x => x.EmployerId,
                        principalTable: "Employers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SavedJobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CandidateId = table.Column<Guid>(type: "uuid", nullable: false),
                    JobId = table.Column<Guid>(type: "uuid", nullable: false),
                    SavedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SavedJobs_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "SavedJobs_CandidateId_fkey",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "SavedJobs_JobId_fkey",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SkillCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SkillCategories_pkey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionPlans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BillingCycle = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CandidateSearchLimit = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Currency = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    FeaturedJobLimit = table.Column<int>(type: "integer", nullable: true),
                    JobPostingLimit = table.Column<int>(type: "integer", nullable: true),
                    PlanName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PlanType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    PriorityListing = table.Column<bool>(type: "boolean", nullable: true),
                    ProfileVisibility = table.Column<bool>(type: "boolean", nullable: true),
                    ResumeAccessLimit = table.Column<int>(type: "integer", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SubscriptionPlans_pkey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserActivityLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    ActivityType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Details = table.Column<string>(type: "text", nullable: true),
                    IpAddress = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    UserAgent = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("UserActivityLogs_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "UserActivityLogs_UserId_fkey",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("UserClaims_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "UserClaims_UserId_fkey",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("UserLogins_pkey", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "UserLogins_UserId_fkey",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("UserRoles_pkey", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "UserRoles_RoleId_fkey",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "UserRoles_UserId_fkey",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("UserTokens_pkey", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "UserTokens_UserId_fkey",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WebsiteReviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsFeatured = table.Column<bool>(type: "boolean", nullable: true),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    ReviewText = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true, defaultValueSql: "'Pending'::character varying"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("WebsiteReviews_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "WebsiteReviews_UserId_fkey",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JobApplications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CandidateId = table.Column<Guid>(type: "uuid", nullable: false),
                    JobId = table.Column<Guid>(type: "uuid", nullable: false),
                    ResumeId = table.Column<Guid>(type: "uuid", nullable: true),
                    AppliedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CoverLetter = table.Column<string>(type: "text", nullable: true),
                    EmployerNotes = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValueSql: "'Pending'::character varying"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("JobApplications_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "JobApplications_CandidateId_fkey",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "JobApplications_JobId_fkey",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "JobApplications_ResumeId_fkey",
                        column: x => x.ResumeId,
                        principalTable: "CandidateResumes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CandidateEducation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CandidateId = table.Column<Guid>(type: "uuid", nullable: false),
                    EducationLevelId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    FieldOfStudy = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    InstitutionName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IsCurrent = table.Column<bool>(type: "boolean", nullable: true),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CandidateEducation_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "CandidateEducation_CandidateId_fkey",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "CandidateEducation_EducationLevelId_fkey",
                        column: x => x.EducationLevelId,
                        principalTable: "EducationLevels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmailLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TemplateId = table.Column<Guid>(type: "uuid", nullable: true),
                    ErrorMessage = table.Column<string>(type: "text", nullable: true),
                    RecipientEmail = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    SentAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Subject = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("EmailLogs_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "EmailLogs_TemplateId_fkey",
                        column: x => x.TemplateId,
                        principalTable: "EmailTemplates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JobAlerts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CandidateId = table.Column<Guid>(type: "uuid", nullable: false),
                    JobCategoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    JobTypeId = table.Column<Guid>(type: "uuid", nullable: true),
                    AlertName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Frequency = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true),
                    Keywords = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    MinSalary = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("JobAlerts_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "JobAlerts_CandidateId_fkey",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "JobAlerts_JobCategoryId_fkey",
                        column: x => x.JobCategoryId,
                        principalTable: "JobCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "JobAlerts_JobTypeId_fkey",
                        column: x => x.JobTypeId,
                        principalTable: "JobTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JobSearchLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    JobCategoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    JobTypeId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    Location = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    MaxSalary = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: true),
                    MinSalary = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: true),
                    ResultsCount = table.Column<int>(type: "integer", nullable: true),
                    SearchDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    SearchKeyword = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("JobSearchLogs_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "JobSearchLogs_JobCategoryId_fkey",
                        column: x => x.JobCategoryId,
                        principalTable: "JobCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "JobSearchLogs_JobTypeId_fkey",
                        column: x => x.JobTypeId,
                        principalTable: "JobTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "JobSearchLogs_UserId_fkey",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "AdminSettings_SettingName_key",
                table: "AdminSettings",
                column: "SettingName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CandidateEducation_CandidateId",
                table: "CandidateEducation",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateEducation_EducationLevelId",
                table: "CandidateEducation",
                column: "EducationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateExperience_CandidateId",
                table: "CandidateExperience",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePortfolio_CandidateId",
                table: "CandidatePortfolio",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "CandidatePreferences_CandidateId_key",
                table: "CandidatePreferences",
                column: "CandidateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CandidateResumes_CandidateId",
                table: "CandidateResumes",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "CandidateSkills_CandidateId_SkillId_key",
                table: "CandidateSkills",
                columns: new[] { "CandidateId", "SkillId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSkills_SkillId",
                table: "CandidateSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyPhotos_EmployerId",
                table: "CompanyPhotos",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "CompanySizes_SizeRange_key",
                table: "CompanySizes",
                column: "SizeRange",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "EducationLevels_LevelName_key",
                table: "EducationLevels",
                column: "LevelName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmailLogs_TemplateId",
                table: "EmailLogs",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailSettings_UserId",
                table: "EmailSettings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "EmailTemplates_TemplateName_key",
                table: "EmailTemplates",
                column: "TemplateName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployerBenefits_EmployerId",
                table: "EmployerBenefits",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "EmployerReviews_EmployerId_CandidateId_key",
                table: "EmployerReviews",
                columns: new[] { "EmployerId", "CandidateId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployerReviews_CandidateId",
                table: "EmployerReviews",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "EmployerSocialMedia_EmployerId_PlatformName_key",
                table: "EmployerSocialMedia",
                columns: new[] { "EmployerId", "PlatformName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ExperienceLevels_LevelName_key",
                table: "ExperienceLevels",
                column: "LevelName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobAlerts_CandidateId",
                table: "JobAlerts",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_JobAlerts_JobCategoryId",
                table: "JobAlerts",
                column: "JobCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_JobAlerts_JobTypeId",
                table: "JobAlerts",
                column: "JobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_CandidateId",
                table: "JobApplications",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_ResumeId",
                table: "JobApplications",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "JobApplications_JobId_CandidateId_key",
                table: "JobApplications",
                columns: new[] { "JobId", "CandidateId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobCategories_ParentCategoryId",
                table: "JobCategories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "JobCategories_CategoryName_key",
                table: "JobCategories",
                column: "CategoryName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobSearchLogs_JobCategoryId",
                table: "JobSearchLogs",
                column: "JobCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSearchLogs_JobTypeId",
                table: "JobSearchLogs",
                column: "JobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSearchLogs_UserId",
                table: "JobSearchLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSkills_SkillId",
                table: "JobSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "JobSkills_JobId_SkillId_key",
                table: "JobSkills",
                columns: new[] { "JobId", "SkillId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "JobTypes_TypeName_key",
                table: "JobTypes",
                column: "TypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "NotificationTypes_TypeName_key",
                table: "NotificationTypes",
                column: "TypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReportedContent_ReporterUserId",
                table: "ReportedContent",
                column: "ReporterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedCandidates_CandidateId",
                table: "SavedCandidates",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "SavedCandidates_EmployerId_CandidateId_key",
                table: "SavedCandidates",
                columns: new[] { "EmployerId", "CandidateId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SavedJobs_JobId",
                table: "SavedJobs",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "SavedJobs_CandidateId_JobId_key",
                table: "SavedJobs",
                columns: new[] { "CandidateId", "JobId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "SkillCategories_CategoryName_key",
                table: "SkillCategories",
                column: "CategoryName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserActivityLogs_UserId",
                table: "UserActivityLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_WebsiteReviews_UserId",
                table: "WebsiteReviews",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "Candidates_UserId_fkey",
                table: "Candidates",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "Employers_CompanySizeId_fkey",
                table: "Employers",
                column: "CompanySizeId",
                principalTable: "CompanySizes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "Employers_IndustryId_fkey",
                table: "Employers",
                column: "IndustryId",
                principalTable: "Industries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "Employers_UserId_fkey",
                table: "Employers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "Jobs_EmployerId_fkey",
                table: "Jobs",
                column: "EmployerId",
                principalTable: "Employers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "Jobs_ExperienceLevelId_fkey",
                table: "Jobs",
                column: "ExperienceLevelId",
                principalTable: "ExperienceLevels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "Jobs_JobCategoryId_fkey",
                table: "Jobs",
                column: "JobCategoryId",
                principalTable: "JobCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "Jobs_JobTypeId_fkey",
                table: "Jobs",
                column: "JobTypeId",
                principalTable: "JobTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "Jobs_MinEducationId_fkey",
                table: "Jobs",
                column: "MinEducationId",
                principalTable: "EducationLevels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "Notifications_NotificationTypeId_fkey",
                table: "Notifications",
                column: "NotificationTypeId",
                principalTable: "NotificationTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "Notifications_UserId_fkey",
                table: "Notifications",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "Payments_SubscriptionId_fkey",
                table: "Payments",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "Payments_UserId_fkey",
                table: "Payments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "Skills_CategoryId_fkey",
                table: "Skills",
                column: "CategoryId",
                principalTable: "SkillCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "Subscriptions_PlanId_fkey",
                table: "Subscriptions",
                column: "PlanId",
                principalTable: "SubscriptionPlans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "Subscriptions_UserId_fkey",
                table: "Subscriptions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
