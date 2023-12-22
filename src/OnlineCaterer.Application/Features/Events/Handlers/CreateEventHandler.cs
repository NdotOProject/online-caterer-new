using AutoMapper;
using MediatR;
using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Contracts.Repositories.Core;
using OnlineCaterer.Application.Features.Events.Commands;
using OnlineCaterer.Application.Features.Events.Requests;
using OnlineCaterer.Application.Features.Events.Validators;
using OnlineCaterer.Application.Models.Api.Error;
using OnlineCaterer.Application.Models.Api.Handler;
using OnlineCaterer.Application.Models.Api.Response;
using OnlineCaterer.Application.Models.Identity.Conventions;
using OnlineCaterer.Application.Models.Identity.Helper;
using System.Net;

namespace OnlineCaterer.Application.Features.Events.Handlers
{
    public class CreateEventHandler :
		PostHandler<CreateEventCommand, CreateEventRequest>,
		IRequestHandler<CreateEventCommand, VoidResponse>
	{
		private readonly IEventRepository _eventRepository;
		private readonly IMapper _mapper;

		public CreateEventHandler(
			IPermissionProvider permissonProvider, IUserService userService,
			IEventRepository eventRepository, IMapper mapper)
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

		protected override async Task<Permission> GetPermission(
			IPermissionProvider provider)
		{
			return await provider.GetPermission(
				Objects.Event, Actions.Create);
		}

		protected override async Task Validate(
			CreateEventCommand request, ErrorList errorList)
		{
			var validator = new CreateEventValidator();
			var validationResult = await validator.ValidateAsync(request.Body);

			if (!validationResult.IsValid)
			{
				foreach (var error in validationResult.Errors)
				{
					errorList.Add(HttpStatusCode.BadRequest, error.ErrorMessage);
				}
			}
		}

		protected override Task Reject(
			CreateEventCommand request, VoidResponse response)
		{
			return Task.CompletedTask;
		}

		protected override Task Resolve(
			CreateEventCommand request, VoidResponse response)
		{
			var evt = _mapper.Map<Domain.Core.Event>(request.Body);



			throw new NotImplementedException();
		}
	}
}
