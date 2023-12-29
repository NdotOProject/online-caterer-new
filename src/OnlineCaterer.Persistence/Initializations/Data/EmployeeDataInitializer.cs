using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineCaterer.Domain.Core;

namespace OnlineCaterer.Persistence.Initializations.Data
{
	public static class EmployeeDataInitializer
	{
		public static void Initialize(this EntityTypeBuilder<Employee> entity)
		{
			entity.HasData(
				new[]
				{
					new Employee
					{
						Id = 1,
						FirstName = "Anh",
						LastName = "Vũ Tuấn",
						Address = "Hà Nội, Việt Nam",
						RatingPoint = 0,
						Status = false,
					},
					new Employee
					{
						Id = 2,
						FirstName = "Thắng",
						LastName = "Lê Thành",
						Address = "Hà Nội, Việt Nam",
						RatingPoint = 0,
						Status = false,
					},
				}
			);
		}
	}
}
