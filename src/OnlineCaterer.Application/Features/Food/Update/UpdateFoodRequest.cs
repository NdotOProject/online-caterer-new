using OnlineCaterer.Application.Features.Food.Create;

namespace OnlineCaterer.Application.Features.Food.Update
{
	public class UpdateFoodRequest : CreateFoodRequest
	{
		public int Id { get; set; }
		public bool Discontinued { get; set; }
		public int CurrentQuantity { get; set; }
	}
}
