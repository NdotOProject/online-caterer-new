using OnlineCaterer.Application.Models.Api.Request;

namespace OnlineCaterer.Application.DTOs.PaymentMethod
{
	public class CreatePaymentMethodDTO
		: IRequestBody
	{
		public string Name { get; set; } = null!;
		public string? Description { get; set; }
	}
}
