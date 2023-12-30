using Microsoft.EntityFrameworkCore;
using OnlineCaterer.Application.Contracts.Repositories.Core;
using OnlineCaterer.Domain.Core;
using OnlineCaterer.Persistence.Repositories.Generic;
using System.Linq.Expressions;

namespace OnlineCaterer.Persistence.Repositories.Core
{
	public class CustomerRepository
		: FullActionRepository<Customer, int>,
		ICustomerRepository
	{
		private readonly OnlineCatererDbContext _dbContext;

		public CustomerRepository(
			OnlineCatererDbContext dbContext)
			: base(dbContext)
		{
			_dbContext = dbContext;
		}

		public new async Task<Customer?> Get(int key)
		{
			return await Get(c => c.Id == key);
		}

		public new async Task<Customer?> Get(
			Expression<Func<Customer, bool>> predicate)
		{
			var query = _dbContext.Customers
				.Include(c => c.Feedbacks)
				.Include(c => c.Orders)
				.Where(predicate)
				.Take(1);

			return query.Any()
				? await query.SingleAsync()
				: null;
		}

		public new async Task<IReadOnlyCollection<Customer>> GetAll()
		{
			return await _dbContext.Customers
				.Include(c => c.Feedbacks)
				.Include(c => c.Orders)
				.ToListAsync();
		}

		public new async Task<IReadOnlyCollection<Customer>> GetAll(
			Expression<Func<Customer, bool>> predicate)
		{
			if (predicate == null)
			{
				return await GetAll();
			}
			else
			{
				return await _dbContext.Customers
					.Include(c => c.Feedbacks)
					.Include(c => c.Orders)
					.Where(predicate)
					.ToListAsync();
			}
		}
		public new IQueryable<Customer> GetQueryable()
		{
			return _dbContext.Customers;
		}
	}
}
