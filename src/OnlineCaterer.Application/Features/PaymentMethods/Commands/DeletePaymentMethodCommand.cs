using MediatR;
using OnlineCaterer.Application.Models.Api.Request;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.PaymentMethods.Commands
{
	public class DeletePaymentMethodCommand
		: IApiRequest,
		IRequest<VoidResponse>
	{
		public int Id { get; set; }
	}
}
