using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Models.Api.Request;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Models.Api.Handler
{
	public abstract class GetHandler<TRequest, TResponse>
		: ApiHandler<TRequest, DataResponse<TResponse>>
		where TRequest : class, IApiRequest
		where TResponse : class
	{
		public GetHandler(
			IPermissionProvider permissonProvider,
			IUserService userService)
			: base(permissonProvider, userService)
		{
		}

		protected sealed override Func<DataResponse<TResponse>> ResponseProvider
			=> () => new DataResponse<TResponse>();
	}
}
