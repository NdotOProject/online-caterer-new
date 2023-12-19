using Microsoft.AspNetCore.Http;
using OnlineCaterer.Application.Constants;
using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Contracts.Persistence;
using OnlineCaterer.Application.Models.Identity;
using OnlineCaterer.Domain.Identity;

namespace OnlineCaterer.Persistence.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<User> GetCurrentUser()
        {
            int userId = Convert.ToInt32(
                _httpContextAccessor.HttpContext.User.FindFirst(CustomClaimTypes.Uid)?.Value
            );

            return await _unitOfWork.UserRepository.Get(userId);
        }

        public async Task<UserTypes> GetTypeOfCurrentUser()
        {
            User user = await GetCurrentUser();
            return user.UserTypeId switch
            {
                1 => UserTypes.Employee,
                2 => UserTypes.Customer,
                3 => UserTypes.Supplierr,
                _ => throw new NotSupportedException()
            };
        }
    }
}
