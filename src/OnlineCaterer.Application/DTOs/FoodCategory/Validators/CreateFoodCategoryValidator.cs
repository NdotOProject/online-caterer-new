using FluentValidation;

namespace OnlineCaterer.Application.DTOs.FoodCategory.Validators
{
	public class CreateFoodCategoryValidator
		: AbstractValidator<CreateFoodCategoryDTO>
	{
		public CreateFoodCategoryValidator()
		{
			RuleFor(o => o.Name)
				.NotEmpty()
				.WithMessage("Name is required.");

			RuleFor(o => o.Name)
				.MaximumLength(100)
				.WithMessage("Name has a maximum length of 100.");
		}
	}
}
