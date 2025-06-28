using AutoMapper;
using JobBee.Application.Features.Payment.Command.CreatePayment;
using JobBee.Domain.Entities;

namespace JobBee.Application.MappingProfiles
{
	public class PaymentProfile : Profile
	{
		public PaymentProfile()
		{
			CreateMap<CreatePaymentCommand, Payment>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
				.ForMember(dest => dest.PaymentDate, opt => opt.MapFrom(src => DateTime.Now));
		}
	}
}
