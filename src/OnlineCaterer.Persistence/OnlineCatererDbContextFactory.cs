using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OnlineCaterer.Persistence.Configurations;

namespace OnlineCaterer.Persistence
{
    public class OnlineCatererDbContextFactory : IDesignTimeDbContextFactory<OnlineCatererDbContext>
	{
		public OnlineCatererDbContext CreateDbContext(string[] args)
		{
			var optionBuilder = new DbContextOptionsBuilder<OnlineCatererDbContext>();
			optionBuilder.UseSqlServer(ConnectionStrings.Default);
			return new OnlineCatererDbContext(optionBuilder.Options);
		}
	}
}
