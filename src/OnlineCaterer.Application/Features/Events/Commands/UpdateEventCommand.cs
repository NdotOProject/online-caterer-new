using MediatR;
using OnlineCaterer.Application.DTOs.Event;
using OnlineCaterer.Application.Exceptions;
using OnlineCaterer.Application.Models.Api.Request;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.Events.Commands
{
	public class UpdateEventCommand
		: IApiBodyRequest<UpdateEventDTO>,
		IRequest<VoidResponse>
	{
		public int Id { get; set; }

		private UpdateEventDTO _dto = null!;
		public UpdateEventDTO Body
		{
			get
			{
				return _dto;
			}
			set {
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
