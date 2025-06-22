using FluentValidation;

public class CreateJobCommandValidator : AbstractValidator<CreateJobCommand>
{
	public CreateJobCommandValidator()
	{
		RuleFor(x => x.EmployerId).NotEmpty();
		RuleFor(x => x.Title)
			.NotEmpty()
			.MaximumLength(100);

		RuleFor(x => x.JobCategoryId).NotEmpty();
		RuleFor(x => x.JobTypeId).NotEmpty();
		RuleFor(x => x.ExperienceLevelId).NotEmpty();
		RuleFor(x => x.MinEducationId).NotEmpty();

		RuleFor(x => x.Description)
			.NotEmpty()
			.MinimumLength(30);

		RuleFor(x => x.Responsibilities)
			.NotEmpty()
			.MinimumLength(10);

		RuleFor(x => x.Requirements)
			.NotEmpty()
			.MinimumLength(10);

		RuleFor(x => x.MinSalary)
			.GreaterThanOrEqualTo(0);

		RuleFor(x => x.MaxSalary)
			.GreaterThanOrEqualTo(x => x.MinSalary);

		RuleFor(x => x.SalaryPeriod)
			.NotEmpty()
			.Must(x => x == "Monthly" || x == "Yearly" || x == "Hourly" || x == "Tháng" || x == "Năm" || x == "Giờ")
			.WithMessage("SalaryPeriod must be Monthly, Yearly, or Hourly.");

		RuleFor(x => x.Currency)
			.NotEmpty()
			.Length(2, 5);

		RuleFor(x => x.LocationCity)
			.NotEmpty();

		RuleFor(x => x.LocationState)
			.NotEmpty();

		RuleFor(x => x.LocationCountry)
			.NotEmpty();

		RuleFor(x => x.ApplicationDeadline)
			.GreaterThanOrEqualTo(0)
			.WithMessage("ApplicationDeadline must be today or a future date.");
	}
}
