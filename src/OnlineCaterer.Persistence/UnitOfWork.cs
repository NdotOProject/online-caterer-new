using OnlineCaterer.Application.Contracts.Persistence;
using OnlineCaterer.Application.Contracts.Repositories.Core;
using OnlineCaterer.Application.Contracts.Repositories.Identity;
using OnlineCaterer.Domain.Core;
using OnlineCaterer.Domain.Identity;
using OnlineCaterer.Persistence.Repositories.Core;
using OnlineCaterer.Persistence.Repositories.Generic;
using OnlineCaterer.Persistence.Repositories.Identity;

namespace OnlineCaterer.Persistence
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly OnlineCatererDbContext _dbContext;

		public UnitOfWork(OnlineCatererDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		// core
		public ICustomerRepository CustomerRepository => new CustomerRepository(_dbContext);

		public IEmployeeRepository EmployeeRepository => new EmployeeRepository(_dbContext);

		public IEventRepository EventRepository => new EventRepository(_dbContext);

		public IFeedbackRepository FeedbackRepository => new FeedbackRepository(_dbContext);

		public IFoodCategoryRepository FoodCategoryRepository => new FoodCategoryRepository(_dbContext);

		public IFoodImageRepository FoodImageRepository => new FoodImageRepository(_dbContext);

		public IFoodRepository FoodRepository => new FoodRepository(_dbContext, OrderDetailRepository);

		public IOrderDetailRepository OrderDetailRepository =>
			new OrderDetailRepository(
				_dbContext,
				new CreatableRepository<OrderDetail>(_dbContext),
				new UpdatableRepository<OrderDetail>(_dbContext),
				new DeletableRepository<OrderDetail>(_dbContext)
			);

		public IOrderRepository OrderRepository =>
			new OrderRepository(
				_dbContext,
				new CreatableRepository<Order>(_dbContext)
			);

		public IPaymentMethodRepository PaymentMethodRepository => new PaymentMethodRepository(_dbContext);

		public ISupplierRepository SupplierRepository => new SupplierRepository(_dbContext);

		// identity
		public IActionRepository ActionRepository => new ActionRepository(_dbContext);

		public IGroupRepository GroupRepository => new GroupRepository(_dbContext);

		public IObjectRepository ObjectRepository => new ObjectRepository(_dbContext);

		public IUserRepository UserRepository => new UserRepository(_dbContext, GroupRepository);

		public IUserTypeRepository UserTypeRepository => new UserTypeRepository(_dbContext);

		public async Task SaveChanges(User byUser)
		{
			await _dbContext.SaveChangesAsync(byUser.UserId, byUser.UserTypeId);
		}

		public void Dispose()
		{
			_dbContext.Dispose();
			GC.SuppressFinalize(this);
		}
	}
}
