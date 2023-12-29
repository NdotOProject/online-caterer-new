using Microsoft.AspNetCore.Http;
using OnlineCaterer.Application.Constants;
using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Contracts.Persistence;
using OnlineCaterer.Application.Exceptions;
using OnlineCaterer.Application.Models.Identity.Conventions;
using OnlineCaterer.Application.Models.Identity.Helper;
using OnlineCaterer.Domain.Identity;

namespace OnlineCaterer.Persistence.Identity.Services
{
	public class UserService : IUserService
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IUnitOfWork _unitOfWork;

		public UserService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
		{
			_unitOfWork = unitOfWork;
			_httpContextAccessor = httpContextAccessor;
		}

		private int GetUserId()
		{
			return Convert.ToInt32(
				_httpContextAccessor.HttpContext.Request.Cookies[CustomClaimTypes.Uid]
			//_httpContextAccessor.HttpContext.User.FindFirst(CustomClaimTypes.Uid)?.Value
			);
		}

		public async Task<User> GetCurrentUser()
		{
			return await _unitOfWork.UserRepository.Get(GetUserId());
		}

		public async Task<UserTypes> GetTypeOfCurrentUser()
		{
			User user = await GetCurrentUser();
			return user.UserTypeId switch
			{
				1 => UserTypes.Employee,
				2 => UserTypes.Customer,
				3 => UserTypes.Supplier,
				_ => throw new NotSupportedException()
			};
		}

		public int GetUserTypeId(UserTypes userType)
		{
			return userType switch
			{
				UserTypes.Employee => 1,
				UserTypes.Customer => 2,
				UserTypes.Supplier => 3,
				_ => throw new NotSupportedException(),
			};
		}

		public async Task<bool> UserHasPermission(Permission permission)
		{
			try
			{
				var permissions = await _unitOfWork.UserRepository
					.GetPermissions(GetUserId());

				return permissions.Where(p =>
					p.Object == permission.Object
					&& p.Action == permission.Action
				).Any();
			}
			catch
			{
				throw new UnauthorizedException();
			}
		}
	}
}
