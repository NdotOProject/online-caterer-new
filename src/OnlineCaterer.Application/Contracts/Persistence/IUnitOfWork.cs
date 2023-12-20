using OnlineCaterer.Application.Contracts.Repositories.Core;
using OnlineCaterer.Application.Contracts.Repositories.Identity;
using OnlineCaterer.Domain.Identity;

namespace OnlineCaterer.Application.Contracts.Persistence
{
	public interface IUnitOfWork : IDisposable
	{
		// core
		ICustomerRepository CustomerRepository { get; }
		IEmployeeRepository EmployeeRepository { get; }
		IEventRepository EventRepository { get; }
		IFeedbackRepository FeedbackRepository { get; }
		IFoodCategoryRepository FoodCategoryRepository { get; }
		IFoodImageRepository FoodImageRepository { get; }
		IFoodRepository FoodRepository { get; }
		IOrderDetailRepository OrderDetailRepository { get; }
		IOrderRepository OrderRepository { get; }
		IPaymentMethodRepository PaymentMethodRepository { get; }
		ISupplierRepository SupplierRepository { get; }

		// identity
		IActionRepository ActionRepository { get; }
		IGroupRepository GroupRepository { get; }
		IObjectRepository ObjectRepository { get; }
		IUserRepository UserRepository { get; }
		IUserTypeRepository UserTypeRepository { get; }

		Task SaveChanges(User byUser);
	}
}
