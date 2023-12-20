using AutoMapper;
using MediatR;
using OnlineCaterer.Application.Contracts.Persistence;
using OnlineCaterer.Application.Exceptions;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.Food.Queries.One
{
    public class GetOneFoodCommandHandler : IRequestHandler<GetOneFoodCommand, DataResponse<FoodInformation>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetOneFoodCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
		{
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<DataResponse<FoodInformation>> Handle(GetOneFoodCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var food = await _unitOfWork.FoodRepository.Get(request.FoodId);
				return new DataResponse<FoodInformation>
				{
					Message = $"Detail of food has id {request.FoodId}.",
					//Data = _mapper.Map<FoodInformation>(food),
				};
			}
			catch (NotFoundException)
			{
				return new DataResponse<FoodInformation>
				{
					Message = $"The food with id {request.FoodId} not found!",
				};
			}
		}
	}
}
