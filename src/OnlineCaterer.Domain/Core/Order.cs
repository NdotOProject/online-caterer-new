using OnlineCaterer.Domain.Common;

namespace OnlineCaterer.Domain.Core
{
	public class Order : IIdAutoIncrementEntity
	{
		public int Id { get; set; }
		public int CustomerId { get; set; }
		public int EmployeeId { get; set; }
		public int SupplierId { get; set; }
		public int PaymentMethodId { get; set; }
		public string? PaymentInformation { get; set; }
		public DateTime ReceivedDate { get; set; }
		public string DeliveryAddress { get; set; } = null!;
		public decimal TotalAmount { get; set; }
		public int Status { get; set; }

		// rel
		public Customer Customer { get; set; } = null!;
		public Employee Employee { get; set; } = null!;
		public Supplier Supplier { get; set; } = null!;
		public PaymentMethod PaymentMethod { get; set; } = null!;
		public ICollection<OrderDetail> OrderDetails { get; set; } = new HashSet<OrderDetail>();
	}
}
