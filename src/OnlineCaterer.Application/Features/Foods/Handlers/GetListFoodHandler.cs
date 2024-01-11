using AutoMapper;
using MediatR;
using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Contracts.Persistence;
using OnlineCaterer.Application.DTOs.Food;
using OnlineCaterer.Application.Features.Foods.Queries;
using OnlineCaterer.Application.Models.Api.Handler;
using OnlineCaterer.Application.Models.Api.Response;
using OnlineCaterer.Domain.Core;

namespace OnlineCaterer.Application.Features.Foods.Handlers
{
	public class GetListFoodHandler
		: GetListHandler<GetListFoodQuery, FoodDTO>,
		IRequestHandler<GetListFoodQuery, ListResponse<FoodDTO>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetListFoodHandler(
			IPermissionProvider permissonProvider,
			IUserService userService,
			IUnitOfWork unitOfWork,
			IMapper mapper)
			: base(permissonProvider, userService)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<ListResponse<FoodDTO>> Handle(
			GetListFoodQuery request, CancellationToken cancellationToken)
		{
			return await GetResponse(request);
		}

		protected override Task Resolve(
			GetListFoodQuery request, ListResponse<FoodDTO> response)
		{
			var foods = _unitOfWork.FoodRepository
				.GetQueryable()
				.Where(f => request.Name == null || f.Name.Contains(request.Name))
				.Where(f => request.CategoryId == null || f.CategoryId == request.CategoryId)
				.Where(f => request.EventId == null || f.EventId == request.EventId);

			response.Payload = _mapper.Map<List<FoodDTO>>(foods.ToList());

			return Task.CompletedTask;
		}
	}
}
