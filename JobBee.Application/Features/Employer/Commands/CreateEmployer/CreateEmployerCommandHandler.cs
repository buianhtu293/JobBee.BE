using JobBee.Application.CloudService;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Application.Models.Response;
using JobBee.Domain.Entities;
using MediatR;
using Newtonsoft.Json;

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
				Id = Guid.NewGuid(),
				UserId = request.UserId,
				CompanyName = request.CompnanyName,
				CompanyDescription = request.AboutUs,
				IndustryId = request.IndustryType,
				CompanySizeId = request.TeamSize,
				FoundedYear = request.FoundedYear,
				WebsiteUrl = request.WebsiteUrl,
				ContactEmail = request.ContactEmail,
				ContactPersonName = request.ContactPerson,
				ContactPhone = request.ContactPhone,
				HeadquartersCity = request.City,
				HeadquartersAddress = request.Address,
				HeadquartersState = request.District,
				HeadquartersCountry = "Vietnam",
				IsVerified = false,
				CreatedAt = DateTime.Now,
				UpdatedAt= DateTime.Now
			};

			var socialLinks = JsonConvert.DeserializeObject<List<SocialMedial>>(request.SocialLinkJson);

			if (socialLinks != null)
			{
				foreach (var media in socialLinks)
				{
					employer.EmployerSocialMedia.Add(new EmployerSocialMedia()
					{
						Id = Guid.NewGuid(),
						CreatedAt = DateTime.Now,
						PlatformName = media.Platform,
						ProfileUrl = media.Link
					});
				}
			}

			// logo
			var logo = request.Logo;
			var logoStream = logo.OpenReadStream();
			var logoUrl = await cloudService.UploadFile(logo.ContentType, JobBee.Shared.Shared.Directory.Images, logoStream);
			var logoImage = new CompanyPhoto()
			{
				Id = Guid.NewGuid(),
				PhotoUrl = logoUrl,
				Caption = "Company Logo",
				CreatedAt = DateTime.Now,
			};

			// banner
			var banner = request.Banner;
			var bannerStream = banner.OpenReadStream();
			var bannerUrl = await cloudService.UploadFile(banner.ContentType, JobBee.Shared.Shared.Directory.Images, bannerStream);
			var bannerImage = new CompanyPhoto()
			{
				Id = Guid.NewGuid(),
				PhotoUrl = bannerUrl,
				Caption = "Company Banner",
				CreatedAt = DateTime.Now,
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
