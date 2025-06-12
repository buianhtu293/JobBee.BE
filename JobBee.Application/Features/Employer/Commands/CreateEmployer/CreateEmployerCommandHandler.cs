using JobBee.Application.CloudService;
using JobBee.Application.Contracts.Persistence;
using JobBee.Application.Exceptions;
using JobBee.Application.Models.Response;
using JobBee.Domain.Entities;
using MediatR;

namespace JobBee.Application.Features.Employer.Commands.CreateEmployer
{
	public class CreateEmployerCommandHandler(
			IUnitOfWork<Domain.Entities.Employer, Guid> unitOfWork
		)
		: IRequestHandler<CreateEmployerCommand, ApiResponse<Guid>>
	{
		public async Task<ApiResponse<Guid>> Handle(CreateEmployerCommand request, CancellationToken cancellationToken)
		{
			var employerId = Guid.NewGuid();
			// employer entities
			var employer = new Domain.Entities.Employer()
			{
				Id = employerId,
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


			if (request.SocialMedials != null)
			{
				foreach (var media in request.SocialMedials)
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

			unitOfWork.GenericRepository.Insert(employer);

			var rowAffectd = await unitOfWork.SaveChangesAsync();
			if (rowAffectd <= 0)
			{
				// can pass validator
				throw new BadRequestException(nameof(Domain.Entities.Employer));
			}
			return new ApiResponse<Guid>("Success", 201, employerId);
		}
	}
}
