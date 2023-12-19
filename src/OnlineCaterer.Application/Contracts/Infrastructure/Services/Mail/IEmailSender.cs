using OnlineCaterer.Application.Models.Services;

namespace OnlineCaterer.Application.Contracts.Infrastructure.Services.Mail
{
	public interface IEmailSender
	{
		Task<bool> SendEmailAsync(Email email);
	}
}
