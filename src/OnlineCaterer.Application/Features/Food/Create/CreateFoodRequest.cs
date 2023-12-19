﻿using FluentValidation;
using OnlineCaterer.Application.Contracts.Persistence;

namespace OnlineCaterer.Application.Features.Food.Create
{
	public class CreateFoodRequest
	{
		public int CategoryId { get; set; }
		public int EventId { get; set; }
		public int SupplierId { get; set; }
		public string Name { get; set; } = null!;
		public string Description { get; set; } = null!;
		public decimal UnitPrice { get; set; }
		public List<string> Images { get; set; } = null!;

		public class Validator : AbstractValidator<CreateFoodRequest>
		{
			public Validator(IUnitOfWork unitOfWork)
			{
				RuleFor(o => o.CategoryId)
					.GreaterThan(0)
					.MustAsync(async (id, token) =>
						await unitOfWork.FoodCategoryRepository.Contains(id)
					)
					.WithMessage("Category does not exists.");

				RuleFor(o => o.EventId)
					.GreaterThan(0)
					.MustAsync(async (id, token) =>
						await unitOfWork.EventRepository.Contains(id)
					)
					.WithMessage("Event does not exists.");

				RuleFor(o => o.SupplierId)
					.GreaterThan(0)
					.MustAsync(async (id, token) =>
						await unitOfWork.SupplierRepository.Contains(id)
					)
					.WithMessage("Supplier does not exists.");

				RuleFor(o => o.Name)
					.NotEmpty()
					.WithMessage("Name is required.");

				RuleFor(o => o.UnitPrice)
					.GreaterThanOrEqualTo(0)
					.WithMessage("Price must greater than 0.");
			}
		}
	}
}