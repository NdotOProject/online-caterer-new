using MediatR;
using OnlineCaterer.Application.DTOs.Feedback;
using OnlineCaterer.Application.Exceptions;
using OnlineCaterer.Application.Models.Api.Request;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.Feedback.Commands
{
	public class UpdateFeedbackCommand
		: IApiBodyRequest<UpdateFeedbackDTO>,
		IRequest<VoidResponse>
	{
		public int Id { get; set; }

		private UpdateFeedbackDTO _dto = null!;
		public UpdateFeedbackDTO Body
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
