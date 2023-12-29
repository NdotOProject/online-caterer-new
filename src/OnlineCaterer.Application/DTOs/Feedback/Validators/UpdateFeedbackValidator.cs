﻿using FluentValidation;
using OnlineCaterer.Application.Contracts.Persistence;

namespace OnlineCaterer.Application.DTOs.Feedback.Validators
{
	public class UpdateFeedbackValidator
		: AbstractValidator<UpdateFeedbackDTO>
	{
		public UpdateFeedbackValidator(IUnitOfWork unitOfWork)
		{
			RuleFor(o => o.Id)
				.NotNull()
				.WithMessage("Id is required.");

			RuleFor(o => o.Id)
				.GreaterThan(0)
				.WithMessage("Id must greater than 0.");

			RuleFor(o => o.Id)
				.MustAsync(async (id, token) =>
					await unitOfWork.FeedbackRepository.Contains(id))
				.WithMessage("Feedback is non-existent.");

			RuleFor(o => o.RatingPoint)
				.InclusiveBetween(0, 5)
				.WithMessage("Rating Point must be between 0 and 5.");
		}
	}
}
