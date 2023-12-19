using FluentValidation;
using FluentValidation.Results;
using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Models;
using OnlineCaterer.Application.Models.Identity;
using OnlineCaterer.Domain.Identity;
using System.Net;

namespace OnlineCaterer.Application.Features
{
    public abstract class CommandHandler<TRequest, TRepsonse>
		where TRequest : class
		where TRepsonse : class
	{
		public CommandResponse<TRepsonse> Response { get; }
		protected User User { get; }

		private readonly Permission _permission;
		private readonly IUserService _userService;

		public CommandHandler(IUserService userService, Permission permission)
		{
			Response = new CommandResponse<TRepsonse>();

			_permission = permission;

			_userService = userService;
			User = _userService.GetCurrentUser().Result;
		}

		protected abstract Task<(string Message, TRepsonse? Data, List<object>? Includes)> Resolve(TRequest request);
		protected abstract string Reject();

//		protected virtual async Task Validate() { }

		public async Task Execute(
			TRequest request,
			AbstractValidator<TRequest> validator,
			CancellationToken cancellationToken = new())
		{
			ValidationResult result = await validator.ValidateAsync(request, cancellationToken);

			bool userHasPermisson = await _userService.UserHasPermission(_permission);
			if (userHasPermisson == false)
			{
				result.Errors.Add(
					new ValidationFailure
					{
						ErrorMessage = "Ban khong co quyen thuc hien chuc nang nay.",
						ErrorCode = HttpStatusCode.Forbidden.ToString(),
					}
				);
			}

//			await Validate(request, result.Errors);

			if (result.IsValid)
			{
				Response.Success = true;
				var (Message, Data, Includes) = await Resolve(request);
				Response.Data = Data;
				Response.Message = Message;
				Response.Includes = Includes;
			}
			else
			{
				Response.Success = false;
				var message = Reject();
				Response.Message = message;
				Response.Errors = result?.Errors.Select(e => e.ErrorMessage).ToList();
			}
		}
	}
}
