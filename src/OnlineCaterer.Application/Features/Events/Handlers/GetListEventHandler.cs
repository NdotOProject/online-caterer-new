using AutoMapper;
using MediatR;
using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Contracts.Repositories.Core;
using OnlineCaterer.Application.DTOs.Event;
using OnlineCaterer.Application.Features.Events.Queries;
using OnlineCaterer.Application.Models.Api.Handler;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.Events.Handlers
{
	public class GetListEventHandler
		: GetListHandler<GetListEventQuery, EventDTO>,
		IRequestHandler<GetListEventQuery, ListResponse<EventDTO>>
	{
		private readonly IEventRepository _eventRepository;
		private readonly IMapper _mapper;

		public GetListEventHandler(
			IPermissionProvider permissonProvider, IUserService userService,
			IEventRepository eventRepository,
			IMapper mapper) : base(permissonProvider, userService)
		{
			_eventRepository = eventRepository;
			_mapper = mapper;
		}

		public async Task<ListResponse<EventDTO>> Handle(
			GetListEventQuery request, CancellationToken cancellationToken)
		{
			return await GetResponse(request);
		}

		protected override async Task Resolve(
			GetListEventQuery request, ListResponse<EventDTO> response)
		{
			var events = await _eventRepository.GetAll();
			response.Payload = _mapper.Map<List<EventDTO>>(events);
		}
	}
}
