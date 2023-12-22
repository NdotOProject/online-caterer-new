using OnlineCaterer.Application.Models.Identity.Conventions;
using OnlineCaterer.Application.Models.Identity.Helper;

namespace OnlineCaterer.Application.Contracts.Identity.Services
{
    public interface IPermissionProvider
	{
		Task<Permission> GetPermission(Objects obj, Actions act);

		Task<Permission> GetEmployeePermission(Actions act);
		Task<Permission> GetCustomerPermission(Actions act);
		Task<Permission> GetSupplierPermission(Actions act);
		Task<Permission> GetFoodPermission(Actions act);
		Task<Permission> GetFoodCategoryPermission(Actions act);
		Task<Permission> GetFoodImagePermission(Actions act);
		Task<Permission> GetOrderPermission(Actions act);
		Task<Permission> GetOrderDetailPermission(Actions act);
		Task<Permission> GetEventPermission(Actions act);
		Task<Permission> GetFeedbackPermission(Actions act);
		Task<Permission> GetPaymentMethodPermission(Actions act);

		Task<Permission> GetGroupPermission(Actions act);
	}
}
