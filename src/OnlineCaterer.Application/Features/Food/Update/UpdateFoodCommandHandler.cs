using AutoMapper;
using MediatR;
using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Contracts.Persistence;
using OnlineCaterer.Application.Models.Api.Request.Put;
using OnlineCaterer.Application.Models.Identity;

namespace OnlineCaterer.Application.Features.Food.Update
{
	public class UpdateFoodCommandHandler :
		PutRequestHandler<UpdateFoodCommand, UpdateFoodRequest, UpdateFoodResponse>,
		IRequestHandler<UpdateFoodCommand, Models.Api.Response.DataResponse<UpdateFoodResponse>>
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;

		public UpdateFoodCommandHandler(
			IUserService userService, IPermissionProvider permissionProvider,
			IMapper mapper, IUnitOfWork unitOfWork
		) : base(permissionProvider, userService)
		{
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<Models.Api.Response.DataResponse<UpdateFoodResponse>> Handle(
			UpdateFoodCommand request, CancellationToken cancellationToken
		) => await GetResponse(request);

		protected override async Task<Permission?> GetRequiredPermission(
			IPermissionProvider permissonProvider
		) => await permissonProvider.GetPermission(Objects.Food, Actions.Update);

		protected override Task Reject(Models.Api.Response.DataResponse<UpdateFoodResponse> response)
		{
			response.Message = "Update Failed!";
			return Task.CompletedTask;
		}

		protected override async Task Resolve(UpdateFoodCommand request, Models.Api.Response.DataResponse<UpdateFoodResponse> response)
		{
			var food = _mapper.Map<Domain.Core.Food>(request.Body);
			_unitOfWork.FoodRepository.Update(food);

			await _unitOfWork.SaveChanges(await GetUser());

			response.Message = "Food with  Updated.";
			response.Payload = new UpdateFoodResponse
			{

			};
		}
	}
}
