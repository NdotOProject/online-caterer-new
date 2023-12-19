using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Contracts.Persistence;
using OnlineCaterer.Application.Exceptions;
using OnlineCaterer.Application.Models.Identity;

namespace OnlineCaterer.Persistence.Identity.Services
{
	public class PermissonProvider : IPermissionProvider
	{
		private readonly IUnitOfWork _unitOfWork;

		public PermissonProvider(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<Permission> GetCustomerPermission(Actions act)
		{
			return act switch
			{
				Actions.Create => await Permission.Find(_unitOfWork, 1, 1),
				Actions.Read => await Permission.Find(_unitOfWork, 1, 2),
				Actions.Update => await Permission.Find(_unitOfWork, 1, 3),
				Actions.Delete => await Permission.Find(_unitOfWork, 1, 4),
				_ => throw new NotSupportedException(),
			};
		}

		public async Task<Permission> GetEmployeePermission(Actions act)
		{
			return act switch
			{
				Actions.Create => await Permission.Find(_unitOfWork, 2, 1),
				Actions.Read => await Permission.Find(_unitOfWork, 2, 2),
				Actions.Update => await Permission.Find(_unitOfWork, 2, 3),
				Actions.Delete => await Permission.Find(_unitOfWork, 2, 4),
				_ => throw new NotSupportedException(),
			};
		}

		public async Task<Permission> GetEventPermission(Actions act)
		{
			return act switch
			{
				Actions.Create => await Permission.Find(_unitOfWork, 11, 1),
				Actions.Read => await Permission.Find(_unitOfWork, 11, 2),
				Actions.Update => await Permission.Find(_unitOfWork, 11, 3),
				Actions.Delete => await Permission.Find(_unitOfWork, 11, 4),
				_ => throw new NotSupportedException(),
			};
		}

		public async Task<Permission> GetFeedbackPermission(Actions act)
		{
			return act switch
			{
				Actions.Create => await Permission.Find(_unitOfWork, 9, 1),
				Actions.Read => await Permission.Find(_unitOfWork, 9, 2),
				Actions.Update => await Permission.Find(_unitOfWork, 9, 3),
				Actions.Delete => await Permission.Find(_unitOfWork, 9, 4),
				_ => throw new NotSupportedException(),
			};
		}

		public async Task<Permission> GetFoodCategoryPermission(Actions act)
		{
			return act switch
			{
				Actions.Create => await Permission.Find(_unitOfWork, 5, 1),
				Actions.Read => await Permission.Find(_unitOfWork, 5, 2),
				Actions.Update => await Permission.Find(_unitOfWork, 5, 3),
				Actions.Delete => await Permission.Find(_unitOfWork, 5, 4),
				_ => throw new NotSupportedException(),
			};
		}

		public async Task<Permission> GetFoodImagePermission(Actions act)
		{
			return act switch
			{
				Actions.Create => await Permission.Find(_unitOfWork, 6, 1),
				Actions.Read => await Permission.Find(_unitOfWork, 6, 2),
				Actions.Update => await Permission.Find(_unitOfWork, 6, 3),
				Actions.Delete => await Permission.Find(_unitOfWork, 6, 4),
				_ => throw new NotSupportedException(),
			};
		}

		public async Task<Permission> GetFoodPermission(Actions act)
		{
			return act switch
			{
				Actions.Create => await Permission.Find(_unitOfWork, 4, 1),
				Actions.Read => await Permission.Find(_unitOfWork, 4, 2),
				Actions.Update => await Permission.Find(_unitOfWork, 4, 3),
				Actions.Delete => await Permission.Find(_unitOfWork, 4, 4),
				_ => throw new NotSupportedException(),
			};
		}

		public async Task<Permission> GetGroupPermission(Actions act)
		{
			return act switch
			{
				Actions.Create => await Permission.Find(_unitOfWork, 13, 1),
				Actions.Read => await Permission.Find(_unitOfWork, 13, 2),
				Actions.Update => await Permission.Find(_unitOfWork, 13, 3),
				Actions.Delete => await Permission.Find(_unitOfWork, 13, 4),
				_ => throw new NotSupportedException(),
			};
		}

		public async Task<Permission> GetOrderDetailPermission(Actions act)
		{
			return act switch
			{
				Actions.Create => await Permission.Find(_unitOfWork, 8, 1),
				Actions.Read => await Permission.Find(_unitOfWork, 8, 2),
				Actions.Update => await Permission.Find(_unitOfWork, 8, 3),
				Actions.Delete => await Permission.Find(_unitOfWork, 8, 4),
				_ => throw new NotSupportedException(),
			};
		}

		public async Task<Permission> GetOrderPermission(Actions act)
		{
			return act switch
			{
				Actions.Create => await Permission.Find(_unitOfWork, 7, 1),
				Actions.Read => await Permission.Find(_unitOfWork, 7, 2),
				Actions.Update => await Permission.Find(_unitOfWork, 7, 3),
				Actions.Delete => await Permission.Find(_unitOfWork, 7, 4),
				_ => throw new NotSupportedException(),
			};
		}

		public async Task<Permission> GetPaymentMethodPermission(Actions act)
		{
			return act switch
			{
				Actions.Create => await Permission.Find(_unitOfWork, 10, 1),
				Actions.Read => await Permission.Find(_unitOfWork, 10, 2),
				Actions.Update => await Permission.Find(_unitOfWork, 10, 3),
				Actions.Delete => await Permission.Find(_unitOfWork, 10, 4),
				_ => throw new NotSupportedException(),
			};
		}

		public async Task<Permission> GetPermission(Objects obj, Actions act)
		{
			return obj switch
			{
				Objects.Customer => await GetCustomerPermission(act),
				Objects.Employee => await GetEmployeePermission(act),
				Objects.Event => await GetEventPermission(act),
				Objects.Feedback => await GetFeedbackPermission(act),
				Objects.Food => await GetFoodPermission(act),
				Objects.FoodCategory => await GetFoodCategoryPermission(act),
				Objects.FoodImage => await GetFoodImagePermission(act),
				Objects.Group => await GetGroupPermission(act),
				Objects.Order => await GetOrderPermission(act),
				Objects.OrderDetail => await GetOrderDetailPermission(act),
				Objects.PaymentMethod => await GetPaymentMethodPermission(act),
				Objects.Supplier => await GetSupplierPermission(act),
				_ => throw new NotSupportedException(),
			};
		}

		public async Task<Permission> GetSupplierPermission(Actions act)
		{
			return act switch
			{
				Actions.Create => await Permission.Find(_unitOfWork, 3, 1),
				Actions.Read => await Permission.Find(_unitOfWork, 3, 2),
				Actions.Update => await Permission.Find(_unitOfWork, 3, 3),
				Actions.Delete => await Permission.Find(_unitOfWork, 3, 4),
				_ => throw new NotSupportedException(),
			};
		}
	}
}
