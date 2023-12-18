using OnlineCaterer.Application.Models.Services;

namespace OnlineCaterer.Application.Contracts.Infrastructure
{
	public interface IEmailSender
	{
		Task<bool> SendEmailAsync(Email email);
	}
}
