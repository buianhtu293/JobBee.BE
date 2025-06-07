using AutoMapper;
using JobBee.Application.Features.User.Commands.Register;
using JobBee.Domain.Entities;

namespace JobBee.Application.MappingProfiles
{
	public class UserProfile : Profile
	{
		public UserProfile() 
		{ 
			CreateMap<User, RegisterUserCommand>().ReverseMap();
			CreateMap<User, RegisterUserDto>().ReverseMap();
		}
	}
}
