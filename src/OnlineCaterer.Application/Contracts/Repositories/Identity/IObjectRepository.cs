using OnlineCaterer.Application.Contracts.Repositories.Generic;

namespace OnlineCaterer.Application.Contracts.Repositories.Identity
{
    public interface IObjectRepository : IReadOnlyRepository<Domain.Identity.Object, int>
    {
    }
}
