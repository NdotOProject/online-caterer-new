using OnlineCaterer.Application.Contracts.Persistence.Extensions;
using OnlineCaterer.Application.Contracts.Persistence.Identity;

namespace OnlineCaterer.Application.Contracts.Persistence
{
	public interface IUnitOfWork : IDisposable
	{
		// identity
		IActionRepository ActionRepository { get; }
		IGroupRepository GroupRepository { get; }
		IObjectRepository ObjectRepository { get; }
		IUserRepository UserRepository { get; }

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

		Task Commit(int userId);
	}
}
