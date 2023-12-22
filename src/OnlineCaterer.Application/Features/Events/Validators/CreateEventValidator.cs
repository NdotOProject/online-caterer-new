using FluentValidation;
using OnlineCaterer.Application.Features.Events.Requests;

namespace OnlineCaterer.Application.Features.Events.Validators
{
	public class CreateEventValidator :
		AbstractValidator<CreateEventRequest>
	{
	}
}
