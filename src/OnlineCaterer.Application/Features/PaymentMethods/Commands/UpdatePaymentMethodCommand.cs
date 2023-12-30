using MediatR;
using OnlineCaterer.Application.DTOs.PaymentMethod;
using OnlineCaterer.Application.Exceptions;
using OnlineCaterer.Application.Models.Api.Request;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.PaymentMethods.Commands
{
	public class UpdatePaymentMethodCommand
		: IApiBodyRequest<PaymentMethodDTO>,
		IRequest<VoidResponse>
	{
		public int Id { get; set; }

		private PaymentMethodDTO _dto = null!;
		public PaymentMethodDTO Body
		{
			get
			{
				return _dto;
			}
			set
			{
				if (value != null && value.Id == Id)
				{
					_dto = value;
				}
				else
				{
					throw new BadRequestException();
				}
			}
		}
	}
}
