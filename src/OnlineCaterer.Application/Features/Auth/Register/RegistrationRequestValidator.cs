using FluentValidation;
using OnlineCaterer.Application.Contracts.Persistence;
using OnlineCaterer.Application.Exceptions;

namespace OnlineCaterer.Application.Features.Auth.Register
{
	public class RegistrationRequestValidator : AbstractValidator<RegistrationRequest>
	{
		public RegistrationRequestValidator(IUnitOfWork unitOfWork)
		{

			RuleFor(o => o.Email)
				.NotEmpty()
				.EmailAddress()
				.MustAsync(async (email, token) =>
				{
					try
					{
						await unitOfWork.UserRepository.Get(
							user => user.Email == email
						);
						return false;
					}
					catch (NotFoundException)
					{
						return true;
					}
				})
				.WithMessage("Invalid Email address!");

			RuleFor(o => o.Password)
				.NotEmpty()
				.MinimumLength(5)
				.WithMessage("Invalid Password!");

			RuleFor(o => o.FirstName)
				.NotEmpty()
				.WithMessage("FirstName not empty!");

			RuleFor(o => o.LastName)
				.NotEmpty()
				.WithMessage("LastName not empty!");

			RuleFor(o => o.Address)
				.NotEmpty()
				.WithMessage("Address not empty!");
		}
	}
}
