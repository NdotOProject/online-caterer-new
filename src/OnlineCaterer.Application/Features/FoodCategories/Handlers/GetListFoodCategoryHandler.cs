using AutoMapper;
using MediatR;
using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Contracts.Repositories.Core;
using OnlineCaterer.Application.DTOs.FoodCategory;
using OnlineCaterer.Application.Features.FoodCategories.Queries;
using OnlineCaterer.Application.Models.Api.Handler;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.FoodCategories.Handlers
{
	public class GetListFoodCategoryHandler
		: GetListHandler<GetListFoodCategoryQuery, FoodCategoryDTO>,
		IRequestHandler<GetListFoodCategoryQuery, ListResponse<FoodCategoryDTO>>
	{
		private readonly IFoodCategoryRepository _foodCategoryRepository;
		private readonly IMapper _mapper;

		public GetListFoodCategoryHandler(
			IPermissionProvider permissonProvider,
			IUserService userService,
			IFoodCategoryRepository foodCategoryRepository,
			IMapper mapper)
			: base(permissonProvider, userService)
		{
			_foodCategoryRepository = foodCategoryRepository;
			_mapper = mapper;
		}

		public async Task<ListResponse<FoodCategoryDTO>> Handle(
			GetListFoodCategoryQuery request,
			CancellationToken cancellationToken)
		{
			return await GetResponse(request);
		}

		protected override async Task Resolve(
			GetListFoodCategoryQuery request,
			ListResponse<FoodCategoryDTO> response)
		{
			var categories = await _foodCategoryRepository.GetAll();

			response.Payload = _mapper.Map<List<FoodCategoryDTO>>(categories);
		}
	}
}
