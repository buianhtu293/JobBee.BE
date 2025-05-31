using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobBee.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migrate_column_name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "website_reviews",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "website_reviews",
                newName: "rating");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "website_reviews",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "website_reviews",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "website_reviews",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ReviewText",
                table: "website_reviews",
                newName: "review_text");

            migrationBuilder.RenameColumn(
                name: "IsFeatured",
                table: "website_reviews",
                newName: "is_featured");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "website_reviews",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_website_reviews_UserId",
                table: "website_reviews",
                newName: "IX_website_reviews_user_id");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "users",
                newName: "user_name");

            migrationBuilder.RenameColumn(
                name: "TwoFactorEnabled",
                table: "users",
                newName: "two_factor_enabled");

            migrationBuilder.RenameColumn(
                name: "SecurityStamp",
                table: "users",
                newName: "security_stamp");

            migrationBuilder.RenameColumn(
                name: "PhoneNumberConfirmed",
                table: "users",
                newName: "phone_number_confirmed");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "users",
                newName: "phone_number");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "users",
                newName: "password_hash");

            migrationBuilder.RenameColumn(
                name: "NormalizedUserName",
                table: "users",
                newName: "normalized_user_name");

            migrationBuilder.RenameColumn(
                name: "NormalizedEmail",
                table: "users",
                newName: "normalized_email");

            migrationBuilder.RenameColumn(
                name: "LockoutEnd",
                table: "users",
                newName: "lockout_end");

            migrationBuilder.RenameColumn(
                name: "LockoutEnabled",
                table: "users",
                newName: "lockout_enabled");

            migrationBuilder.RenameColumn(
                name: "EmailConfirmed",
                table: "users",
                newName: "email_confirmed");

            migrationBuilder.RenameColumn(
                name: "ConcurrencyStamp",
                table: "users",
                newName: "concurrency_stamp");

            migrationBuilder.RenameColumn(
                name: "AccessFailedCount",
                table: "users",
                newName: "access_failed_count");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "user_tokens",
                newName: "value");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "user_tokens",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "LoginProvider",
                table: "user_tokens",
                newName: "login_provider");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "user_tokens",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "user_logins",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "ProviderDisplayName",
                table: "user_logins",
                newName: "provider_display_name");

            migrationBuilder.RenameColumn(
                name: "ProviderKey",
                table: "user_logins",
                newName: "provider_key");

            migrationBuilder.RenameColumn(
                name: "LoginProvider",
                table: "user_logins",
                newName: "login_provider");

            migrationBuilder.RenameIndex(
                name: "IX_user_logins_UserId",
                table: "user_logins",
                newName: "IX_user_logins_user_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "user_claims",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "user_claims",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "ClaimValue",
                table: "user_claims",
                newName: "claim_value");

            migrationBuilder.RenameColumn(
                name: "ClaimType",
                table: "user_claims",
                newName: "claim_type");

            migrationBuilder.RenameIndex(
                name: "IX_user_claims_UserId",
                table: "user_claims",
                newName: "IX_user_claims_user_id");

            migrationBuilder.RenameColumn(
                name: "Details",
                table: "user_activity_logs",
                newName: "details");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "user_activity_logs",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "user_activity_logs",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "UserAgent",
                table: "user_activity_logs",
                newName: "user_agent");

            migrationBuilder.RenameColumn(
                name: "IpAddress",
                table: "user_activity_logs",
                newName: "ip_address");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "user_activity_logs",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "ActivityType",
                table: "user_activity_logs",
                newName: "activity_type");

            migrationBuilder.RenameIndex(
                name: "IX_user_activity_logs_UserId",
                table: "user_activity_logs",
                newName: "IX_user_activity_logs_user_id");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "subscriptions",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "subscriptions",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "subscriptions",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "subscriptions",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "subscriptions",
                newName: "start_date");

            migrationBuilder.RenameColumn(
                name: "RenewalDate",
                table: "subscriptions",
                newName: "renewal_date");

            migrationBuilder.RenameColumn(
                name: "PlanId",
                table: "subscriptions",
                newName: "plan_id");

            migrationBuilder.RenameColumn(
                name: "PaymentMethod",
                table: "subscriptions",
                newName: "payment_method");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "subscriptions",
                newName: "end_date");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "subscriptions",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "AutoRenew",
                table: "subscriptions",
                newName: "auto_renew");

            migrationBuilder.RenameIndex(
                name: "IX_subscriptions_UserId",
                table: "subscriptions",
                newName: "IX_subscriptions_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_subscriptions_PlanId",
                table: "subscriptions",
                newName: "IX_subscriptions_plan_id");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "subscription_plans",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "subscription_plans",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Currency",
                table: "subscription_plans",
                newName: "currency");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "subscription_plans",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "subscription_plans",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ResumeAccessLimit",
                table: "subscription_plans",
                newName: "resume_access_limit");

            migrationBuilder.RenameColumn(
                name: "ProfileVisibility",
                table: "subscription_plans",
                newName: "profile_visibility");

            migrationBuilder.RenameColumn(
                name: "PriorityListing",
                table: "subscription_plans",
                newName: "priority_listing");

            migrationBuilder.RenameColumn(
                name: "PlanType",
                table: "subscription_plans",
                newName: "plan_type");

            migrationBuilder.RenameColumn(
                name: "PlanName",
                table: "subscription_plans",
                newName: "plan_name");

            migrationBuilder.RenameColumn(
                name: "JobPostingLimit",
                table: "subscription_plans",
                newName: "job_posting_limit");

            migrationBuilder.RenameColumn(
                name: "FeaturedJobLimit",
                table: "subscription_plans",
                newName: "featured_job_limit");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "subscription_plans",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "CandidateSearchLimit",
                table: "subscription_plans",
                newName: "candidate_search_limit");

            migrationBuilder.RenameColumn(
                name: "BillingCycle",
                table: "subscription_plans",
                newName: "billing_cycle");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "skills",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SkillName",
                table: "skills",
                newName: "skill_name");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "skills",
                newName: "category_id");

            migrationBuilder.RenameIndex(
                name: "IX_skills_CategoryId",
                table: "skills",
                newName: "IX_skills_category_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "skill_categories",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "skill_categories",
                newName: "category_name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "saved_jobs",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SavedAt",
                table: "saved_jobs",
                newName: "saved_at");

            migrationBuilder.RenameColumn(
                name: "JobId",
                table: "saved_jobs",
                newName: "job_id");

            migrationBuilder.RenameColumn(
                name: "CandidateId",
                table: "saved_jobs",
                newName: "candidate_id");

            migrationBuilder.RenameIndex(
                name: "IX_saved_jobs_JobId",
                table: "saved_jobs",
                newName: "IX_saved_jobs_job_id");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "saved_candidates",
                newName: "notes");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "saved_candidates",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SavedAt",
                table: "saved_candidates",
                newName: "saved_at");

            migrationBuilder.RenameColumn(
                name: "EmployerId",
                table: "saved_candidates",
                newName: "employer_id");

            migrationBuilder.RenameColumn(
                name: "CandidateId",
                table: "saved_candidates",
                newName: "candidate_id");

            migrationBuilder.RenameIndex(
                name: "IX_saved_candidates_CandidateId",
                table: "saved_candidates",
                newName: "IX_saved_candidates_candidate_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "roles",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "roles",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "NormalizedName",
                table: "roles",
                newName: "normalized_name");

            migrationBuilder.RenameColumn(
                name: "ConcurrencyStamp",
                table: "roles",
                newName: "concurrency_stamp");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "role_claims",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "role_claims",
                newName: "role_id");

            migrationBuilder.RenameColumn(
                name: "ClaimValue",
                table: "role_claims",
                newName: "claim_value");

            migrationBuilder.RenameColumn(
                name: "ClaimType",
                table: "role_claims",
                newName: "claim_type");

            migrationBuilder.RenameIndex(
                name: "IX_role_claims_RoleId",
                table: "role_claims",
                newName: "IX_role_claims_role_id");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "reported_content",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Reason",
                table: "reported_content",
                newName: "reason");

            migrationBuilder.RenameColumn(
                name: "Details",
                table: "reported_content",
                newName: "details");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "reported_content",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "reported_content",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ReporterUserId",
                table: "reported_content",
                newName: "reporter_user_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "reported_content",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "ContentType",
                table: "reported_content",
                newName: "content_type");

            migrationBuilder.RenameColumn(
                name: "ContentId",
                table: "reported_content",
                newName: "content_id");

            migrationBuilder.RenameColumn(
                name: "AdminNotes",
                table: "reported_content",
                newName: "admin_notes");

            migrationBuilder.RenameIndex(
                name: "IX_reported_content_ReporterUserId",
                table: "reported_content",
                newName: "IX_reported_content_reporter_user_id");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "payments",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "payments",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Currency",
                table: "payments",
                newName: "currency");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "payments",
                newName: "amount");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "payments",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "payments",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "TransactionId",
                table: "payments",
                newName: "transaction_id");

            migrationBuilder.RenameColumn(
                name: "SubscriptionId",
                table: "payments",
                newName: "subscription_id");

            migrationBuilder.RenameColumn(
                name: "PaymentMethod",
                table: "payments",
                newName: "payment_method");

            migrationBuilder.RenameColumn(
                name: "PaymentDate",
                table: "payments",
                newName: "payment_date");

            migrationBuilder.RenameIndex(
                name: "IX_payments_UserId",
                table: "payments",
                newName: "IX_payments_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_payments_SubscriptionId",
                table: "payments",
                newName: "IX_payments_subscription_id");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "notifications",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Message",
                table: "notifications",
                newName: "message");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "notifications",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "notifications",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "RelatedEntityType",
                table: "notifications",
                newName: "related_entity_type");

            migrationBuilder.RenameColumn(
                name: "RelatedEntityId",
                table: "notifications",
                newName: "related_entity_id");

            migrationBuilder.RenameColumn(
                name: "NotificationTypeId",
                table: "notifications",
                newName: "notification_type_id");

            migrationBuilder.RenameColumn(
                name: "IsRead",
                table: "notifications",
                newName: "is_read");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "notifications",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_notifications_UserId",
                table: "notifications",
                newName: "IX_notifications_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_notifications_NotificationTypeId",
                table: "notifications",
                newName: "IX_notifications_notification_type_id");

            migrationBuilder.RenameColumn(
                name: "Template",
                table: "notification_types",
                newName: "template");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "notification_types",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TypeName",
                table: "notification_types",
                newName: "type_name");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "notification_types",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "jobs",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ViewsCount",
                table: "jobs",
                newName: "views_count");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "jobs",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "SalaryPeriod",
                table: "jobs",
                newName: "salary_period");

            migrationBuilder.RenameColumn(
                name: "PostedAt",
                table: "jobs",
                newName: "posted_at");

            migrationBuilder.RenameColumn(
                name: "MinSalary",
                table: "jobs",
                newName: "min_salary");

            migrationBuilder.RenameColumn(
                name: "MinEducationId",
                table: "jobs",
                newName: "min_education_id");

            migrationBuilder.RenameColumn(
                name: "MaxSalary",
                table: "jobs",
                newName: "max_salary");

            migrationBuilder.RenameColumn(
                name: "LocationState",
                table: "jobs",
                newName: "location_state");

            migrationBuilder.RenameColumn(
                name: "LocationCountry",
                table: "jobs",
                newName: "location_country");

            migrationBuilder.RenameColumn(
                name: "LocationCity",
                table: "jobs",
                newName: "location_city");

            migrationBuilder.RenameColumn(
                name: "JobTypeId",
                table: "jobs",
                newName: "job_type_id");

            migrationBuilder.RenameColumn(
                name: "JobCategoryId",
                table: "jobs",
                newName: "job_category_id");

            migrationBuilder.RenameColumn(
                name: "IsSalaryNegotiable",
                table: "jobs",
                newName: "is_salary_negotiable");

            migrationBuilder.RenameColumn(
                name: "IsRemote",
                table: "jobs",
                newName: "is_remote");

            migrationBuilder.RenameColumn(
                name: "IsFeatured",
                table: "jobs",
                newName: "is_featured");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "jobs",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "ExpiresAt",
                table: "jobs",
                newName: "expires_at");

            migrationBuilder.RenameColumn(
                name: "ExperienceLevelId",
                table: "jobs",
                newName: "experience_level_id");

            migrationBuilder.RenameColumn(
                name: "EmployerId",
                table: "jobs",
                newName: "employer_id");

            migrationBuilder.RenameColumn(
                name: "ApplicationsCount",
                table: "jobs",
                newName: "applications_count");

            migrationBuilder.RenameColumn(
                name: "ApplicationDeadline",
                table: "jobs",
                newName: "application_deadline");

            migrationBuilder.RenameColumn(
                name: "AllowsWorkFromHome",
                table: "jobs",
                newName: "allows_work_from_home");

            migrationBuilder.RenameIndex(
                name: "IX_jobs_MinEducationId",
                table: "jobs",
                newName: "IX_jobs_min_education_id");

            migrationBuilder.RenameIndex(
                name: "IX_jobs_JobTypeId",
                table: "jobs",
                newName: "IX_jobs_job_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_jobs_JobCategoryId",
                table: "jobs",
                newName: "IX_jobs_job_category_id");

            migrationBuilder.RenameIndex(
                name: "IX_jobs_ExperienceLevelId",
                table: "jobs",
                newName: "IX_jobs_experience_level_id");

            migrationBuilder.RenameIndex(
                name: "IX_jobs_EmployerId",
                table: "jobs",
                newName: "IX_jobs_employer_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "job_types",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TypeName",
                table: "job_types",
                newName: "type_name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "job_skills",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SkillId",
                table: "job_skills",
                newName: "skill_id");

            migrationBuilder.RenameColumn(
                name: "JobId",
                table: "job_skills",
                newName: "job_id");

            migrationBuilder.RenameColumn(
                name: "IsRequired",
                table: "job_skills",
                newName: "is_required");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "job_skills",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_job_skills_SkillId",
                table: "job_skills",
                newName: "IX_job_skills_skill_id");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "job_search_logs",
                newName: "location");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "job_search_logs",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "job_search_logs",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "SearchKeyword",
                table: "job_search_logs",
                newName: "search_keyword");

            migrationBuilder.RenameColumn(
                name: "SearchDate",
                table: "job_search_logs",
                newName: "search_date");

            migrationBuilder.RenameColumn(
                name: "ResultsCount",
                table: "job_search_logs",
                newName: "results_count");

            migrationBuilder.RenameColumn(
                name: "MinSalary",
                table: "job_search_logs",
                newName: "min_salary");

            migrationBuilder.RenameColumn(
                name: "MaxSalary",
                table: "job_search_logs",
                newName: "max_salary");

            migrationBuilder.RenameColumn(
                name: "JobTypeId",
                table: "job_search_logs",
                newName: "job_type_id");

            migrationBuilder.RenameColumn(
                name: "JobCategoryId",
                table: "job_search_logs",
                newName: "job_category_id");

            migrationBuilder.RenameIndex(
                name: "IX_job_search_logs_UserId",
                table: "job_search_logs",
                newName: "IX_job_search_logs_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_job_search_logs_JobTypeId",
                table: "job_search_logs",
                newName: "IX_job_search_logs_job_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_job_search_logs_JobCategoryId",
                table: "job_search_logs",
                newName: "IX_job_search_logs_job_category_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "job_categories",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ParentCategoryId",
                table: "job_categories",
                newName: "parent_category_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "job_categories",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "job_categories",
                newName: "category_name");

            migrationBuilder.RenameIndex(
                name: "IX_job_categories_ParentCategoryId",
                table: "job_categories",
                newName: "IX_job_categories_parent_category_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "job_applications",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "job_applications",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ResumeId",
                table: "job_applications",
                newName: "resume_id");

            migrationBuilder.RenameColumn(
                name: "JobId",
                table: "job_applications",
                newName: "job_id");

            migrationBuilder.RenameColumn(
                name: "EmployerNotes",
                table: "job_applications",
                newName: "employer_notes");

            migrationBuilder.RenameColumn(
                name: "CoverLetter",
                table: "job_applications",
                newName: "cover_letter");

            migrationBuilder.RenameColumn(
                name: "CandidateId",
                table: "job_applications",
                newName: "candidate_id");

            migrationBuilder.RenameColumn(
                name: "AppliedAt",
                table: "job_applications",
                newName: "applied_at");

            migrationBuilder.RenameIndex(
                name: "IX_job_applications_ResumeId",
                table: "job_applications",
                newName: "IX_job_applications_resume_id");

            migrationBuilder.RenameIndex(
                name: "IX_job_applications_CandidateId",
                table: "job_applications",
                newName: "IX_job_applications_candidate_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "job_alerts",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "job_alerts",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "MinSalary",
                table: "job_alerts",
                newName: "min_salary");

            migrationBuilder.RenameColumn(
                name: "JobTypeId",
                table: "job_alerts",
                newName: "job_type_id");

            migrationBuilder.RenameColumn(
                name: "JobCategoryId",
                table: "job_alerts",
                newName: "job_category_id");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "job_alerts",
                newName: "is_active");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "job_alerts",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "CandidateId",
                table: "job_alerts",
                newName: "candidate_id");

            migrationBuilder.RenameColumn(
                name: "AlertName",
                table: "job_alerts",
                newName: "alert_name");

            migrationBuilder.RenameIndex(
                name: "IX_job_alerts_JobTypeId",
                table: "job_alerts",
                newName: "IX_job_alerts_job_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_job_alerts_JobCategoryId",
                table: "job_alerts",
                newName: "IX_job_alerts_job_category_id");

            migrationBuilder.RenameIndex(
                name: "IX_job_alerts_CandidateId",
                table: "job_alerts",
                newName: "IX_job_alerts_candidate_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "industries",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "IndustryName",
                table: "industries",
                newName: "industry_name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "experience_levels",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "LevelName",
                table: "experience_levels",
                newName: "level_name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "employers",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "WebsiteUrl",
                table: "employers",
                newName: "website_url");

            migrationBuilder.RenameColumn(
                name: "VerificationDocuments",
                table: "employers",
                newName: "verification_documents");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "employers",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "employers",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "IsVerified",
                table: "employers",
                newName: "is_verified");

            migrationBuilder.RenameColumn(
                name: "IndustryId",
                table: "employers",
                newName: "industry_id");

            migrationBuilder.RenameColumn(
                name: "HeadquartersState",
                table: "employers",
                newName: "headquarters_state");

            migrationBuilder.RenameColumn(
                name: "HeadquartersCountry",
                table: "employers",
                newName: "headquarters_country");

            migrationBuilder.RenameColumn(
                name: "HeadquartersCity",
                table: "employers",
                newName: "headquarters_city");

            migrationBuilder.RenameColumn(
                name: "HeadquartersAddress",
                table: "employers",
                newName: "headquarters_address");

            migrationBuilder.RenameColumn(
                name: "FoundedYear",
                table: "employers",
                newName: "founded_year");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "employers",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "ContactPhone",
                table: "employers",
                newName: "contact_phone");

            migrationBuilder.RenameColumn(
                name: "ContactPersonName",
                table: "employers",
                newName: "contact_person_name");

            migrationBuilder.RenameColumn(
                name: "ContactEmail",
                table: "employers",
                newName: "contact_email");

            migrationBuilder.RenameColumn(
                name: "CompanySizeId",
                table: "employers",
                newName: "company_size_id");

            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "employers",
                newName: "company_name");

            migrationBuilder.RenameColumn(
                name: "CompanyLogo",
                table: "employers",
                newName: "company_logo");

            migrationBuilder.RenameColumn(
                name: "CompanyDescription",
                table: "employers",
                newName: "company_description");

            migrationBuilder.RenameIndex(
                name: "IX_employers_IndustryId",
                table: "employers",
                newName: "IX_employers_industry_id");

            migrationBuilder.RenameIndex(
                name: "IX_employers_CompanySizeId",
                table: "employers",
                newName: "IX_employers_company_size_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "employer_social_media",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "employer_social_media",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ProfileUrl",
                table: "employer_social_media",
                newName: "profile_url");

            migrationBuilder.RenameColumn(
                name: "PlatformName",
                table: "employer_social_media",
                newName: "platform_name");

            migrationBuilder.RenameColumn(
                name: "EmployerId",
                table: "employer_social_media",
                newName: "employer_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "employer_social_media",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "employer_reviews",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "employer_reviews",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "employer_reviews",
                newName: "rating");

            migrationBuilder.RenameColumn(
                name: "Pros",
                table: "employer_reviews",
                newName: "pros");

            migrationBuilder.RenameColumn(
                name: "Cons",
                table: "employer_reviews",
                newName: "cons");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "employer_reviews",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "employer_reviews",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ReviewText",
                table: "employer_reviews",
                newName: "review_text");

            migrationBuilder.RenameColumn(
                name: "IsAnonymous",
                table: "employer_reviews",
                newName: "is_anonymous");

            migrationBuilder.RenameColumn(
                name: "EmployerId",
                table: "employer_reviews",
                newName: "employer_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "employer_reviews",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "CandidateId",
                table: "employer_reviews",
                newName: "candidate_id");

            migrationBuilder.RenameIndex(
                name: "IX_employer_reviews_CandidateId",
                table: "employer_reviews",
                newName: "IX_employer_reviews_candidate_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "employer_benefits",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "employer_benefits",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "EmployerId",
                table: "employer_benefits",
                newName: "employer_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "employer_benefits",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "BenefitName",
                table: "employer_benefits",
                newName: "benefit_name");

            migrationBuilder.RenameColumn(
                name: "BenefitDescription",
                table: "employer_benefits",
                newName: "benefit_description");

            migrationBuilder.RenameIndex(
                name: "IX_employer_benefits_EmployerId",
                table: "employer_benefits",
                newName: "IX_employer_benefits_employer_id");

            migrationBuilder.RenameColumn(
                name: "Variables",
                table: "email_templates",
                newName: "variables");

            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "email_templates",
                newName: "subject");

            migrationBuilder.RenameColumn(
                name: "Body",
                table: "email_templates",
                newName: "body");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "email_templates",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "email_templates",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "TemplateName",
                table: "email_templates",
                newName: "template_name");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "email_templates",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "email_settings",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "email_settings",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "email_settings",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ProfileViews",
                table: "email_settings",
                newName: "profile_views");

            migrationBuilder.RenameColumn(
                name: "MarketingEmails",
                table: "email_settings",
                newName: "marketing_emails");

            migrationBuilder.RenameColumn(
                name: "JobRecommendations",
                table: "email_settings",
                newName: "job_recommendations");

            migrationBuilder.RenameColumn(
                name: "JobAlerts",
                table: "email_settings",
                newName: "job_alerts");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "email_settings",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "ApplicationUpdates",
                table: "email_settings",
                newName: "application_updates");

            migrationBuilder.RenameIndex(
                name: "IX_email_settings_UserId",
                table: "email_settings",
                newName: "IX_email_settings_user_id");

            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "email_logs",
                newName: "subject");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "email_logs",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "email_logs",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TemplateId",
                table: "email_logs",
                newName: "template_id");

            migrationBuilder.RenameColumn(
                name: "SentAt",
                table: "email_logs",
                newName: "sent_at");

            migrationBuilder.RenameColumn(
                name: "RecipientEmail",
                table: "email_logs",
                newName: "recipient_email");

            migrationBuilder.RenameColumn(
                name: "ErrorMessage",
                table: "email_logs",
                newName: "error_message");

            migrationBuilder.RenameIndex(
                name: "IX_email_logs_TemplateId",
                table: "email_logs",
                newName: "IX_email_logs_template_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "education_levels",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "LevelName",
                table: "education_levels",
                newName: "level_name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "company_sizes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SizeRange",
                table: "company_sizes",
                newName: "size_range");

            migrationBuilder.RenameColumn(
                name: "Caption",
                table: "company_photos",
                newName: "caption");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "company_photos",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "PhotoUrl",
                table: "company_photos",
                newName: "photo_url");

            migrationBuilder.RenameColumn(
                name: "EmployerId",
                table: "company_photos",
                newName: "employer_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "company_photos",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_company_photos_EmployerId",
                table: "company_photos",
                newName: "IX_company_photos_employer_id");

            migrationBuilder.RenameColumn(
                name: "Summary",
                table: "candidates",
                newName: "summary");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "candidates",
                newName: "state");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "candidates",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Headline",
                table: "candidates",
                newName: "headline");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "candidates",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "candidates",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "candidates",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "candidates",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "candidates",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "candidates",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "candidates",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "SalaryExpectation",
                table: "candidates",
                newName: "salary_expectation");

            migrationBuilder.RenameColumn(
                name: "ProfilePicture",
                table: "candidates",
                newName: "profile_picture");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "candidates",
                newName: "postal_code");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "candidates",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "IsAvailableForHire",
                table: "candidates",
                newName: "is_available_for_hire");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "candidates",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "ExperienceYears",
                table: "candidates",
                newName: "experience_years");

            migrationBuilder.RenameColumn(
                name: "CurrentSalary",
                table: "candidates",
                newName: "current_salary");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "candidates",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "candidates",
                newName: "birth_date");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "candidate_skills",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "YearsExperience",
                table: "candidate_skills",
                newName: "years_experience");

            migrationBuilder.RenameColumn(
                name: "SkillId",
                table: "candidate_skills",
                newName: "skill_id");

            migrationBuilder.RenameColumn(
                name: "ProficiencyLevel",
                table: "candidate_skills",
                newName: "proficiency_level");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "candidate_skills",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "CandidateId",
                table: "candidate_skills",
                newName: "candidate_id");

            migrationBuilder.RenameIndex(
                name: "IX_candidate_skills_SkillId",
                table: "candidate_skills",
                newName: "IX_candidate_skills_skill_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "candidate_resumes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "candidate_resumes",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "IsDefault",
                table: "candidate_resumes",
                newName: "is_default");

            migrationBuilder.RenameColumn(
                name: "FileType",
                table: "candidate_resumes",
                newName: "file_type");

            migrationBuilder.RenameColumn(
                name: "FileSize",
                table: "candidate_resumes",
                newName: "file_size");

            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "candidate_resumes",
                newName: "file_path");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "candidate_resumes",
                newName: "file_name");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "candidate_resumes",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "CandidateId",
                table: "candidate_resumes",
                newName: "candidate_id");

            migrationBuilder.RenameIndex(
                name: "IX_candidate_resumes_CandidateId",
                table: "candidate_resumes",
                newName: "IX_candidate_resumes_candidate_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "candidate_preferences",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "candidate_preferences",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "TravelWillingness",
                table: "candidate_preferences",
                newName: "travel_willingness");

            migrationBuilder.RenameColumn(
                name: "RemotePreference",
                table: "candidate_preferences",
                newName: "remote_preference");

            migrationBuilder.RenameColumn(
                name: "RelocationWillingness",
                table: "candidate_preferences",
                newName: "relocation_willingness");

            migrationBuilder.RenameColumn(
                name: "PreferredLocation",
                table: "candidate_preferences",
                newName: "preferred_location");

            migrationBuilder.RenameColumn(
                name: "MinSalary",
                table: "candidate_preferences",
                newName: "min_salary");

            migrationBuilder.RenameColumn(
                name: "JobType",
                table: "candidate_preferences",
                newName: "job_type");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "candidate_preferences",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "CandidateId",
                table: "candidate_preferences",
                newName: "candidate_id");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "candidate_portfolios",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "candidate_portfolios",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "candidate_portfolios",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "candidate_portfolios",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "ProjectUrl",
                table: "candidate_portfolios",
                newName: "project_url");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "candidate_portfolios",
                newName: "image_url");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "candidate_portfolios",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "CandidateId",
                table: "candidate_portfolios",
                newName: "candidate_id");

            migrationBuilder.RenameIndex(
                name: "IX_candidate_portfolios_CandidateId",
                table: "candidate_portfolios",
                newName: "IX_candidate_portfolios_candidate_id");

            migrationBuilder.RenameColumn(
                name: "Responsibilities",
                table: "candidate_experiences",
                newName: "responsibilities");

            migrationBuilder.RenameColumn(
                name: "Position",
                table: "candidate_experiences",
                newName: "position");

            migrationBuilder.RenameColumn(
                name: "Achievements",
                table: "candidate_experiences",
                newName: "achievements");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "candidate_experiences",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "candidate_experiences",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "candidate_experiences",
                newName: "start_date");

            migrationBuilder.RenameColumn(
                name: "IsCurrent",
                table: "candidate_experiences",
                newName: "is_current");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "candidate_experiences",
                newName: "end_date");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "candidate_experiences",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "candidate_experiences",
                newName: "company_name");

            migrationBuilder.RenameColumn(
                name: "CandidateId",
                table: "candidate_experiences",
                newName: "candidate_id");

            migrationBuilder.RenameIndex(
                name: "IX_candidate_experiences_CandidateId",
                table: "candidate_experiences",
                newName: "IX_candidate_experiences_candidate_id");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "candidate_educations",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "candidate_educations",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "candidate_educations",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "candidate_educations",
                newName: "start_date");

            migrationBuilder.RenameColumn(
                name: "IsCurrent",
                table: "candidate_educations",
                newName: "is_current");

            migrationBuilder.RenameColumn(
                name: "InstitutionName",
                table: "candidate_educations",
                newName: "institution_name");

            migrationBuilder.RenameColumn(
                name: "FieldOfStudy",
                table: "candidate_educations",
                newName: "field_of_study");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "candidate_educations",
                newName: "end_date");

            migrationBuilder.RenameColumn(
                name: "EducationLevelId",
                table: "candidate_educations",
                newName: "education_level_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "candidate_educations",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "CandidateId",
                table: "candidate_educations",
                newName: "candidate_id");

            migrationBuilder.RenameIndex(
                name: "IX_candidate_educations_EducationLevelId",
                table: "candidate_educations",
                newName: "IX_candidate_educations_education_level_id");

            migrationBuilder.RenameIndex(
                name: "IX_candidate_educations_CandidateId",
                table: "candidate_educations",
                newName: "IX_candidate_educations_candidate_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "admin_settings",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "admin_settings",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "SettingValue",
                table: "admin_settings",
                newName: "setting_value");

            migrationBuilder.RenameColumn(
                name: "SettingName",
                table: "admin_settings",
                newName: "setting_name");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "admin_settings",
                newName: "created_at");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status",
                table: "website_reviews",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "rating",
                table: "website_reviews",
                newName: "Rating");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "website_reviews",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "website_reviews",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "website_reviews",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "review_text",
                table: "website_reviews",
                newName: "ReviewText");

            migrationBuilder.RenameColumn(
                name: "is_featured",
                table: "website_reviews",
                newName: "IsFeatured");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "website_reviews",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_website_reviews_user_id",
                table: "website_reviews",
                newName: "IX_website_reviews_UserId");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_name",
                table: "users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "two_factor_enabled",
                table: "users",
                newName: "TwoFactorEnabled");

            migrationBuilder.RenameColumn(
                name: "security_stamp",
                table: "users",
                newName: "SecurityStamp");

            migrationBuilder.RenameColumn(
                name: "phone_number_confirmed",
                table: "users",
                newName: "PhoneNumberConfirmed");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "users",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "password_hash",
                table: "users",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "normalized_user_name",
                table: "users",
                newName: "NormalizedUserName");

            migrationBuilder.RenameColumn(
                name: "normalized_email",
                table: "users",
                newName: "NormalizedEmail");

            migrationBuilder.RenameColumn(
                name: "lockout_end",
                table: "users",
                newName: "LockoutEnd");

            migrationBuilder.RenameColumn(
                name: "lockout_enabled",
                table: "users",
                newName: "LockoutEnabled");

            migrationBuilder.RenameColumn(
                name: "email_confirmed",
                table: "users",
                newName: "EmailConfirmed");

            migrationBuilder.RenameColumn(
                name: "concurrency_stamp",
                table: "users",
                newName: "ConcurrencyStamp");

            migrationBuilder.RenameColumn(
                name: "access_failed_count",
                table: "users",
                newName: "AccessFailedCount");

            migrationBuilder.RenameColumn(
                name: "value",
                table: "user_tokens",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "user_tokens",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "login_provider",
                table: "user_tokens",
                newName: "LoginProvider");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "user_tokens",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "user_logins",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "provider_display_name",
                table: "user_logins",
                newName: "ProviderDisplayName");

            migrationBuilder.RenameColumn(
                name: "provider_key",
                table: "user_logins",
                newName: "ProviderKey");

            migrationBuilder.RenameColumn(
                name: "login_provider",
                table: "user_logins",
                newName: "LoginProvider");

            migrationBuilder.RenameIndex(
                name: "IX_user_logins_user_id",
                table: "user_logins",
                newName: "IX_user_logins_UserId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "user_claims",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "user_claims",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "claim_value",
                table: "user_claims",
                newName: "ClaimValue");

            migrationBuilder.RenameColumn(
                name: "claim_type",
                table: "user_claims",
                newName: "ClaimType");

            migrationBuilder.RenameIndex(
                name: "IX_user_claims_user_id",
                table: "user_claims",
                newName: "IX_user_claims_UserId");

            migrationBuilder.RenameColumn(
                name: "details",
                table: "user_activity_logs",
                newName: "Details");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "user_activity_logs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "user_activity_logs",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "user_agent",
                table: "user_activity_logs",
                newName: "UserAgent");

            migrationBuilder.RenameColumn(
                name: "ip_address",
                table: "user_activity_logs",
                newName: "IpAddress");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "user_activity_logs",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "activity_type",
                table: "user_activity_logs",
                newName: "ActivityType");

            migrationBuilder.RenameIndex(
                name: "IX_user_activity_logs_user_id",
                table: "user_activity_logs",
                newName: "IX_user_activity_logs_UserId");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "subscriptions",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "subscriptions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "subscriptions",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "subscriptions",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "start_date",
                table: "subscriptions",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "renewal_date",
                table: "subscriptions",
                newName: "RenewalDate");

            migrationBuilder.RenameColumn(
                name: "plan_id",
                table: "subscriptions",
                newName: "PlanId");

            migrationBuilder.RenameColumn(
                name: "payment_method",
                table: "subscriptions",
                newName: "PaymentMethod");

            migrationBuilder.RenameColumn(
                name: "end_date",
                table: "subscriptions",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "subscriptions",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "auto_renew",
                table: "subscriptions",
                newName: "AutoRenew");

            migrationBuilder.RenameIndex(
                name: "IX_subscriptions_user_id",
                table: "subscriptions",
                newName: "IX_subscriptions_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_subscriptions_plan_id",
                table: "subscriptions",
                newName: "IX_subscriptions_PlanId");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "subscription_plans",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "subscription_plans",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "currency",
                table: "subscription_plans",
                newName: "Currency");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "subscription_plans",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "subscription_plans",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "resume_access_limit",
                table: "subscription_plans",
                newName: "ResumeAccessLimit");

            migrationBuilder.RenameColumn(
                name: "profile_visibility",
                table: "subscription_plans",
                newName: "ProfileVisibility");

            migrationBuilder.RenameColumn(
                name: "priority_listing",
                table: "subscription_plans",
                newName: "PriorityListing");

            migrationBuilder.RenameColumn(
                name: "plan_type",
                table: "subscription_plans",
                newName: "PlanType");

            migrationBuilder.RenameColumn(
                name: "plan_name",
                table: "subscription_plans",
                newName: "PlanName");

            migrationBuilder.RenameColumn(
                name: "job_posting_limit",
                table: "subscription_plans",
                newName: "JobPostingLimit");

            migrationBuilder.RenameColumn(
                name: "featured_job_limit",
                table: "subscription_plans",
                newName: "FeaturedJobLimit");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "subscription_plans",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "candidate_search_limit",
                table: "subscription_plans",
                newName: "CandidateSearchLimit");

            migrationBuilder.RenameColumn(
                name: "billing_cycle",
                table: "subscription_plans",
                newName: "BillingCycle");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "skills",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "skill_name",
                table: "skills",
                newName: "SkillName");

            migrationBuilder.RenameColumn(
                name: "category_id",
                table: "skills",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_skills_category_id",
                table: "skills",
                newName: "IX_skills_CategoryId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "skill_categories",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "category_name",
                table: "skill_categories",
                newName: "CategoryName");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "saved_jobs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "saved_at",
                table: "saved_jobs",
                newName: "SavedAt");

            migrationBuilder.RenameColumn(
                name: "job_id",
                table: "saved_jobs",
                newName: "JobId");

            migrationBuilder.RenameColumn(
                name: "candidate_id",
                table: "saved_jobs",
                newName: "CandidateId");

            migrationBuilder.RenameIndex(
                name: "IX_saved_jobs_job_id",
                table: "saved_jobs",
                newName: "IX_saved_jobs_JobId");

            migrationBuilder.RenameColumn(
                name: "notes",
                table: "saved_candidates",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "saved_candidates",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "saved_at",
                table: "saved_candidates",
                newName: "SavedAt");

            migrationBuilder.RenameColumn(
                name: "employer_id",
                table: "saved_candidates",
                newName: "EmployerId");

            migrationBuilder.RenameColumn(
                name: "candidate_id",
                table: "saved_candidates",
                newName: "CandidateId");

            migrationBuilder.RenameIndex(
                name: "IX_saved_candidates_candidate_id",
                table: "saved_candidates",
                newName: "IX_saved_candidates_CandidateId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "roles",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "roles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "normalized_name",
                table: "roles",
                newName: "NormalizedName");

            migrationBuilder.RenameColumn(
                name: "concurrency_stamp",
                table: "roles",
                newName: "ConcurrencyStamp");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "role_claims",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "role_id",
                table: "role_claims",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "claim_value",
                table: "role_claims",
                newName: "ClaimValue");

            migrationBuilder.RenameColumn(
                name: "claim_type",
                table: "role_claims",
                newName: "ClaimType");

            migrationBuilder.RenameIndex(
                name: "IX_role_claims_role_id",
                table: "role_claims",
                newName: "IX_role_claims_RoleId");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "reported_content",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "reason",
                table: "reported_content",
                newName: "Reason");

            migrationBuilder.RenameColumn(
                name: "details",
                table: "reported_content",
                newName: "Details");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "reported_content",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "reported_content",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "reporter_user_id",
                table: "reported_content",
                newName: "ReporterUserId");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "reported_content",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "content_type",
                table: "reported_content",
                newName: "ContentType");

            migrationBuilder.RenameColumn(
                name: "content_id",
                table: "reported_content",
                newName: "ContentId");

            migrationBuilder.RenameColumn(
                name: "admin_notes",
                table: "reported_content",
                newName: "AdminNotes");

            migrationBuilder.RenameIndex(
                name: "IX_reported_content_reporter_user_id",
                table: "reported_content",
                newName: "IX_reported_content_ReporterUserId");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "payments",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "payments",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "currency",
                table: "payments",
                newName: "Currency");

            migrationBuilder.RenameColumn(
                name: "amount",
                table: "payments",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "payments",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "payments",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "transaction_id",
                table: "payments",
                newName: "TransactionId");

            migrationBuilder.RenameColumn(
                name: "subscription_id",
                table: "payments",
                newName: "SubscriptionId");

            migrationBuilder.RenameColumn(
                name: "payment_method",
                table: "payments",
                newName: "PaymentMethod");

            migrationBuilder.RenameColumn(
                name: "payment_date",
                table: "payments",
                newName: "PaymentDate");

            migrationBuilder.RenameIndex(
                name: "IX_payments_user_id",
                table: "payments",
                newName: "IX_payments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_payments_subscription_id",
                table: "payments",
                newName: "IX_payments_SubscriptionId");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "notifications",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "message",
                table: "notifications",
                newName: "Message");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "notifications",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "notifications",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "related_entity_type",
                table: "notifications",
                newName: "RelatedEntityType");

            migrationBuilder.RenameColumn(
                name: "related_entity_id",
                table: "notifications",
                newName: "RelatedEntityId");

            migrationBuilder.RenameColumn(
                name: "notification_type_id",
                table: "notifications",
                newName: "NotificationTypeId");

            migrationBuilder.RenameColumn(
                name: "is_read",
                table: "notifications",
                newName: "IsRead");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "notifications",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_notifications_user_id",
                table: "notifications",
                newName: "IX_notifications_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_notifications_notification_type_id",
                table: "notifications",
                newName: "IX_notifications_NotificationTypeId");

            migrationBuilder.RenameColumn(
                name: "template",
                table: "notification_types",
                newName: "Template");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "notification_types",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "type_name",
                table: "notification_types",
                newName: "TypeName");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "notification_types",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "jobs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "views_count",
                table: "jobs",
                newName: "ViewsCount");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "jobs",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "salary_period",
                table: "jobs",
                newName: "SalaryPeriod");

            migrationBuilder.RenameColumn(
                name: "posted_at",
                table: "jobs",
                newName: "PostedAt");

            migrationBuilder.RenameColumn(
                name: "min_salary",
                table: "jobs",
                newName: "MinSalary");

            migrationBuilder.RenameColumn(
                name: "min_education_id",
                table: "jobs",
                newName: "MinEducationId");

            migrationBuilder.RenameColumn(
                name: "max_salary",
                table: "jobs",
                newName: "MaxSalary");

            migrationBuilder.RenameColumn(
                name: "location_state",
                table: "jobs",
                newName: "LocationState");

            migrationBuilder.RenameColumn(
                name: "location_country",
                table: "jobs",
                newName: "LocationCountry");

            migrationBuilder.RenameColumn(
                name: "location_city",
                table: "jobs",
                newName: "LocationCity");

            migrationBuilder.RenameColumn(
                name: "job_type_id",
                table: "jobs",
                newName: "JobTypeId");

            migrationBuilder.RenameColumn(
                name: "job_category_id",
                table: "jobs",
                newName: "JobCategoryId");

            migrationBuilder.RenameColumn(
                name: "is_salary_negotiable",
                table: "jobs",
                newName: "IsSalaryNegotiable");

            migrationBuilder.RenameColumn(
                name: "is_remote",
                table: "jobs",
                newName: "IsRemote");

            migrationBuilder.RenameColumn(
                name: "is_featured",
                table: "jobs",
                newName: "IsFeatured");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "jobs",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "expires_at",
                table: "jobs",
                newName: "ExpiresAt");

            migrationBuilder.RenameColumn(
                name: "experience_level_id",
                table: "jobs",
                newName: "ExperienceLevelId");

            migrationBuilder.RenameColumn(
                name: "employer_id",
                table: "jobs",
                newName: "EmployerId");

            migrationBuilder.RenameColumn(
                name: "applications_count",
                table: "jobs",
                newName: "ApplicationsCount");

            migrationBuilder.RenameColumn(
                name: "application_deadline",
                table: "jobs",
                newName: "ApplicationDeadline");

            migrationBuilder.RenameColumn(
                name: "allows_work_from_home",
                table: "jobs",
                newName: "AllowsWorkFromHome");

            migrationBuilder.RenameIndex(
                name: "IX_jobs_min_education_id",
                table: "jobs",
                newName: "IX_jobs_MinEducationId");

            migrationBuilder.RenameIndex(
                name: "IX_jobs_job_type_id",
                table: "jobs",
                newName: "IX_jobs_JobTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_jobs_job_category_id",
                table: "jobs",
                newName: "IX_jobs_JobCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_jobs_experience_level_id",
                table: "jobs",
                newName: "IX_jobs_ExperienceLevelId");

            migrationBuilder.RenameIndex(
                name: "IX_jobs_employer_id",
                table: "jobs",
                newName: "IX_jobs_EmployerId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "job_types",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "type_name",
                table: "job_types",
                newName: "TypeName");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "job_skills",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "skill_id",
                table: "job_skills",
                newName: "SkillId");

            migrationBuilder.RenameColumn(
                name: "job_id",
                table: "job_skills",
                newName: "JobId");

            migrationBuilder.RenameColumn(
                name: "is_required",
                table: "job_skills",
                newName: "IsRequired");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "job_skills",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_job_skills_skill_id",
                table: "job_skills",
                newName: "IX_job_skills_SkillId");

            migrationBuilder.RenameColumn(
                name: "location",
                table: "job_search_logs",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "job_search_logs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "job_search_logs",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "search_keyword",
                table: "job_search_logs",
                newName: "SearchKeyword");

            migrationBuilder.RenameColumn(
                name: "search_date",
                table: "job_search_logs",
                newName: "SearchDate");

            migrationBuilder.RenameColumn(
                name: "results_count",
                table: "job_search_logs",
                newName: "ResultsCount");

            migrationBuilder.RenameColumn(
                name: "min_salary",
                table: "job_search_logs",
                newName: "MinSalary");

            migrationBuilder.RenameColumn(
                name: "max_salary",
                table: "job_search_logs",
                newName: "MaxSalary");

            migrationBuilder.RenameColumn(
                name: "job_type_id",
                table: "job_search_logs",
                newName: "JobTypeId");

            migrationBuilder.RenameColumn(
                name: "job_category_id",
                table: "job_search_logs",
                newName: "JobCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_job_search_logs_user_id",
                table: "job_search_logs",
                newName: "IX_job_search_logs_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_job_search_logs_job_type_id",
                table: "job_search_logs",
                newName: "IX_job_search_logs_JobTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_job_search_logs_job_category_id",
                table: "job_search_logs",
                newName: "IX_job_search_logs_JobCategoryId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "job_categories",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "parent_category_id",
                table: "job_categories",
                newName: "ParentCategoryId");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "job_categories",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "category_name",
                table: "job_categories",
                newName: "CategoryName");

            migrationBuilder.RenameIndex(
                name: "IX_job_categories_parent_category_id",
                table: "job_categories",
                newName: "IX_job_categories_ParentCategoryId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "job_applications",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "job_applications",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "resume_id",
                table: "job_applications",
                newName: "ResumeId");

            migrationBuilder.RenameColumn(
                name: "job_id",
                table: "job_applications",
                newName: "JobId");

            migrationBuilder.RenameColumn(
                name: "employer_notes",
                table: "job_applications",
                newName: "EmployerNotes");

            migrationBuilder.RenameColumn(
                name: "cover_letter",
                table: "job_applications",
                newName: "CoverLetter");

            migrationBuilder.RenameColumn(
                name: "candidate_id",
                table: "job_applications",
                newName: "CandidateId");

            migrationBuilder.RenameColumn(
                name: "applied_at",
                table: "job_applications",
                newName: "AppliedAt");

            migrationBuilder.RenameIndex(
                name: "IX_job_applications_resume_id",
                table: "job_applications",
                newName: "IX_job_applications_ResumeId");

            migrationBuilder.RenameIndex(
                name: "IX_job_applications_candidate_id",
                table: "job_applications",
                newName: "IX_job_applications_CandidateId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "job_alerts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "job_alerts",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "min_salary",
                table: "job_alerts",
                newName: "MinSalary");

            migrationBuilder.RenameColumn(
                name: "job_type_id",
                table: "job_alerts",
                newName: "JobTypeId");

            migrationBuilder.RenameColumn(
                name: "job_category_id",
                table: "job_alerts",
                newName: "JobCategoryId");

            migrationBuilder.RenameColumn(
                name: "is_active",
                table: "job_alerts",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "job_alerts",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "candidate_id",
                table: "job_alerts",
                newName: "CandidateId");

            migrationBuilder.RenameColumn(
                name: "alert_name",
                table: "job_alerts",
                newName: "AlertName");

            migrationBuilder.RenameIndex(
                name: "IX_job_alerts_job_type_id",
                table: "job_alerts",
                newName: "IX_job_alerts_JobTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_job_alerts_job_category_id",
                table: "job_alerts",
                newName: "IX_job_alerts_JobCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_job_alerts_candidate_id",
                table: "job_alerts",
                newName: "IX_job_alerts_CandidateId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "industries",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "industry_name",
                table: "industries",
                newName: "IndustryName");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "experience_levels",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "level_name",
                table: "experience_levels",
                newName: "LevelName");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "employers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "website_url",
                table: "employers",
                newName: "WebsiteUrl");

            migrationBuilder.RenameColumn(
                name: "verification_documents",
                table: "employers",
                newName: "VerificationDocuments");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "employers",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "employers",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "is_verified",
                table: "employers",
                newName: "IsVerified");

            migrationBuilder.RenameColumn(
                name: "industry_id",
                table: "employers",
                newName: "IndustryId");

            migrationBuilder.RenameColumn(
                name: "headquarters_state",
                table: "employers",
                newName: "HeadquartersState");

            migrationBuilder.RenameColumn(
                name: "headquarters_country",
                table: "employers",
                newName: "HeadquartersCountry");

            migrationBuilder.RenameColumn(
                name: "headquarters_city",
                table: "employers",
                newName: "HeadquartersCity");

            migrationBuilder.RenameColumn(
                name: "headquarters_address",
                table: "employers",
                newName: "HeadquartersAddress");

            migrationBuilder.RenameColumn(
                name: "founded_year",
                table: "employers",
                newName: "FoundedYear");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "employers",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "contact_phone",
                table: "employers",
                newName: "ContactPhone");

            migrationBuilder.RenameColumn(
                name: "contact_person_name",
                table: "employers",
                newName: "ContactPersonName");

            migrationBuilder.RenameColumn(
                name: "contact_email",
                table: "employers",
                newName: "ContactEmail");

            migrationBuilder.RenameColumn(
                name: "company_size_id",
                table: "employers",
                newName: "CompanySizeId");

            migrationBuilder.RenameColumn(
                name: "company_name",
                table: "employers",
                newName: "CompanyName");

            migrationBuilder.RenameColumn(
                name: "company_logo",
                table: "employers",
                newName: "CompanyLogo");

            migrationBuilder.RenameColumn(
                name: "company_description",
                table: "employers",
                newName: "CompanyDescription");

            migrationBuilder.RenameIndex(
                name: "IX_employers_industry_id",
                table: "employers",
                newName: "IX_employers_IndustryId");

            migrationBuilder.RenameIndex(
                name: "IX_employers_company_size_id",
                table: "employers",
                newName: "IX_employers_CompanySizeId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "employer_social_media",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "employer_social_media",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "profile_url",
                table: "employer_social_media",
                newName: "ProfileUrl");

            migrationBuilder.RenameColumn(
                name: "platform_name",
                table: "employer_social_media",
                newName: "PlatformName");

            migrationBuilder.RenameColumn(
                name: "employer_id",
                table: "employer_social_media",
                newName: "EmployerId");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "employer_social_media",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "employer_reviews",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "employer_reviews",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "rating",
                table: "employer_reviews",
                newName: "Rating");

            migrationBuilder.RenameColumn(
                name: "pros",
                table: "employer_reviews",
                newName: "Pros");

            migrationBuilder.RenameColumn(
                name: "cons",
                table: "employer_reviews",
                newName: "Cons");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "employer_reviews",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "employer_reviews",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "review_text",
                table: "employer_reviews",
                newName: "ReviewText");

            migrationBuilder.RenameColumn(
                name: "is_anonymous",
                table: "employer_reviews",
                newName: "IsAnonymous");

            migrationBuilder.RenameColumn(
                name: "employer_id",
                table: "employer_reviews",
                newName: "EmployerId");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "employer_reviews",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "candidate_id",
                table: "employer_reviews",
                newName: "CandidateId");

            migrationBuilder.RenameIndex(
                name: "IX_employer_reviews_candidate_id",
                table: "employer_reviews",
                newName: "IX_employer_reviews_CandidateId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "employer_benefits",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "employer_benefits",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "employer_id",
                table: "employer_benefits",
                newName: "EmployerId");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "employer_benefits",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "benefit_name",
                table: "employer_benefits",
                newName: "BenefitName");

            migrationBuilder.RenameColumn(
                name: "benefit_description",
                table: "employer_benefits",
                newName: "BenefitDescription");

            migrationBuilder.RenameIndex(
                name: "IX_employer_benefits_employer_id",
                table: "employer_benefits",
                newName: "IX_employer_benefits_EmployerId");

            migrationBuilder.RenameColumn(
                name: "variables",
                table: "email_templates",
                newName: "Variables");

            migrationBuilder.RenameColumn(
                name: "subject",
                table: "email_templates",
                newName: "Subject");

            migrationBuilder.RenameColumn(
                name: "body",
                table: "email_templates",
                newName: "Body");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "email_templates",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "email_templates",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "template_name",
                table: "email_templates",
                newName: "TemplateName");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "email_templates",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "email_settings",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "email_settings",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "email_settings",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "profile_views",
                table: "email_settings",
                newName: "ProfileViews");

            migrationBuilder.RenameColumn(
                name: "marketing_emails",
                table: "email_settings",
                newName: "MarketingEmails");

            migrationBuilder.RenameColumn(
                name: "job_recommendations",
                table: "email_settings",
                newName: "JobRecommendations");

            migrationBuilder.RenameColumn(
                name: "job_alerts",
                table: "email_settings",
                newName: "JobAlerts");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "email_settings",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "application_updates",
                table: "email_settings",
                newName: "ApplicationUpdates");

            migrationBuilder.RenameIndex(
                name: "IX_email_settings_user_id",
                table: "email_settings",
                newName: "IX_email_settings_UserId");

            migrationBuilder.RenameColumn(
                name: "subject",
                table: "email_logs",
                newName: "Subject");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "email_logs",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "email_logs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "template_id",
                table: "email_logs",
                newName: "TemplateId");

            migrationBuilder.RenameColumn(
                name: "sent_at",
                table: "email_logs",
                newName: "SentAt");

            migrationBuilder.RenameColumn(
                name: "recipient_email",
                table: "email_logs",
                newName: "RecipientEmail");

            migrationBuilder.RenameColumn(
                name: "error_message",
                table: "email_logs",
                newName: "ErrorMessage");

            migrationBuilder.RenameIndex(
                name: "IX_email_logs_template_id",
                table: "email_logs",
                newName: "IX_email_logs_TemplateId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "education_levels",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "level_name",
                table: "education_levels",
                newName: "LevelName");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "company_sizes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "size_range",
                table: "company_sizes",
                newName: "SizeRange");

            migrationBuilder.RenameColumn(
                name: "caption",
                table: "company_photos",
                newName: "Caption");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "company_photos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "photo_url",
                table: "company_photos",
                newName: "PhotoUrl");

            migrationBuilder.RenameColumn(
                name: "employer_id",
                table: "company_photos",
                newName: "EmployerId");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "company_photos",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_company_photos_employer_id",
                table: "company_photos",
                newName: "IX_company_photos_EmployerId");

            migrationBuilder.RenameColumn(
                name: "summary",
                table: "candidates",
                newName: "Summary");

            migrationBuilder.RenameColumn(
                name: "state",
                table: "candidates",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "candidates",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "headline",
                table: "candidates",
                newName: "Headline");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "candidates",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "candidates",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "candidates",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "candidates",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "candidates",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "candidates",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "candidates",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "salary_expectation",
                table: "candidates",
                newName: "SalaryExpectation");

            migrationBuilder.RenameColumn(
                name: "profile_picture",
                table: "candidates",
                newName: "ProfilePicture");

            migrationBuilder.RenameColumn(
                name: "postal_code",
                table: "candidates",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "candidates",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "is_available_for_hire",
                table: "candidates",
                newName: "IsAvailableForHire");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "candidates",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "experience_years",
                table: "candidates",
                newName: "ExperienceYears");

            migrationBuilder.RenameColumn(
                name: "current_salary",
                table: "candidates",
                newName: "CurrentSalary");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "candidates",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "birth_date",
                table: "candidates",
                newName: "BirthDate");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "candidate_skills",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "years_experience",
                table: "candidate_skills",
                newName: "YearsExperience");

            migrationBuilder.RenameColumn(
                name: "skill_id",
                table: "candidate_skills",
                newName: "SkillId");

            migrationBuilder.RenameColumn(
                name: "proficiency_level",
                table: "candidate_skills",
                newName: "ProficiencyLevel");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "candidate_skills",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "candidate_id",
                table: "candidate_skills",
                newName: "CandidateId");

            migrationBuilder.RenameIndex(
                name: "IX_candidate_skills_skill_id",
                table: "candidate_skills",
                newName: "IX_candidate_skills_SkillId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "candidate_resumes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "candidate_resumes",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "is_default",
                table: "candidate_resumes",
                newName: "IsDefault");

            migrationBuilder.RenameColumn(
                name: "file_type",
                table: "candidate_resumes",
                newName: "FileType");

            migrationBuilder.RenameColumn(
                name: "file_size",
                table: "candidate_resumes",
                newName: "FileSize");

            migrationBuilder.RenameColumn(
                name: "file_path",
                table: "candidate_resumes",
                newName: "FilePath");

            migrationBuilder.RenameColumn(
                name: "file_name",
                table: "candidate_resumes",
                newName: "FileName");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "candidate_resumes",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "candidate_id",
                table: "candidate_resumes",
                newName: "CandidateId");

            migrationBuilder.RenameIndex(
                name: "IX_candidate_resumes_candidate_id",
                table: "candidate_resumes",
                newName: "IX_candidate_resumes_CandidateId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "candidate_preferences",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "candidate_preferences",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "travel_willingness",
                table: "candidate_preferences",
                newName: "TravelWillingness");

            migrationBuilder.RenameColumn(
                name: "remote_preference",
                table: "candidate_preferences",
                newName: "RemotePreference");

            migrationBuilder.RenameColumn(
                name: "relocation_willingness",
                table: "candidate_preferences",
                newName: "RelocationWillingness");

            migrationBuilder.RenameColumn(
                name: "preferred_location",
                table: "candidate_preferences",
                newName: "PreferredLocation");

            migrationBuilder.RenameColumn(
                name: "min_salary",
                table: "candidate_preferences",
                newName: "MinSalary");

            migrationBuilder.RenameColumn(
                name: "job_type",
                table: "candidate_preferences",
                newName: "JobType");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "candidate_preferences",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "candidate_id",
                table: "candidate_preferences",
                newName: "CandidateId");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "candidate_portfolios",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "candidate_portfolios",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "candidate_portfolios",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "candidate_portfolios",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "project_url",
                table: "candidate_portfolios",
                newName: "ProjectUrl");

            migrationBuilder.RenameColumn(
                name: "image_url",
                table: "candidate_portfolios",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "candidate_portfolios",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "candidate_id",
                table: "candidate_portfolios",
                newName: "CandidateId");

            migrationBuilder.RenameIndex(
                name: "IX_candidate_portfolios_candidate_id",
                table: "candidate_portfolios",
                newName: "IX_candidate_portfolios_CandidateId");

            migrationBuilder.RenameColumn(
                name: "responsibilities",
                table: "candidate_experiences",
                newName: "Responsibilities");

            migrationBuilder.RenameColumn(
                name: "position",
                table: "candidate_experiences",
                newName: "Position");

            migrationBuilder.RenameColumn(
                name: "achievements",
                table: "candidate_experiences",
                newName: "Achievements");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "candidate_experiences",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "candidate_experiences",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "start_date",
                table: "candidate_experiences",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "is_current",
                table: "candidate_experiences",
                newName: "IsCurrent");

            migrationBuilder.RenameColumn(
                name: "end_date",
                table: "candidate_experiences",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "candidate_experiences",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "company_name",
                table: "candidate_experiences",
                newName: "CompanyName");

            migrationBuilder.RenameColumn(
                name: "candidate_id",
                table: "candidate_experiences",
                newName: "CandidateId");

            migrationBuilder.RenameIndex(
                name: "IX_candidate_experiences_candidate_id",
                table: "candidate_experiences",
                newName: "IX_candidate_experiences_CandidateId");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "candidate_educations",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "candidate_educations",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "candidate_educations",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "start_date",
                table: "candidate_educations",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "is_current",
                table: "candidate_educations",
                newName: "IsCurrent");

            migrationBuilder.RenameColumn(
                name: "institution_name",
                table: "candidate_educations",
                newName: "InstitutionName");

            migrationBuilder.RenameColumn(
                name: "field_of_study",
                table: "candidate_educations",
                newName: "FieldOfStudy");

            migrationBuilder.RenameColumn(
                name: "end_date",
                table: "candidate_educations",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "education_level_id",
                table: "candidate_educations",
                newName: "EducationLevelId");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "candidate_educations",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "candidate_id",
                table: "candidate_educations",
                newName: "CandidateId");

            migrationBuilder.RenameIndex(
                name: "IX_candidate_educations_education_level_id",
                table: "candidate_educations",
                newName: "IX_candidate_educations_EducationLevelId");

            migrationBuilder.RenameIndex(
                name: "IX_candidate_educations_candidate_id",
                table: "candidate_educations",
                newName: "IX_candidate_educations_CandidateId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "admin_settings",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "admin_settings",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "setting_value",
                table: "admin_settings",
                newName: "SettingValue");

            migrationBuilder.RenameColumn(
                name: "setting_name",
                table: "admin_settings",
                newName: "SettingName");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "admin_settings",
                newName: "CreatedAt");
        }
    }
}
