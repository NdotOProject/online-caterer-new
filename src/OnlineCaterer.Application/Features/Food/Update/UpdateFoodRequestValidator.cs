using FluentValidation;
using OnlineCaterer.Application.Contracts.Persistence;

namespace OnlineCaterer.Application.Features.Food.Update
{
	public class UpdateFoodRequestValidator : AbstractValidator<UpdateFoodRequest>
	{
		public UpdateFoodRequestValidator(IUnitOfWork unitOfWork)
		{
			RuleFor(o => o.Id)
				.NotNull()
				.GreaterThan(0)
				.MustAsync(async (id, token) =>
				{
					return await unitOfWork.FoodRepository.Contains(id);
				})
				.WithMessage("Not Found");

			RuleFor(o => o.CategoryId)
				.NotNull()
				.GreaterThan(0)
				.MustAsync(async (id, token) =>
				{
					return await unitOfWork.FoodCategoryRepository.Contains(id);
				})
				.WithMessage("Category does not exists.");

			RuleFor(o => o.EventId)
				.NotNull()
				.GreaterThan(0)
				.MustAsync(async (id, token) =>
				{
					return await unitOfWork.EventRepository.Contains(id);
				})
				.WithMessage("Event does not exists.");

			RuleFor(o => o.SupplierId)
				.NotNull()
				.GreaterThan(0)
				.MustAsync(async (id, token) =>
				{
					return await unitOfWork.SupplierRepository.Contains(id);
				})
				.WithMessage("Supplier does not exists.");

			RuleFor(o => o.Name)
				.NotEmpty()
				.WithMessage("Name is required.");

			RuleFor(o => o.UnitPrice)
				.NotNull()
				.GreaterThanOrEqualTo(0)
				.WithMessage("Price must greater than 0.");

			RuleFor(o => o.RatingPoint)
				.NotNull()
				.GreaterThanOrEqualTo(0)
				.WithMessage("Rating Point must greater than 0.");

			RuleFor(o => o.Discontinued)
				.NotNull()
				.WithMessage("Discontinued is required.");

			RuleFor(o => o.CurrentQuantity)
				.NotNull()
				.GreaterThanOrEqualTo(0)
				.WithMessage("Quantity must greater than 0.");
		}
	}
}
