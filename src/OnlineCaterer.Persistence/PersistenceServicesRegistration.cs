using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Contracts.Persistence;
using OnlineCaterer.Application.Contracts.Repositories.Core;
using OnlineCaterer.Application.Contracts.Repositories.Generic;
using OnlineCaterer.Application.Contracts.Repositories.Identity;
using OnlineCaterer.Persistence.Configurations;
using OnlineCaterer.Persistence.Identity.Services;
using OnlineCaterer.Persistence.Repositories.Core;
using OnlineCaterer.Persistence.Repositories.Generic;
using OnlineCaterer.Persistence.Repositories.Identity;

namespace OnlineCaterer.Persistence
{
    public static class PersistenceServicesRegistration
	{
		public static IServiceCollection RegisterPersistenceServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<OnlineCatererDbContext>(
				options => options.UseSqlServer(ConnectionStrings.Default)
			);

			// Contracts.Identity.Services
			services.AddScoped<IAuthService, AuthService>();
			services.AddScoped<IPermissionProvider, PermissonProvider>();
			services.AddScoped<IUserService, UserService>();

			// Contracts.Persistence
			services.AddScoped<IUnitOfWork, UnitOfWork>();

			// Contracts.Repositories.Core
			services.AddScoped<ICustomerRepository, CustomerRepository>();
			services.AddScoped<IEmployeeRepository, EmployeeRepository>();
			services.AddScoped<IEventRepository, EventRepository>();
			services.AddScoped<IFeedbackRepository, FeedbackRepository>();
			services.AddScoped<IFoodCategoryRepository, FoodCategoryRepository>();
			services.AddScoped<IFoodImageRepository, FoodImageRepository>();
			services.AddScoped<IFoodRepository, FoodRepository>();
			services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
			services.AddScoped<IOrderRepository, OrderRepository>();
			services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
			services.AddScoped<ISupplierRepository, SupplierRepository>();

			// Contracts.Repositories.Generic
			services.AddScoped(typeof(ICreatableRepository<>), typeof(CreatableRepository<>));
			services.AddScoped(typeof(IDeletableRepository<>), typeof(DeletableRepository<>));
			services.AddScoped(typeof(IFullActionRepository<,>), typeof(FullActionRepository<,>));
			services.AddScoped(typeof(IReadOnlyRepository<,>), typeof(ReadOnlyRepository<,>));
			services.AddScoped(typeof(IUpdatableRepository<>), typeof(UpdatableRepository<>));

			// Contracts.Repositories.Identity
			services.AddScoped<IActionRepository, ActionRepository>();
			services.AddScoped<IGroupRepository, GroupRepository>();
			services.AddScoped<IObjectRepository, ObjectRepository>();
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IUserTypeRepository, UserTypeRepository>();

			return services;
		}
	}
}
