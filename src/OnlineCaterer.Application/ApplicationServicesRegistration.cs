using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace OnlineCaterer.Application
{
	public static class ApplicationServicesRegistration
	{
		public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
		{
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			services.AddMediatR(Assembly.GetExecutingAssembly());

			return services;
		}
	}
}
