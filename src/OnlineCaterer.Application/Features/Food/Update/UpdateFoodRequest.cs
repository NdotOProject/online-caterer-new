using FluentValidation;
using OnlineCaterer.Application.Contracts.Persistence;
using OnlineCaterer.Application.Features.Food.Create;

namespace OnlineCaterer.Application.Features.Food.Update
{
	public class UpdateFoodRequest : CreateFoodRequest
	{
		public int Id { get; set; }
		public bool Discontinued { get; set; }
		public int CurrentQuantity { get; set; }

		public new class Validator : AbstractValidator<UpdateFoodRequest>
		{
			public Validator(IUnitOfWork unitOfWork)
			{
				RuleFor(o => o.Id)
					.GreaterThan(0)
					.WithMessage("Not Found");

				RuleFor(o => o.CategoryId)
					.GreaterThan(0)
					.MustAsync(async (id, token) =>
					{
						return (await unitOfWork.FoodCategoryRepository.Get(id)) != null;
					})
					.WithMessage("Category does not exists.");

				RuleFor(o => o.EventId)
					.GreaterThan(0)
					.MustAsync(async (id, token) =>
					{
						return (await unitOfWork.EventRepository.Get(id)) != null;
					})
					.WithMessage("Event does not exists.");

				RuleFor(o => o.SupplierId)
					.GreaterThan(0)
					.MustAsync(async (id, token) =>
					{
						return (await unitOfWork.SupplierRepository.Get(id)) != null;
					})
					.WithMessage("Supplier does not exists.");

				RuleFor(o => o.Name)
					.NotEmpty()
					.WithMessage("Name is required.");

				RuleFor(o => o.UnitPrice)
					.GreaterThanOrEqualTo(0)
					.WithMessage("Price must greater than 0.");

			}
		}
	}
}
