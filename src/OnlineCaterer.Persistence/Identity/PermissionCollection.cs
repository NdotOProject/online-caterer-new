using OnlineCaterer.Application.Contracts.Identity;
using OnlineCaterer.Application.Models.Identity;

namespace OnlineCaterer.Persistence.Identity
{
	public class PermissionCollection : IPermissionCollection
	{
		public Permission ReadEmployeeInfoPermission => throw new NotImplementedException();

		public Permission CreateEmployeePermission => throw new NotImplementedException();

		public Permission UpdateEmployeeInfoPermission => throw new NotImplementedException();

		public Permission DeleteEmployeeInfoPermission => throw new NotImplementedException();

		public Permission CreateFoodPermission => throw new NotImplementedException();

		public Permission ReadFoodInfoPermission => throw new NotImplementedException();

		public Permission UpdateFoodPermission => throw new NotImplementedException();

		public Permission DeleteFoodPermission => throw new NotImplementedException();
	}
}
