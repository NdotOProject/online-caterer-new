using MediatR;
using OnlineCaterer.Application.DTOs.PaymentMethod;
using OnlineCaterer.Application.Models.Api.Request;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.PaymentMethods.Commands
{
	public class CreatePaymentMethodCommand
		: IApiBodyRequest<CreatePaymentMethodDTO>,
		IRequest<VoidResponse>
	{
		public CreatePaymentMethodDTO Body { get; set; } = null!;
	}
}
