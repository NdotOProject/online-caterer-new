using AutoMapper;
using MediatR;
using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Contracts.Repositories.Core;
using OnlineCaterer.Application.DTOs.Event;
using OnlineCaterer.Application.DTOs.Event.Validators;
using OnlineCaterer.Application.Features.Events.Commands;
using OnlineCaterer.Application.Models.Api.Error;
using OnlineCaterer.Application.Models.Api.Handler;
using OnlineCaterer.Application.Models.Api.Response;
using OnlineCaterer.Application.Models.Identity.Conventions;
using OnlineCaterer.Application.Models.Identity.Helper;
using OnlineCaterer.Domain.Core;
using System.Net;

namespace OnlineCaterer.Application.Features.Events.Handlers
{
	public class CreateEventHandler
		: PostHandler<CreateEventCommand, CreateEventDTO>,
		IRequestHandler<CreateEventCommand, VoidResponse>
	{
		private readonly IEventRepository _eventRepository;
		private readonly IMapper _mapper;

		public CreateEventHandler(
			IPermissionProvider permissonProvider,
			IUserService userService,
			IEventRepository eventRepository,
			IMapper mapper)
			: base(permissonProvider, userService)
		{
			_eventRepository = eventRepository;
			_mapper = mapper;
		}

		public async Task<VoidResponse> Handle(
			CreateEventCommand request, CancellationToken cancellationToken)
		{
			return await GetResponse(request);
		}

		protected override async Task Resolve(
			CreateEventCommand request, VoidResponse response)
		{
			var evt = _mapper.Map<Event>(request.Body);

			evt = await _eventRepository.Add(evt);

			response.Id = evt.Id;
			response.Message = "Created new event successfully.";
		}

		protected override Task Reject(
			CreateEventCommand request, VoidResponse response)
		{
			response.Message = "Create new event failed.";
			return Task.CompletedTask;
		}

		protected override async Task<Permission> GetPermission(
			IPermissionProvider provider)
		{
			return await provider.GetPermission(
				Objects.Event,
				Actions.Create
			);
		}

		protected override async Task Validate(
			CreateEventCommand request, ErrorList errorList)
		{
			var validator = new CreateEventValidator();
			var result = await validator.ValidateAsync(request.Body);

			if (!result.IsValid)
			{
				foreach (var error in result.Errors)
				{
					errorList.Add(
						HttpStatusCode.BadRequest,
						error.ErrorMessage
					);
				}
			}
		}
	}
}
