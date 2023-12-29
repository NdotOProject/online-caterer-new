using AutoMapper;
using MediatR;
using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Contracts.Persistence;
using OnlineCaterer.Application.DTOs.FoodImage;
using OnlineCaterer.Application.Features.FoodImages.Queries;
using OnlineCaterer.Application.Models.Api.Error;
using OnlineCaterer.Application.Models.Api.Handler;
using OnlineCaterer.Application.Models.Api.Response;
using System.Net;

namespace OnlineCaterer.Application.Features.FoodImages.Handlers
{
	public class GetListFoodImageHandler
		: GetListHandler<GetListFoodImageQuery, FoodImageDTO>,
		IRequestHandler<GetListFoodImageQuery, ListResponse<FoodImageDTO>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetListFoodImageHandler(
			IPermissionProvider permissonProvider,
			IUserService userService,
			IUnitOfWork unitOfWork,
			IMapper mapper)
			: base(permissonProvider, userService)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<ListResponse<FoodImageDTO>> Handle(
			GetListFoodImageQuery request,
			CancellationToken cancellationToken)
		{
			return await GetResponse(request);
		}

		protected override async Task Resolve(
			GetListFoodImageQuery request,
			ListResponse<FoodImageDTO> response)
		{
			var images = await _unitOfWork.FoodImageRepository
				.GetByFoodId(request.FoodId);

			response.Payload = _mapper.Map<List<FoodImageDTO>>(images);
		}

		protected override async Task Validate(
			GetListFoodImageQuery request, ErrorList errorList)
		{
			var isExist = await _unitOfWork.FoodRepository.Contains(request.FoodId);

			if (!isExist)
			{
				errorList.Add(
					HttpStatusCode.BadRequest,
					$"Food with ID {request.FoodId} does not exist."
				);
			}
		}
	}
}
