using OnlineCaterer.Application.Models.Identity;

namespace OnlineCaterer.Application.Contracts.Identity
{
	public interface IPermissionCollection
	{

		Permission CreateEmployeePermission { get; }
		Permission ReadEmployeeInfoPermission { get; }
		Permission UpdateEmployeeInfoPermission { get; }
		Permission DeleteEmployeeInfoPermission { get; }

		Permission CreateFoodPermission { get; }
		Permission ReadFoodInfoPermission { get; }
		Permission UpdateFoodPermission { get; }
		Permission DeleteFoodPermission { get; }
	}
}
