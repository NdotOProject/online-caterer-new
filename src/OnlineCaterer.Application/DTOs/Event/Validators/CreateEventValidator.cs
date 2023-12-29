using FluentValidation;

namespace OnlineCaterer.Application.DTOs.Event.Validators
{
	public class CreateEventValidator
		: AbstractValidator<CreateEventDTO>
	{
		public CreateEventValidator()
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
