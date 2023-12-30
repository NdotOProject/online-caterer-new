using AutoMapper;
using MediatR;
using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Contracts.Persistence;
using OnlineCaterer.Application.DTOs.Food;
using OnlineCaterer.Application.Features.Foods.Queries;
using OnlineCaterer.Application.Models.Api.Error;
using OnlineCaterer.Application.Models.Api.Handler;
using OnlineCaterer.Application.Models.Api.Response;
using System.Net;

namespace OnlineCaterer.Application.Features.Foods.Handlers
{
	public class GetFoodDetailHandler
		: GetHandler<GetFoodDetailQuery, FoodDTO>,
		IRequestHandler<GetFoodDetailQuery, DataResponse<FoodDTO>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetFoodDetailHandler(
			IPermissionProvider permissonProvider,
			IUserService userService,
			IMapper mapper,
			IUnitOfWork unitOfWork)
			: base(permissonProvider, userService)
		{
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<DataResponse<FoodDTO>> Handle(
			GetFoodDetailQuery request, CancellationToken cancellationToken)
		{
			return await GetResponse(request);
		}

		protected override async Task Resolve(
			GetFoodDetailQuery request, DataResponse<FoodDTO> response)
		{
			var food = await _unitOfWork.FoodRepository.Get(request.Id);
			response.Message = $"Detail of food has id {request.Id}.";
			response.Payload = _mapper.Map<FoodDTO>(food);
		}

		protected override Task Reject(
			GetFoodDetailQuery request, DataResponse<FoodDTO> response)
		{
			response.Message = $"The food not found!";
			return Task.CompletedTask;
		}

		protected override async Task Validate(
			GetFoodDetailQuery request, ErrorList errorList)
		{
			var isExist = await _unitOfWork
				.FoodRepository.Contains(request.Id);

			if (!isExist)
			{
				errorList.Add(
					HttpStatusCode.NotFound,
					"The food not found!"
				);
			}
		}
	}
}
