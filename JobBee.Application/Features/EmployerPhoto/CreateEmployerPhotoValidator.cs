using FluentValidation;

namespace JobBee.Application.Features.EmployerPhoto
{
	public class CreateEmployerPhotoValidator : AbstractValidator<CreateEmployerPhotoCommand>
	{
		public CreateEmployerPhotoValidator()
		{
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
