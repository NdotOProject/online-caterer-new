using MediatR;
using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Contracts.Persistence;
using OnlineCaterer.Application.Features.Foods.Commands;
using OnlineCaterer.Application.Models.Api.Error;
using OnlineCaterer.Application.Models.Api.Handler;
using OnlineCaterer.Application.Models.Api.Response;
using OnlineCaterer.Application.Models.Identity.Conventions;
using OnlineCaterer.Application.Models.Identity.Helper;
using System.Net;

namespace OnlineCaterer.Application.Features.Foods.Handlers
{
	// delete food => delete image and feedback
	public class DeleteFoodHandler :
		DeleteHandler<DeleteFoodCommand>,
		IRequestHandler<DeleteFoodCommand, VoidResponse>
	{
		private readonly IUnitOfWork _unitOfWork;

		public DeleteFoodHandler(
			IPermissionProvider permissonProvider,
			IUserService userService,
			IUnitOfWork unitOfWork)
			: base(permissonProvider, userService)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<VoidResponse> Handle(
			DeleteFoodCommand request, CancellationToken cancellationToken)
		{
			return await GetResponse(request);
		}

		protected override async Task Resolve(
			DeleteFoodCommand request, VoidResponse response)
		{
			var food = await _unitOfWork.FoodRepository.Get(request.Id);

			foreach (var img in food.Images)
			{
				_unitOfWork.FoodImageRepository.Delete(img);
			}

			foreach (var feedback in food.Feedbacks)
			{
				_unitOfWork.FeedbackRepository.Delete(feedback);
			}

			_unitOfWork.FoodRepository.Delete(food);

			response.Id = food.Id;
			response.Message = $"Food with ID {request.Id} has been deleted.";
		}

		protected override Task Reject(
			DeleteFoodCommand request, VoidResponse response)
		{
			response.Message = $"Delete food with ID {request.Id} failed.";
			return Task.CompletedTask;
		}

		protected override Task<Permission> GetPermission(
			IPermissionProvider provider)
		{
			return provider.GetPermission(
				Objects.Food,
				Actions.Delete
			);
		}

		protected override async Task Validate(
			DeleteFoodCommand request, ErrorList errorList)
		{
			var isExist = await _unitOfWork.FoodRepository.Contains(request.Id);
			if (!isExist)
			{
				errorList.Add(
					HttpStatusCode.NotFound,
					$"Food with ID {request.Id} does not exist."
				);
			}
		}
	}
}
