﻿using Microsoft.EntityFrameworkCore;
using OnlineCaterer.Application.Contracts.Repositories.Core;
using OnlineCaterer.Application.Contracts.Repositories.Generic;
using OnlineCaterer.Domain.Core;

namespace OnlineCaterer.Persistence.Repositories.Core
{
	public class OrderDetailRepository : IOrderDetailRepository
	{
		private readonly ICreatableRepository<OrderDetail> _creatableRepository;
		private readonly IUpdatableRepository<OrderDetail> _updatableRepository;
		private readonly IDeletableRepository<OrderDetail> _deletableRepository;

		private readonly OnlineCatererDbContext _dbContext;

		public OrderDetailRepository(
			OnlineCatererDbContext dbContext,
			ICreatableRepository<OrderDetail> creatableRepository,
			IUpdatableRepository<OrderDetail> updatableRepository,
			IDeletableRepository<OrderDetail> deletableRepository)
		{
			_dbContext = dbContext;
			_creatableRepository = creatableRepository;
			_updatableRepository = updatableRepository;
			_deletableRepository = deletableRepository;
		}


		public async Task<OrderDetail> Add(OrderDetail entity)
		{
			return await _creatableRepository.Add(entity);
		}

		public async Task AddRange(ICollection<OrderDetail> orderDetails)
		{
			await _dbContext.AddRangeAsync(orderDetails);
		}

		public void Delete(OrderDetail entity)
		{
			_deletableRepository.Delete(entity);
		}

		public async Task<IReadOnlyCollection<OrderDetail>> GetByOrderId(int orderId)
		{
			return await _dbContext.OrderDetails
				.Where(od => od.OrderId == orderId)
				.ToListAsync();
		}

		public void Update(OrderDetail entity)
		{
			_updatableRepository.Update(entity);
		}
	}
}
