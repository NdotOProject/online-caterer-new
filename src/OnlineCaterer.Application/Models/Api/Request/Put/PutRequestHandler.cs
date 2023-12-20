using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Models.Api.Error;
using OnlineCaterer.Application.Models.Api.Response;
using OnlineCaterer.Application.Models.Identity;

namespace OnlineCaterer.Application.Models.Api.Request.Put
{
	public abstract class PutRequestHandler<TRequest, TBody, TResponse> :
		RequestHandler<TRequest, DataResponse<TResponse>>
		where TRequest : PutRequest<TBody>
		where TBody : class
	{
		public PutRequestHandler(
			IPermissionProvider permissonProvider,
			IUserService userService) : base(permissonProvider, userService)
		{
		}

		protected sealed override Func<DataResponse<TResponse>> Response
			=> () => new DataResponse<TResponse>();

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
