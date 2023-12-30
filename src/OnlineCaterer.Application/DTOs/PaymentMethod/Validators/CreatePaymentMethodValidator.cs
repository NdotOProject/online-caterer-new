using FluentValidation;

namespace OnlineCaterer.Application.DTOs.PaymentMethod.Validators
{
	public class CreatePaymentMethodValidator
		: AbstractValidator<CreatePaymentMethodDTO>
	{
		public CreatePaymentMethodValidator()
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
