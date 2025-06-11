using AutoMapper;
using JobBee.Application.Features.User.Commands.ForgetPassword;
using JobBee.Application.Features.User.Commands.Register;
using JobBee.Application.Features.User.Commands.ResendVerifyAccount;
using JobBee.Application.Features.User.Commands.ResetPassword;
using JobBee.Application.Features.User.Commands.VerifyAccount;
using JobBee.Application.Features.User.Queries.GetAllUser;
using JobBee.Application.Features.User.Queries.GetUserDetail;
using JobBee.Domain.Entities;

namespace JobBee.Application.MappingProfiles
{
	public class UserProfile : Profile
	{
		public UserProfile() 
		{ 
			CreateMap<User, RegisterUserCommand>().ReverseMap();
			CreateMap<User, RegisterUserDto>().ReverseMap();

			CreateMap<User, UserDto>().ReverseMap();

			CreateMap<User, UserDetailDto>().ReverseMap();

			CreateMap<User, VerifyUserDto>().ReverseMap();

			CreateMap<User, ResendVerifyAccountDto>().ReverseMap();

			CreateMap<User, ForgetPasswordDto>().ReverseMap();

			CreateMap<User, ResetPasswordDto>().ReverseMap();
		}
	}
}
