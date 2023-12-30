using AutoMapper;
using OnlineCaterer.Application.DTOs.Event;

namespace OnlineCaterer.Application.DTOs.Mappers
{
	public class EventMapper : Profile
	{
		public EventMapper()
		{
			CreateMap<Domain.Core.Event, EventDTO>()
				.ReverseMap();

			CreateMap<CreateEventDTO, Domain.Core.Event>();
		}
	}
}
