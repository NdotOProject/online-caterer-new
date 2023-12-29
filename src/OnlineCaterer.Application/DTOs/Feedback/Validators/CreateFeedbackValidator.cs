using FluentValidation;
using OnlineCaterer.Application.Contracts.Persistence;

namespace OnlineCaterer.Application.DTOs.Feedback.Validators
{
	public class CreateFeedbackValidator
		: AbstractValidator<CreateFeedbackDTO>
	{
		public CreateFeedbackValidator(IUnitOfWork unitOfWork)
		{
			RuleFor(o => o.CustomerId)
				.NotNull()
				.WithMessage("Customer Id is required.");

			RuleFor(o => o.CustomerId)
				.GreaterThan(0)
				.WithMessage("Customer Id must greater than 0.");

			RuleFor(o => o.CustomerId)
				.MustAsync(async (id, token) =>
					await unitOfWork.CustomerRepository.Contains(id))
				.WithMessage("Customer is non-existent.");

			RuleFor(o => o.FoodId)
				.NotNull()
				.WithMessage("Food Id is required.");

			RuleFor(o => o.FoodId)
				.GreaterThan(0)
				.WithMessage("Food Id must greater than 0.");

			RuleFor(o => o.FoodId)
				.MustAsync(async (id, token) =>
					await unitOfWork.FoodRepository.Contains(id))
				.WithMessage("Food is non-existent.");

			RuleFor(o => o.RatingPoint)
				.InclusiveBetween(0, 5)
				.WithMessage("Rating Point must be between 0 and 5.");
		}
	}
}
