using MediatR;
using OnlineCaterer.Application.DTOs.Supplier;
using OnlineCaterer.Application.Models.Api.Request;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.Supplier.Queries
{
	public class GetListSupplierQuery
		: IApiRequest,
		IRequest<ListResponse<SupplierDTO>>
	{
	}
}
