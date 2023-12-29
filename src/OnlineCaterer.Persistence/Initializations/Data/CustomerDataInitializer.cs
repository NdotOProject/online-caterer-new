using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Domain.Core;

namespace OnlineCaterer.Persistence.Initializations.Data
{
	public static class CustomerDataInitializer
	{
		public static void Initialize(this EntityTypeBuilder<Customer> entity)
		{
			entity.HasData(
				new[]
				{
					new Customer
					{
						Id = 1,
						FirstName = "Anh",
						LastName = "Lê Đức",
						Address = "Hà Nội, Việt Nam",
					},
					new Customer
					{
						Id = 2,
						FirstName = "Nam",
						LastName = "Trần Minh",
						Address = "Hà Nội, Việt Nam",
					},
				}
			);
		}
	}
}
