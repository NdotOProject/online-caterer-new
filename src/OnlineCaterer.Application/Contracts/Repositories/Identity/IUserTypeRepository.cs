using OnlineCaterer.Application.Contracts.Repositories.Generic;
using OnlineCaterer.Domain.Identity;

namespace OnlineCaterer.Application.Contracts.Repositories.Identity
{
    public interface IUserTypeRepository : IReadOnlyRepository<UserType, int>
    {
    }
}
