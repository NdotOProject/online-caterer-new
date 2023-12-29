using MediatR;
using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Contracts.Repositories.Core;
using OnlineCaterer.Application.Features.Events.Commands;
using OnlineCaterer.Application.Models.Api.Error;
using OnlineCaterer.Application.Models.Api.Handler;
using OnlineCaterer.Application.Models.Api.Response;
using OnlineCaterer.Application.Models.Identity.Conventions;
using OnlineCaterer.Application.Models.Identity.Helper;
using System.Net;

namespace OnlineCaterer.Application.Features.Events.Handlers
{
	public class DeleteEventHandler
		: DeleteHandler<DeleteEventCommand>,
		IRequestHandler<DeleteEventCommand, VoidResponse>
	{
		private readonly IEventRepository _eventRepository;

		public DeleteEventHandler(
			IPermissionProvider permissonProvider,
			IUserService userService,
			IEventRepository eventRepository)
			: base(permissonProvider, userService)
		{
			_eventRepository = eventRepository;
		}

		public async Task<VoidResponse> Handle(
			DeleteEventCommand request,
			CancellationToken cancellationToken)
		{
			return await GetResponse(request);
		}

		protected override async Task Resolve(
			DeleteEventCommand request, VoidResponse response)
		{
			var evt = await _eventRepository.Get(request.Id);
			_eventRepository.Delete(evt);

			response.Id = evt.Id;
			response.Message = $"Event with ID {request.Id} has been deleted.";
		}

		protected override Task Reject(
			DeleteEventCommand request, VoidResponse response)
		{
			response.Message = $"Delete event with ID {request.Id} failed.";
			return Task.CompletedTask;
		}

		protected override async Task<Permission> GetPermission(
			IPermissionProvider provider)
		{
			return await provider.GetPermission(
				Objects.Event,
				Actions.Delete
			);
		}

		protected override async Task Validate(
			DeleteEventCommand request, ErrorList errorList)
		{
			if (!await _eventRepository.Contains(request.Id))
			{
				errorList.Add(
					HttpStatusCode.NotFound,
					$"Event with ID {request.Id} does not exist."
				);
			}
		}
	}
}
