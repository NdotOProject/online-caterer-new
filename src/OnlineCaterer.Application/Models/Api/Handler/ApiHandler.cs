using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Exceptions;
using OnlineCaterer.Application.Models.Api.Error;
using OnlineCaterer.Application.Models.Api.Request;
using OnlineCaterer.Application.Models.Api.Response;
using OnlineCaterer.Application.Models.Identity.Helper;
using OnlineCaterer.Domain.Identity;
using System.Net;

namespace OnlineCaterer.Application.Models.Api.Handler
{
    public abstract class ApiHandler<TRequest, TResponse>
		where TRequest : class, IApiRequest
		where TResponse : VoidResponse
	{
		protected IPermissionProvider PermissonProvider { get; }
		protected IUserService UserService { get; }

		private ErrorList Errors { get; }
		private User? User { get; set; }

		public ApiHandler(
			IPermissionProvider permissonProvider, IUserService userService)
		{
			PermissonProvider = permissonProvider;
			UserService = userService;

			Errors = new();
		}

		// must implememt
		protected abstract Func<TResponse> ResponseProvider { get; }

		protected abstract Task Resolve(TRequest request, TResponse response);

		// optional implement
		protected virtual Task Reject(TRequest request, TResponse response)
		{
			return Task.CompletedTask;
		}

		protected virtual Task Validate(
			TRequest request, ErrorList errorList)
		{
			return Task.CompletedTask;
		}

		protected virtual Task<Permission> GetPermission(
			IPermissionProvider provider)
		{
			return Task.FromResult(Permission.Optional);
		}

		protected virtual async Task CheckPermission(
			IPermissionProvider provider, IUserService userService,
			ErrorList errorList)
		{
			Permission permission = await GetPermission(provider);
			if (permission != Permission.Optional)
			{
				try
				{
					if (!await UserService.UserHasPermission(permission))
					{
						errorList.Add(HttpStatusCode.Forbidden,
							"You do not have permission to perform this feature."
						);
					}
				}
				catch (UnauthorizedException)
				{
					errorList.Add(HttpStatusCode.Unauthorized,
						"You must be logged in to use this feature."
					);
				}
			}
		}

		// do not override or hide methods, only use.
		protected async Task<User> GetUser()
		{
			User ??= await UserService.GetCurrentUser();
			return User;
		}

		public async Task<TResponse> GetResponse(TRequest request)
		{
			await CheckPermission(PermissonProvider, UserService, Errors);

			await Validate(request, Errors);

			TResponse response = ResponseProvider.Invoke();

			response.AddErrors(Errors.GetReader().GetErrors());

			if (response.Success)
			{
				await Resolve(request, response);
			}
			else
			{
				await Reject(request, response);
			}

			return response;
		}
	}
}
