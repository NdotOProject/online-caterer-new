using MediatR;
using OnlineCaterer.Application.DTOs.PaymentMethod;
using OnlineCaterer.Application.Models.Api.Request;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.PaymentMethods.Queries
{
	public class GetListPaymentMethodQuery
		: IApiRequest,
		IRequest<ListResponse<PaymentMethodDTO>>
	{
	}
}
