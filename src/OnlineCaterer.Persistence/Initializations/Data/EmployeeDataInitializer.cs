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
						Address = "Hà Nội, Việt Nam",
						FirstName = "Tuấn Anh",
						LastName = "Vũ",
						RatingPoint = 0,
						Status = false,
					},
				}
			);
		}
	}
}
