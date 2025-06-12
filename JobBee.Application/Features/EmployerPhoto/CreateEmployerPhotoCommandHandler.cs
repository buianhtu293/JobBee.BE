using JobBee.Application.CloudService;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Application.Models.Response;
using JobBee.Domain.Entities;
using MediatR;

namespace JobBee.Application.Features.EmployerPhoto
{
	public class CreateEmployerPhotoCommandHandler
	(
		IUnitOfWork<Domain.Entities.CompanyPhoto, Guid> unitOfWork,
		ICloudService cloudService
	): IRequestHandler<CreateEmployerPhotoCommand, ApiResponse<bool>>
	{
		public async Task<ApiResponse<bool>> Handle(CreateEmployerPhotoCommand request, CancellationToken cancellationToken)
		{
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
				EmployerId = request.EmployerId,
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
				EmployerId = request.EmployerId,
			};
			var list = new List<CompanyPhoto>() { logoImage, bannerImage };
			await unitOfWork.GenericRepository.InsertRange(list);
			var cnt = await unitOfWork.SaveChangesAsync();
			if(cnt <= 0)
			{
				throw new BadRequestException(nameof(CompanyPhoto));
			}
			return new ApiResponse<bool>("Sucesss", 200, true);
		}
	}
}
