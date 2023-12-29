using AutoMapper;
using OnlineCaterer.Application.DTOs.Event;

namespace OnlineCaterer.Application.DTOs.Mappers
{
	public class EventMapper : Profile
	{
		public EventMapper()
		{
			CreateMap<CreateEventDTO, Domain.Core.Event>();

			CreateMap<UpdateEventDTO, Domain.Core.Event>();

			CreateMap<Domain.Core.Event, EventDTO>();
		}
	}
}
