using FluentValidation;
using OnlineCaterer.Application.Contracts.Persistence;

namespace OnlineCaterer.Application.DTOs.FoodCategory.Validators
{
	public class UpdateFoodCategoryValidator
		: AbstractValidator<FoodCategoryDTO>
	{
		public UpdateFoodCategoryValidator(IUnitOfWork unitOfWork)
		{
			RuleFor(o => o.Id)
				.NotNull()
				.WithMessage("Id is required.");

			RuleFor(o => o.Id)
				.GreaterThan(0)
				.WithMessage("Id must greater than 0.");

			RuleFor(o => o.Id)
				.MustAsync(async (id, token) =>
					await unitOfWork.FoodCategoryRepository.Contains(id))
				.WithMessage("Event is non-existent.");

			RuleFor(o => o.Name)
				.NotEmpty()
				.WithMessage("Name is required.");

			RuleFor(o => o.Name)
				.MaximumLength(100)
				.WithMessage("Name has a maximum length of 100.");
		}
	}
}
