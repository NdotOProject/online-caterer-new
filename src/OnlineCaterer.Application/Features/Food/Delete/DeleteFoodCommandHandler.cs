using MediatR;
using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Contracts.Persistence;
using OnlineCaterer.Application.Exceptions;
using OnlineCaterer.Application.Models.Api.Error;
using OnlineCaterer.Application.Models.Api.Request.Delete;
using OnlineCaterer.Application.Models.Api.Response;
using System.Net;

namespace OnlineCaterer.Application.Features.Food.Delete
{
	public class DeleteFoodCommandHandler :
		DeleteRequestHandler<DeleteFoodCommand>,
		IRequestHandler<DeleteFoodCommand, VoidResponse>
	{
		private readonly IUnitOfWork _unitOfWork;

		public DeleteFoodCommandHandler(
			IPermissionProvider permissonProvider, IUserService userService,
			IUnitOfWork unitOfWork) : base(permissonProvider, userService)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<VoidResponse> Handle(
			DeleteFoodCommand request, CancellationToken cancellationToken)
			=> await GetResponse(request);

		protected override Task Reject(VoidResponse response)
		{
			response.Message = "Delete Failed!";
			return Task.CompletedTask;
		}

		protected override async Task Resolve(DeleteFoodCommand request, VoidResponse response)
		{
			try
			{
				Domain.Core.Food food = await _unitOfWork.FoodRepository.Get(request.Id);
				_unitOfWork.FoodRepository.Delete(food);

				response.Message = "Delete Done and Successfull.";
			}
			catch (NotFoundException)
			{
				response.AddError(new ErrorInfo(HttpStatusCode.NotFound, "The food not found!"));
			}
		}
	}
}
