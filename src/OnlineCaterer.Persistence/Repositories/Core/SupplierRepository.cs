using Microsoft.EntityFrameworkCore;
using OnlineCaterer.Application.Contracts.Repositories.Core;
using OnlineCaterer.Domain.Core;
using OnlineCaterer.Persistence.Repositories.Generic;

namespace OnlineCaterer.Persistence.Repositories.Core
{
	public class SupplierRepository
		: FullActionRepository<Supplier, int>,
		ISupplierRepository
	{
		private readonly OnlineCatererDbContext _dbContext;

		public SupplierRepository(
			OnlineCatererDbContext dbContext)
			: base(dbContext)
		{
			_dbContext = dbContext;
		}

		public new async Task<IReadOnlyCollection<Supplier>> GetAll()
		{
			return await GetQueryable()
				.ToListAsync();
		}

		public new IQueryable<Supplier> GetQueryable()
		{
			return (
				from sup in _dbContext.Suppliers
				select new Supplier
				{
					Id = sup.Id,
					Name = sup.Name,
					Address = sup.Address,
					Introduction = sup.Introduction,
					RatingPoint = sup.RatingPoint,
					Status = sup.Status,
					Foods = _dbContext.Foods
						.Include(f => f.Images)
						.Where(f => f.SupplierId == sup.Id)
						.ToList(),
				}
			).AsNoTracking();
		}
	}
}
