using JobBee.Application.CloudService;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Application.Models.Response;
using JobBee.Domain.Entities;
using JobBee.Shared.Ultils;
using MediatR;

namespace JobBee.Application.Features.Employer.Commands.CreateEmployer
{
	public class CreateEmployerCommandHandler(
			IUnitOfWork<Domain.Entities.Employer, Guid> unitOfWork,
			ICloudService cloudService
		)
		: IRequestHandler<CreateEmployerCommand, ApiResponse<bool>>
	{
		public async Task<ApiResponse<bool>> Handle(CreateEmployerCommand request, CancellationToken cancellationToken)
		{
			// employer entities
			var employer = new Domain.Entities.Employer()
			{
				CompanyName = request.CompnanyName,
				CompanyDescription = request.AboutUs,
				IndustryId = request.IndustryType,
				CompanySizeId = request.TeamSize,
				FoundedYear = request.FoundedYear,
				WebsiteUrl = request.WebsiteUrl,
			};

			var listSocailMedia = new List<EmployerSocialMedia>();

			var socialMedias = request.SocialLink;
			foreach (var media in socialMedias)
			{
				listSocailMedia.Add(new EmployerSocialMedia()
				{
					CreatedAt = DateTime.UtcNow,
					PlatformName = media.Platform,
					ProfileUrl = media.Link
				});
			}

			employer.EmployerSocialMedia = listSocailMedia;

			// logo
			var logo = request.Logo;
			var logoStream = logo.OpenReadStream();
			var logoUrl = await cloudService.UploadFile(logo.ContentType, JobBee.Shared.Shared.Directory.Images, logoStream);
			var logoImage = new CompanyPhoto()
			{
				PhotoUrl = logoUrl,
				Caption = "Company Logo",
				CreatedAt = DateTime.UtcNow,
			};

			// banner
			var banner = request.Banner;
			var bannerStream = banner.OpenReadStream();
			var bannerUrl = await cloudService.UploadFile(logo.ContentType, JobBee.Shared.Shared.Directory.Images, bannerStream);
			var bannerImage = new CompanyPhoto()
			{
				PhotoUrl = bannerUrl,
				Caption = "Company Banner",
				CreatedAt = DateTime.UtcNow,
			};

			// save logo and banner image
			employer.CompanyLogo = logoUrl;
			employer.CompanyPhotos.Add(logoImage);
			employer.CompanyPhotos.Add(bannerImage);

			unitOfWork.GenericRepository.Insert(employer);

			var rowAffectd = await unitOfWork.SaveChangesAsync();
			if (rowAffectd <= 0)
			{
				// can pass validator
				throw new BadRequestException(nameof(Domain.Entities.Employer));
			}
			return new ApiResponse<bool>("Success", 201, true);
		}
	}
}
