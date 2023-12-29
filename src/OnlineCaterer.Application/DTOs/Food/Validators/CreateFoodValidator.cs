using FluentValidation;
using OnlineCaterer.Application.Contracts.Persistence;

namespace OnlineCaterer.Application.DTOs.Food.Validators
{
	public class CreateFoodValidator
		: AbstractValidator<CreateFoodDTO>
	{
		public CreateFoodValidator(IUnitOfWork unitOfWork)
		{
			RuleFor(o => o.CategoryId)
				.NotNull()
				.WithMessage("Category Id is required.");

			RuleFor(o => o.CategoryId)
				.GreaterThan(0)
				.WithMessage("Category Id must greater than 0.");

			RuleFor(o => o.CategoryId)
				.MustAsync(async (id, token) =>
					await unitOfWork.FoodCategoryRepository.Contains(id))
				.WithMessage("Category is non-existent.");

			RuleFor(o => o.EventId)
				.NotNull()
				.WithMessage("Event Id is required.");

			RuleFor(o => o.EventId)
				.GreaterThan(0)
				.WithMessage("Event Id must greater than 0.");

			RuleFor(o => o.EventId)
				.MustAsync(async (id, token) =>
					await unitOfWork.EventRepository.Contains(id))
				.WithMessage("Event is non-existent.");

			RuleFor(o => o.SupplierId)
				.NotNull()
				.WithMessage("Supplier Id is required.");

			RuleFor(o => o.SupplierId)
				.GreaterThan(0)
				.WithMessage("Supplier Id must greater than 0.");

			RuleFor(o => o.SupplierId)
				.MustAsync(async (id, token) =>
					await unitOfWork.SupplierRepository.Contains(id))
				.WithMessage("Supplier is non-existent.");

			RuleFor(o => o.Name)
				.NotEmpty()
				.WithMessage("Name is required.");

			RuleFor(o => o.Name)
				.MaximumLength(100)
				.WithMessage("Name has a maximum length of 100.");

			RuleFor(o => o.UnitPrice)
				.GreaterThanOrEqualTo(0)
				.WithMessage("Price must greater than 0.");
		}
	}
}
