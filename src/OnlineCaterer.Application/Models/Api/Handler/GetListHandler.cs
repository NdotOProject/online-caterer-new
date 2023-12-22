using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Models.Api.Request;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Models.Api.Handler
{
	public abstract class GetListHandler<TRequest, TResponse>
		: ApiHandler<TRequest, ListResponse<TResponse>>
		where TRequest : class, IApiRequest
		where TResponse : class
	{
		public GetListHandler(
			IPermissionProvider permissonProvider,
			IUserService userService)
			: base(permissonProvider, userService)
		{
		}

		protected sealed override Func<ListResponse<TResponse>> ResponseProvider
			=> () => new ListResponse<TResponse>();
	}
}
