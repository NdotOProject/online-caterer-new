using AutoMapper;
using MediatR;
using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Contracts.Persistence;
using OnlineCaterer.Application.Models.Api.Handler;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.Food.Queries.All
{
	public class GetAllFoodCommandHandler
		: GetListHandler<GetAllFoodCommand, FoodInformation>,
		IRequestHandler<GetAllFoodCommand, ListResponse<FoodInformation>>
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

		public async Task<ListResponse<FoodInformation>> Handle(
			GetAllFoodCommand request, CancellationToken cancellationToken)
			=> await GetResponse(request);

		protected override async Task Resolve(
			GetAllFoodCommand request, ListResponse<FoodInformation> response)
		{
			var foods = await _unitOfWork.FoodRepository.GetAll();
			response.Message = "List of all food.";
			response.Payload = _mapper.Map<List<FoodInformation>>(foods);
			response.Include(foods.Select(f => f.Category));
		}
	}
}
