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
						Description = @"Is a classic payment method in which
							the sender directly gives money to the recipient.",
					},
					new PaymentMethod
					{
						Id = 2,
						Name = "Agribank",
						Description = @"Is an online payment method
							through the Agribank service.",
					},
					new PaymentMethod
					{
						Id = 3,
						Name = "MB Bank",
						Description = @"Is an online payment method
							through the MB Bank service.",
					},
					new PaymentMethod
					{
						Id = 4,
						Name = "VietcomBank",
						Description = @"Is an online payment method
							through the VietcomBank service.",
					},
				}
			);
		}
	}
}
