using AutoMapper;
using MediatR;
using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Contracts.Persistence;
using OnlineCaterer.Application.Models.Api.Handler;
using OnlineCaterer.Application.Models.Api.Response;
using OnlineCaterer.Application.Models.Identity.Conventions;
using OnlineCaterer.Application.Models.Identity.Helper;

namespace OnlineCaterer.Application.Features.Food.Update
{
    // update food => insert or delete image
    public class UpdateFoodCommandHandler :
		PutHandler<UpdateFoodCommand, UpdateFoodRequest, UpdateFoodResponse>,
		IRequestHandler<UpdateFoodCommand, DataResponse<UpdateFoodResponse>>
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

		public async Task<DataResponse<UpdateFoodResponse>> Handle(
			UpdateFoodCommand request, CancellationToken cancellationToken
		) => await GetResponse(request);

		protected override async Task<Permission> GetPermission(
			IPermissionProvider provider)
			=> await provider.GetPermission(Objects.Food, Actions.Update);

		protected override Task Reject(
			UpdateFoodCommand request, DataResponse<UpdateFoodResponse> response)
		{
			response.Message = "Update Failed!";
			return Task.CompletedTask;
		}

		protected override async Task Resolve(
			UpdateFoodCommand request, DataResponse<UpdateFoodResponse> response)
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
