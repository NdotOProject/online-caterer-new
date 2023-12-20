using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Exceptions;
using OnlineCaterer.Application.Models.Api.Error;
using OnlineCaterer.Application.Models.Api.Response;
using OnlineCaterer.Application.Models.Identity;
using OnlineCaterer.Domain.Identity;
using System.Net;

namespace OnlineCaterer.Application.Models.Api.Request
{
	public abstract class RequestHandler<TRequest, TResponse>
		where TRequest : class
		where TResponse : VoidResponse
	{
		protected IPermissionProvider PermissonProvider { get; }
		protected IUserService UserService { get; }

		public RequestHandler(
			IPermissionProvider permissonProvider,
			IUserService userService)
		{
			PermissonProvider = permissonProvider;
			UserService = userService;
		}

		// must implememt properties
		protected abstract Func<TResponse> Response { get; }

		// must implement methods
		protected abstract Task Resolve(TRequest request, TResponse response);

		protected abstract Task Reject(TResponse response);

		// optional implement methods
		protected virtual Task Validate(TRequest request, ErrorList errorList)
			=> Task.CompletedTask;

		protected virtual Task<Permission?> GetRequiredPermission(
			IPermissionProvider permissonProvider)
			=> Task.FromResult<Permission?>(null);

		protected virtual async Task CheckPermission(
			IPermissionProvider permissionProvider, IUserService userService,
			ErrorList errorList)
		{
			Permission? permission = await GetRequiredPermission(PermissonProvider);
			if (permission != null)
			{
				try
				{
					if ((await UserService.UserHasPermission(permission)) == false)
					{
						errorList.Add(HttpStatusCode.Unauthorized,
							"You do not have permission to perform this feature."
						);
					}
				}
				catch (NotFoundException)
				{
					errorList.Add(HttpStatusCode.NotAcceptable,
						"You must be logged in to use this feature."
					);
				}
			}
		}

		// do not override or hide methods, only use.
		private User? _user;
		protected async Task<User> GetUser()
		{
			_user ??= await UserService.GetCurrentUser();
			return _user;
		}

		public async Task<TResponse> GetResponse(TRequest request)
		{
			// init
			ErrorList errorList = new();

			// Validate Request
			await Validate(request, errorList);

			// CheckPermission
			await CheckPermission(PermissonProvider, UserService, errorList);

			// Create Response
			TResponse response = Response.Invoke();

			// Pass errors to response
			response.AddErrors(errorList.GetReader().GetErrors());

			// check
			if (response.Success)
			{
				// handle success
				await Resolve(request, response);
			}
			else
			{
				// handle failure
				await Reject(response);
			}

			return response;
		}
	}
}
