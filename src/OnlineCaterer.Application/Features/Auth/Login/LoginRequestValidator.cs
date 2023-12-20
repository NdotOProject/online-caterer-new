using FluentValidation;
using OnlineCaterer.Application.Contracts.Persistence;
using OnlineCaterer.Application.Exceptions;

namespace OnlineCaterer.Application.Features.Auth.Login
{
	public class LoginRequestValidator : AbstractValidator<LoginRequest>
	{
		public LoginRequestValidator(IUnitOfWork unitOfWork)
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
		}
	}
}
