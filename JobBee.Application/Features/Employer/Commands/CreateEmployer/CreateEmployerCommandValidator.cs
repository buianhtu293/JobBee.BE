using FluentValidation;

namespace JobBee.Application.Features.Employer.Commands.CreateEmployer
{
	public class CreateEmployerCommandValidator : AbstractValidator<CreateEmployerCommand>
	{
		public CreateEmployerCommandValidator()
		{
			RuleFor(x => x.CompnanyName)
				.NotEmpty().WithMessage("Company name is required.")
				.MaximumLength(100).WithMessage("Company name must not exceed 100 characters.");

			RuleFor(x => x.AboutUs)
				.NotEmpty().WithMessage("About Us section is required.");

			RuleFor(x => x.IndustryType)
				.NotEmpty().WithMessage("Industry type must be selected.");

			RuleFor(x => x.TeamSize)
				.NotEmpty().WithMessage("Company size must be selected.");

			RuleFor(x => x.FoundedYear)
				.InclusiveBetween(1800, DateTime.Now.Year)
				.WithMessage($"Founded year must be between 1800 and {DateTime.Now.Year}.");

			RuleFor(x => x.WebsiteUrl)
				.NotEmpty().WithMessage("Website URL is required.")
				.Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute))
				.WithMessage("Website URL is invalid.");

			RuleFor(x => x.ContactPerson)
				.NotEmpty().WithMessage("Contact person name is required.");

			RuleFor(x => x.ContactEmail)
				.NotEmpty().WithMessage("Contact email is required.")
				.EmailAddress().WithMessage("Invalid email address format.");

			RuleFor(x => x.ContactPhone)
				.NotEmpty().WithMessage("Contact phone number is required.")
				.Matches(@"^(0|\+84)(3[2-9]|5[6|8|9]|7[0|6-9]|8[1-5]|9[0-9])[0-9]{7}$").WithMessage("Invalid phone number format.");

			RuleFor(x => x.Address)
				.NotEmpty().WithMessage("Address is required.");

			RuleFor(x => x.City)
				.NotEmpty().WithMessage("City is required.");

			RuleFor(x => x.District)
				.NotEmpty().WithMessage("District is required.");

			RuleFor(x => x.Commune)
				.NotEmpty().WithMessage("Commune is required.");

			RuleFor(x => x.Logo)
			.NotNull().WithMessage("Company logo is required.")
			.Must(file => file.Length <= 10 * 1024 * 1024)
				.WithMessage("Logo must be smaller than 10MB.")
			.Must(file =>
				file.ContentType == "image/jpeg" ||
				file.ContentType == "image/png" ||
				file.ContentType == "image/jpg" ||
				file.ContentType == "image/gif" ||
				file.ContentType == "image/webp")
				.WithMessage("Logo must be a valid image file (jpg, png, gif, webp).");

			RuleFor(x => x.Banner)
			.NotNull().WithMessage("Company banner is required.")
			.Must(file => file.Length <= 10 * 1024 * 1024)
				.WithMessage("Banner must be smaller than 10MB.")
			.Must(file =>
				file.ContentType == "image/jpeg" ||
				file.ContentType == "image/png" ||
				file.ContentType == "image/jpg" ||
				file.ContentType == "image/gif" ||
				file.ContentType == "image/webp")
				.WithMessage("Banner must be a valid image file (jpg, png, gif, webp).");
		}

	}
}
