using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using OnlineCaterer.Application.Contracts.Persistence;
using OnlineCaterer.Application.Contracts.Persistence.Extensions;
using OnlineCaterer.Application.Contracts.Persistence.Generic;
using OnlineCaterer.Persistence.Core.Repositories;
using OnlineCaterer.Persistence.Generic;

namespace OnlineCaterer.Persistence
{
    public static class PersistenceServicesRegistration
	{
		public static IServiceCollection RegisterPersistenceServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<OnlineCatererDbContext>();
			services.AddSqlServer<OnlineCatererDbContext>("");

			services.AddScoped(typeof(ICreatableRepository<>), typeof(CreatableRepository<>));
			services.AddScoped(typeof(IDeletableRepository<>), typeof(DeletableRepository<>));
			services.AddScoped(typeof(IFullActionRepository<,>), typeof(FullActionRepository<,>));
			services.AddScoped(typeof(IReadOnlyRepository<,>), typeof(ReadOnlyRepository<,>));
			services.AddScoped(typeof(IUpdatableRepository<>), typeof(UpdatableRepository<>));
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			/*
			services.AddScoped<IBookingDetailRepository, BookingDetailRepository>();
			services.AddScoped<IBookingRepository, BookingRepository>();
			services.AddScoped<ICatererRepository, CatererRepository>();
			*/
			services.AddScoped<ICustomerRepository, CustomerRepository>();
			services.AddScoped<IFoodCategoryRepository, FoodCategoryRepository>();
			services.AddScoped<IFoodRepository, FoodRepository>();

			return services;
		}
	}
}
