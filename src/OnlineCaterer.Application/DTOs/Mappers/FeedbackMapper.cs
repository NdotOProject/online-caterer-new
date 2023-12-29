using AutoMapper;
using OnlineCaterer.Application.DTOs.Feedback;

namespace OnlineCaterer.Application.DTOs.Mappers
{
	public class FeedbackMapper : Profile
	{
		public FeedbackMapper()
		{
			CreateMap<CreateFeedbackDTO, Domain.Core.Feedback>();

			CreateMap<UpdateFeedbackDTO, Domain.Core.Feedback>();

			CreateMap<Domain.Core.Feedback, FeedbackDTO>();
		}
	}
}
