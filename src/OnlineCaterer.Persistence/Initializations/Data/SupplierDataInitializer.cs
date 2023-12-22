using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Domain.Core;

namespace OnlineCaterer.Persistence.Initializations.Data
{
	public static class SupplierDataInitializer
	{
		public static void Initialize(this EntityTypeBuilder<Supplier> entity)
		{
			/*entity.HasData(
				new[]
				{
					new Supplier
					{

					},
				}
			);*/
		}
	}
}
