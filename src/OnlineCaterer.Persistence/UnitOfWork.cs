using Microsoft.AspNetCore.Http;
using OnlineCaterer.Application.Constants;
using OnlineCaterer.Application.Contracts.Persistence;
using OnlineCaterer.Application.Contracts.Persistence.Extensions;
using OnlineCaterer.Application.Contracts.Persistence.Identity;
using OnlineCaterer.Persistence.Core.Repositories;

namespace OnlineCaterer.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OnlineCatererDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UnitOfWork(
            OnlineCatererDbContext dbContext,
            IHttpContextAccessor httpContextAccessor
        )
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionRepository ActionRepository => throw new NotImplementedException();

        public IGroupRepository GroupRepository => throw new NotImplementedException();

        public IObjectRepository ObjectRepository => throw new NotImplementedException();

        public IUserRepository UserRepository => throw new NotImplementedException();

        public ICustomerRepository CustomerRepository => new CustomerRepository(_dbContext);

        public IEmployeeRepository EmployeeRepository => throw new NotImplementedException();

        public IEventRepository EventRepository => throw new NotImplementedException();

        public IFeedbackRepository FeedbackRepository => throw new NotImplementedException();

        public IFoodCategoryRepository FoodCategoryRepository => new FoodCategoryRepository(_dbContext);

        public IFoodImageRepository FoodImageRepository => throw new NotImplementedException();

        public IFoodRepository FoodRepository => new FoodRepository(_dbContext);

        public IOrderDetailRepository OrderDetailRepository => throw new NotImplementedException();

        public IOrderRepository OrderRepository => throw new NotImplementedException();

        public IPaymentMethodRepository PaymentMethodRepository => throw new NotImplementedException();

        public ISupplierRepository SupplierRepository => throw new NotImplementedException();

        public async Task Commit(int userId)
        {
            await _dbContext.SaveChangesAsync(Convert.ToInt32(userId));
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
