using FluentValidation;

public class CreateJobCommandValidator : AbstractValidator<CreateJobCommand>
{
	public CreateJobCommandValidator()
	{
		RuleFor(x => x.JobCategoryId).NotEmpty();
		RuleFor(x => x.JobTypeId).NotEmpty();
		RuleFor(x => x.ExperienceLevelId).NotEmpty();
		RuleFor(x => x.MinEducationId).NotEmpty();

		RuleFor(x => x.Description)
			.NotEmpty()
			.Must(x => !string.IsNullOrWhiteSpace(x))
			.WithMessage("Description cannot be empty or contain only spaces")
			.MinimumLength(30);

		RuleFor(x => x.Responsibilities)
			.NotEmpty()
			.Must(x => !string.IsNullOrWhiteSpace(x))
			.WithMessage("Responsibilities cannot be empty or contain only spaces")
			.MinimumLength(30);

		RuleFor(x => x.Requirements)
			.NotEmpty()
			.Must(x => !string.IsNullOrWhiteSpace(x))
			.WithMessage("Requirements cannot be empty or contain only spaces")
			.MinimumLength(30);

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

		RuleFor(x => x.LocationCity.Trim())
			.NotEmpty()
			.Must(x => !string.IsNullOrWhiteSpace(x));

		RuleFor(x => x.LocationState.Trim())
			.NotEmpty()
			.Must(x => !string.IsNullOrWhiteSpace(x));

		RuleFor(x => x.LocationCountry.Trim())
			.NotEmpty()
			.Must(x => !string.IsNullOrWhiteSpace(x));

		RuleFor(x => x.ApplicationDeadline)
			.GreaterThanOrEqualTo(DateTimeOffset.UtcNow.ToUnixTimeSeconds())
			.WithMessage("Application deadline must be now or in the future.");
	}
}
