using AutoMapper;
using OnlineCaterer.Application.DTOs.PaymentMethod;

namespace OnlineCaterer.Application.DTOs.Mappers
{
    public class PaymentMethodMapper : Profile
	{
		public PaymentMethodMapper()
		{
			CreateMap<Domain.Core.PaymentMethod, PaymentMethodDTO>()
				.ReverseMap();

			CreateMap<CreatePaymentMethodDTO, Domain.Core.PaymentMethod>();
		}
	}
}
