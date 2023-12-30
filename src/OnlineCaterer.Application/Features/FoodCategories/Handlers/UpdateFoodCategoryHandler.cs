using AutoMapper;
using MediatR;
using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Contracts.Persistence;
using OnlineCaterer.Application.DTOs.FoodCategory;
using OnlineCaterer.Application.DTOs.FoodCategory.Validators;
using OnlineCaterer.Application.Features.FoodCategories.Commands;
using OnlineCaterer.Application.Models.Api.Error;
using OnlineCaterer.Application.Models.Api.Handler;
using OnlineCaterer.Application.Models.Api.Response;
using OnlineCaterer.Application.Models.Identity.Conventions;
using OnlineCaterer.Application.Models.Identity.Helper;
using OnlineCaterer.Domain.Core;
using System.Net;

namespace OnlineCaterer.Application.Features.FoodCategories.Handlers
{
	public class UpdateFoodCategoryHandler
		: PostHandler<UpdateFoodCategoryCommand, FoodCategoryDTO>,
		IRequestHandler<UpdateFoodCategoryCommand, VoidResponse>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public UpdateFoodCategoryHandler(
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
			UpdateFoodCategoryCommand request, CancellationToken cancellationToken)
		{
			return await GetResponse(request);
		}

		protected override Task Resolve(
			UpdateFoodCategoryCommand request, VoidResponse response)
		{
			var category = _mapper.Map<FoodCategory>(request.Body);

			_unitOfWork.FoodCategoryRepository.Update(category);

			response.Id = category.Id;
			response.Message = $"Update food category" +
				$" with ID {request.Body.Id} was successful.";

			return Task.CompletedTask;
		}

		protected override Task Reject(
			UpdateFoodCategoryCommand request, VoidResponse response)
		{
			response.Message = $"An error occurred while updating the food category.";
			return Task.CompletedTask;
		}

		protected override Task<Permission> GetPermission(
			IPermissionProvider provider)
		{
			return provider.GetPermission(
				Objects.FoodCategory,
				Actions.Update
			);
		}

		protected override async Task Validate(
			UpdateFoodCategoryCommand request, ErrorList errorList)
		{
			var validator = new UpdateFoodCategoryValidator(_unitOfWork);
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
