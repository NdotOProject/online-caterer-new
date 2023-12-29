using MediatR;
using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Contracts.Repositories.Core;
using OnlineCaterer.Application.Features.FoodCategories.Commands;
using OnlineCaterer.Application.Models.Api.Error;
using OnlineCaterer.Application.Models.Api.Handler;
using OnlineCaterer.Application.Models.Api.Response;
using OnlineCaterer.Application.Models.Identity.Conventions;
using OnlineCaterer.Application.Models.Identity.Helper;
using System.Net;

namespace OnlineCaterer.Application.Features.FoodCategories.Handlers
{
	public class DeleteFoodCategoryHandler
		: DeleteHandler<DeleteFoodCategoryCommand>,
		IRequestHandler<DeleteFoodCategoryCommand, VoidResponse>
	{
		private readonly IFoodCategoryRepository _foodCategoryRepository;

		public DeleteFoodCategoryHandler(
			IPermissionProvider permissonProvider,
			IUserService userService,
			IFoodCategoryRepository foodCategoryRepository)
			: base(permissonProvider, userService)
		{
			_foodCategoryRepository = foodCategoryRepository;
		}

		public async Task<VoidResponse> Handle(
			DeleteFoodCategoryCommand request,
			CancellationToken cancellationToken)
		{
			return await GetResponse(request);
		}

		protected override async Task Resolve(
			DeleteFoodCategoryCommand request, VoidResponse response)
		{
			var category = await _foodCategoryRepository.Get(request.Id);

			_foodCategoryRepository.Delete(category);

			response.Id = category.Id;
			response.Message = $"Feedback with ID {request.Id} has been deleted.";
		}

		protected override Task Reject(
			DeleteFoodCategoryCommand request, VoidResponse response)
		{
			response.Message = $"Delete food category with ID {request.Id} failed.";
			return Task.CompletedTask;
		}

		protected override async Task<Permission> GetPermission(
			IPermissionProvider provider)
		{
			return await provider.GetPermission(
				Objects.FoodCategory,
				Actions.Delete
			);
		}

		protected override async Task Validate(
			DeleteFoodCategoryCommand request, ErrorList errorList)
		{
			var isExist = await _foodCategoryRepository.Contains(request.Id);

			if (!isExist)
			{
				errorList.Add(
					HttpStatusCode.NotFound,
					$"Food Category with ID {request.Id} does not exist."
				);
			}
		}
	}
}
