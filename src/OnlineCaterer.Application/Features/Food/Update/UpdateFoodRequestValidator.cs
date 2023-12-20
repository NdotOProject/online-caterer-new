using FluentValidation;
using OnlineCaterer.Application.Contracts.Persistence;

namespace OnlineCaterer.Application.Features.Food.Update
{
	public class UpdateFoodRequestValidator : AbstractValidator<UpdateFoodRequest>
	{
		public UpdateFoodRequestValidator(IUnitOfWork unitOfWork)
		{
			RuleFor(o => o.Id)
				.GreaterThan(0)
				.MustAsync(async (id, token) =>
				{
					return (await unitOfWork.FoodRepository.Get(id)) != null;
				})
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

			RuleFor(o => o.CurrentQuantity)
				.GreaterThanOrEqualTo(0)
				.WithMessage("CurrentQuantity must greater than 0.");
		}
	}
}
