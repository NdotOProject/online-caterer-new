using FluentValidation;
using OnlineCaterer.Application.Contracts.Persistence;

namespace OnlineCaterer.Application.Features.Food.Create
{
	public class CreateFoodRequestValidator : AbstractValidator<CreateFoodRequest>
	{
		public CreateFoodRequestValidator(IUnitOfWork unitOfWork)
		{
			RuleFor(o => o.CategoryId)
				.GreaterThan(0)
				.MustAsync(async (id, token) =>
					await unitOfWork.FoodCategoryRepository.Contains(id)
				)
				.WithMessage("Category does not exists.");

			RuleFor(o => o.EventId)
				.GreaterThan(0)
				.MustAsync(async (id, token) =>
					await unitOfWork.EventRepository.Contains(id)
				)
				.WithMessage("Event does not exists.");

			RuleFor(o => o.SupplierId)
				.GreaterThan(0)
				.MustAsync(async (id, token) =>
					await unitOfWork.SupplierRepository.Contains(id)
				)
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
