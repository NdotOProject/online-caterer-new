using OnlineCaterer.Domain.Identity;

namespace OnlineCaterer.Application.Contracts.Services
{
    public interface IUserService
    {
        Task<User> GetCurrentUser();
    }
}
