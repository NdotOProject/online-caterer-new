using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Domain.Core;

namespace OnlineCaterer.Persistence.Initializations.Data
{
	public static class PaymentMethodDataInitializer
	{
		public static void Initialize(
			this EntityTypeBuilder<PaymentMethod> entity)
		{
			entity.HasData(
				new[]
				{
					new PaymentMethod
					{
						Id = 1,
						Name = "Cash",
						Description = "",
					},
					new PaymentMethod
					{
						Id = 2,
						Name = "Agribank",
						Description = "",
					},
					new PaymentMethod
					{
						Id = 3,
						Name = "MB Bank",
						Description = "",
					},
					new PaymentMethod
					{
						Id = 4,
						Name = "VietcomBank",
						Description = "",
					},
				}
			);
		}
	}
}
