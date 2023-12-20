using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Models.Api.Request.Get
{
	public abstract class GetRequestHandler<TRequest, TResponse> :
		RequestHandler<TRequest, DataResponse<TResponse>>
		where TRequest : GetRequest<TResponse>
		where TResponse : class
	{
		public GetRequestHandler(
			IPermissionProvider permissonProvider,
			IUserService userService) : base(permissonProvider, userService)
		{
		}

		protected sealed override Func<DataResponse<TResponse>> Response
			=> () => new DataResponse<TResponse>();
	}
}
