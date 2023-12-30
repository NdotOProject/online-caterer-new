using MediatR;
using OnlineCaterer.Application.DTOs.Feedback;
using OnlineCaterer.Application.Exceptions;
using OnlineCaterer.Application.Models.Api.Request;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.Feedback.Commands
{
	public class UpdateFeedbackCommand
		: IApiBodyRequest<FeedbackDTO>,
		IRequest<VoidResponse>
	{
		public int Id { get; set; }

		private FeedbackDTO _dto = null!;
		public FeedbackDTO Body
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
