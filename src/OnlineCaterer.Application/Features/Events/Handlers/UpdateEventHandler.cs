using AutoMapper;
using MediatR;
using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Contracts.Persistence;
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
	public class UpdateEventHandler
		: PutHandler<UpdateEventCommand, EventDTO>,
		IRequestHandler<UpdateEventCommand, VoidResponse>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public UpdateEventHandler(
			IPermissionProvider permissonProvider,
			IUserService userService,
			IUnitOfWork unitOfWork,
			IMapper mapper)
			: base(permissonProvider, userService)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<VoidResponse> Handle(
			UpdateEventCommand request, CancellationToken cancellationToken)
		{
			return await GetResponse(request);
		}

		protected override Task Resolve(
			UpdateEventCommand request, VoidResponse response)
		{
			var evt = _mapper.Map<Event>(request.Body);
			_unitOfWork.EventRepository.Update(evt);

			response.Id = evt.Id;
			response.Message = $"Update event with ID {request.Body.Id} was successful.";

			return Task.CompletedTask;
		}

		protected override Task Reject(
			UpdateEventCommand request, VoidResponse response)
		{
			response.Message = $"An error occurred while updating the event.";
			return Task.CompletedTask;
		}

		protected override async Task<Permission> GetPermission(
			IPermissionProvider provider)
		{
			return await provider.GetPermission(
				Objects.Event,
				Actions.Update
			);
		}

		protected override async Task Validate(
			UpdateEventCommand request, ErrorList errorList)
		{
			var validator = new UpdateEventValidator(_unitOfWork);
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
