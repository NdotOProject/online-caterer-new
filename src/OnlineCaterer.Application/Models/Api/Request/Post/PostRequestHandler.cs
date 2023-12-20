using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Models.Api.Error;
using OnlineCaterer.Application.Models.Api.Response;
using OnlineCaterer.Application.Models.Identity;

namespace OnlineCaterer.Application.Models.Api.Request.Post
{
	public abstract class PostRequestHandler<TRequest, TBody> :
		RequestHandler<TRequest, VoidResponse>
		where TRequest : PostRequest<TBody>
		where TBody : class
	{
		public PostRequestHandler(
			IPermissionProvider permissonProvider,
			IUserService userService) : base(permissonProvider, userService)
		{
		}

		protected sealed override Func<VoidResponse> Response
			=> () => new VoidResponse();

		protected override async Task CheckPermission(
			IPermissionProvider permissionProvider, IUserService userService,
			ErrorList errorList)
		{
			Permission? permission = await GetRequiredPermission(permissionProvider);
			if (permission == null)
			{
				throw new ArgumentNullException($"{nameof(permission)} must not null.", nameof(permission));
			}

			await base.CheckPermission(permissionProvider, userService, errorList);
		}
	}
}
