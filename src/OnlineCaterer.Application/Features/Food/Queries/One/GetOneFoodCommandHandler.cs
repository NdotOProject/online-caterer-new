using AutoMapper;
using MediatR;
using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Contracts.Persistence;
using OnlineCaterer.Application.Models.Api.Handler;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.Food.Queries.One
{
    public class GetOneFoodCommandHandler :
		GetHandler<GetOneFoodCommand, FoodInformation>,
		IRequestHandler<GetOneFoodCommand, DataResponse<FoodInformation>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetOneFoodCommandHandler(
			IPermissionProvider permissonProvider, IUserService userService,
			IMapper mapper, IUnitOfWork unitOfWork) : base(permissonProvider, userService)
		{
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<DataResponse<FoodInformation>> Handle(
			GetOneFoodCommand request, CancellationToken cancellationToken)
			=> await GetResponse(request);

		protected override Task Reject(
			GetOneFoodCommand request, DataResponse<FoodInformation> response)
		{
			response.Message = $"The food not found!";
			return Task.CompletedTask;
		}

		protected override async Task Resolve(
			GetOneFoodCommand request, DataResponse<FoodInformation> response)
		{
			var food = await _unitOfWork.FoodRepository.Get(request.Id);
			response.Message = $"Detail of food has id {request.Id}.";
			response.Payload = _mapper.Map<FoodInformation>(food);
		}
	}
}
