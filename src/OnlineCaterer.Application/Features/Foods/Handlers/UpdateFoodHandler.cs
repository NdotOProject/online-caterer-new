using AutoMapper;
using MediatR;
using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Contracts.Persistence;
using OnlineCaterer.Application.DTOs.Food;
using OnlineCaterer.Application.DTOs.Food.Validators;
using OnlineCaterer.Application.Features.Foods.Commands;
using OnlineCaterer.Application.Models.Api.Error;
using OnlineCaterer.Application.Models.Api.Handler;
using OnlineCaterer.Application.Models.Api.Response;
using OnlineCaterer.Application.Models.Identity.Conventions;
using OnlineCaterer.Application.Models.Identity.Helper;
using OnlineCaterer.Domain.Core;
using System.Net;

namespace OnlineCaterer.Application.Features.Foods.Handlers
{
	// update food => insert or delete image
	public class UpdateFoodCommandHandler :
		PutHandler<UpdateFoodCommand, UpdateFoodDTO>,
		IRequestHandler<UpdateFoodCommand, VoidResponse>
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;

		public UpdateFoodCommandHandler(
			IUserService userService,
			IPermissionProvider permissionProvider,
			IMapper mapper,
			IUnitOfWork unitOfWork)
			: base(permissionProvider, userService)
		{
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<VoidResponse> Handle(
			UpdateFoodCommand request, CancellationToken cancellationToken)
		{
			return await GetResponse(request);
		}

		protected override async Task Resolve(
			UpdateFoodCommand request,
			VoidResponse response)
		{
			var food = _mapper.Map<Food>(request.Body);
			_unitOfWork.FoodRepository.Update(food);

			await _unitOfWork.SaveChanges(await GetUser());

			response.Message = $"Food with ID {request.Body.Id} Updated.";
		}

		protected override Task Reject(
			UpdateFoodCommand request,
			VoidResponse response)
		{
			response.Message = "Update Failed!";
			return Task.CompletedTask;
		}

		protected override async Task<Permission> GetPermission(
			IPermissionProvider provider)
		{
			return await provider.GetPermission(
				Objects.Food,
				Actions.Update
			);
		}

		protected override async Task Validate(
			UpdateFoodCommand request, ErrorList errorList)
		{
			var validator = new UpdateFoodValidator(_unitOfWork);
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
