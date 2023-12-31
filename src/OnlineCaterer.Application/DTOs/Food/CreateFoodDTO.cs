﻿using OnlineCaterer.Application.Models.Api.Request;

namespace OnlineCaterer.Application.DTOs.Food
{
	public class CreateFoodDTO
		: IRequestBody
	{
		public int CategoryId { get; set; }
		public int EventId { get; set; }
		public int SupplierId { get; set; }
		public string Name { get; set; } = null!;
		public string Description { get; set; } = null!;
		public decimal UnitPrice { get; set; }

		public List<string> Images { get; set; } = new();
	}
}
