using OnlineCaterer.Domain.Common;

namespace OnlineCaterer.Domain.Core
{
	public class Food : IIdAutoIncrementEntity, IAuditableEntity
	{
		public int Id { get; set; }
		public int CategoryId { get; set; }
		public int EventId { get; set; }
		public int SupplierId { get; set; }
		public string Name { get; set; } = null!;
		public string Description { get; set; } = null!;
		public decimal UnitPrice { get; set; }
		public int RatingPoint { get; set; }
		public bool Discontinued { get; set; }
		public int CurrentQuantity { get; set; }

		// impl IAuditableEntity
		public DateTime CreatedDate { get; set; }
		public int CreatedBy { get; set; }
		public DateTime LastModifiedDate { get; set; }
		public int LastModifiedBy { get; set; }

		// rel
		public Supplier Supplier { get; set; } = null!;
		public FoodCategory Category { get; set; } = null!;
		public Event Event { get; set; } = null!;
		public ICollection<FoodImage> Images { get; set; } = new HashSet<FoodImage>();
		public ICollection<Feedback> Feedbacks { get; set; } = new HashSet<Feedback>();
		public ICollection<OrderDetail> OrderDetails { get; set; } = new HashSet<OrderDetail>();
	}
}
