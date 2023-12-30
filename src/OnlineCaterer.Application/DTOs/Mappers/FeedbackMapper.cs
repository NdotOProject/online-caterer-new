using AutoMapper;
using OnlineCaterer.Application.DTOs.Feedback;

namespace OnlineCaterer.Application.DTOs.Mappers
{
	public class FeedbackMapper : Profile
	{
		public FeedbackMapper()
		{
			CreateMap<Domain.Core.Feedback, FeedbackDTO>()
				.ReverseMap();

			CreateMap<CreateFeedbackDTO, Domain.Core.Feedback>();
		}
	}
}
