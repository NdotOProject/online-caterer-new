using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Models.Api.Request;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Models.Api.Handler
{
	public abstract class PostHandler<TRequest, TBody>
		: ApiHandler<TRequest, VoidResponse>
		where TRequest : class, IApiBodyRequest<TBody>
		where TBody : class, IRequestBody
	{
		public PostHandler(
			IPermissionProvider permissonProvider,
			IUserService userService)
			: base(permissonProvider, userService)
		{
		}

		protected sealed override Func<VoidResponse> ResponseProvider
			=> () => new VoidResponse();
	}
}
