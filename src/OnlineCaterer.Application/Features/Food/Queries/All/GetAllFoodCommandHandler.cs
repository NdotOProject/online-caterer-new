using AutoMapper;
using MediatR;
using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Contracts.Persistence;
using OnlineCaterer.Application.Models.Api.Request.Get;
using OnlineCaterer.Application.Models.Api.Response;
using OnlineCaterer.Application.Models.Identity;

namespace OnlineCaterer.Application.Features.Food.Queries.All
{
	public class GetAllFoodCommandHandler :
		GetRequestHandler<GetAllFoodCommand, List<FoodInformation>>,
		IRequestHandler<GetAllFoodCommand, DataResponse<List<FoodInformation>>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetAllFoodCommandHandler(
			IPermissionProvider permissonProvider, IUserService userService,
			IUnitOfWork unitOfWork, IMapper mapper) : base(permissonProvider, userService)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<DataResponse<List<FoodInformation>>> Handle(
			GetAllFoodCommand request, CancellationToken cancellationToken)
			=> await GetResponse(request);

		protected override Task Reject(DataResponse<List<FoodInformation>> response)
		{
			response.Message = "Get failed!";
			return Task.CompletedTask;
		}

		protected override async Task Resolve(
			GetAllFoodCommand request, DataResponse<List<FoodInformation>> response)
		{
			var foods = await _unitOfWork.FoodRepository.GetAll();
			response.Message = "List of all food.";
			response.Payload = _mapper.Map<List<FoodInformation>>(foods);
			response.Include(foods.Select(f => f.Category));
		}
	}
}
