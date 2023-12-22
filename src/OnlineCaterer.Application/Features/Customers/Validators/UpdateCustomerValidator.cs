using FluentValidation;
using OnlineCaterer.Application.Features.Customers.Requests;

namespace OnlineCaterer.Application.Features.Customers.Validators
{
	public class UpdateCustomerRequestValidator :
		AbstractValidator<UpdateCustomerRequest>
	{
		public UpdateCustomerRequestValidator()
		{
			#region Password
			RuleFor(o => o.Password)
				.NotEmpty()
				.WithSeverity(Severity.Error)
				.WithMessage("Password is required");

			RuleFor(o => o.Password)
				.MinimumLength(5)
				.WithSeverity(Severity.Error)
				.WithMessage("Password must have at least 5 characters.");
			#endregion

			RuleFor(o => o.Id)
				.GreaterThan(0)
				.WithSeverity(Severity.Error)
				.WithMessage("Invalid Id");

			RuleFor(o => o.FirstName)
				.NotEmpty()
				.WithSeverity(Severity.Error)
				.WithMessage("FirstName is required.");

			RuleFor(o => o.LastName)
				.NotEmpty()
				.WithSeverity(Severity.Error)
				.WithMessage("LastName is required.");

			RuleFor(o => o.Address)
				.NotEmpty()
				.WithSeverity(Severity.Error)
				.WithMessage("Address is required.");

			RuleFor(o => o.UserName)
				.NotEmpty()
				.WithSeverity(Severity.Error)
				.WithMessage("UserName is required.");

			RuleFor(o => o.PhoneNumber)
				.NotEmpty()
				.WithSeverity(Severity.Error)
				.WithMessage("PhoneNumber is required.");
		}
	}
}
