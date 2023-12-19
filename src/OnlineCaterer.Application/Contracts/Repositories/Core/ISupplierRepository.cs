﻿using OnlineCaterer.Application.Contracts.Repositories.Generic;
using OnlineCaterer.Domain.Core;

namespace OnlineCaterer.Application.Contracts.Repositories.Core
{
    public interface ISupplierRepository : IFullActionRepository<Supplier, int>
    {
    }
}
