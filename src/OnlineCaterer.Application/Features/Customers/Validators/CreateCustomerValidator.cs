using FluentValidation;
using OnlineCaterer.Application.Contracts.Persistence;
using OnlineCaterer.Application.Features.Customers.Requests;

namespace OnlineCaterer.Application.Features.Customers.Validators
{
	public class CreateCustomerValidator
		: AbstractValidator<CreateCustomerRequest>
	{
		public CreateCustomerValidator(IUnitOfWork unitOfWork)
		{
			#region Email
			RuleFor(o => o.Email)
				.NotEmpty()
				.WithSeverity(Severity.Error)
				.WithMessage("Email is required.");

			RuleFor(o => o.Email)
				.EmailAddress()
				.WithSeverity(Severity.Error)
				.WithMessage("Email format is incorrect.");

			RuleFor(o => o.Email)
				.MustAsync(async (email, token) =>
				{
					bool isExists =
						await unitOfWork.UserRepository
							.ExistsByEmail(email);
					return isExists;
				})
				.WithSeverity(Severity.Error)
				.WithMessage("This email has been registered.");
			#endregion

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
		}
	}
}
