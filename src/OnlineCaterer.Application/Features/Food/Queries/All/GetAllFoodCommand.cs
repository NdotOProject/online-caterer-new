using AutoMapper;
using MediatR;
using OnlineCaterer.Application.Contracts.Persistence;
using OnlineCaterer.Application.Models;

namespace OnlineCaterer.Application.Features.Food.Queries.All
{
	public class GetAllFoodCommand : IRequest<CommandResponse<List<FoodInformation>>>
	{

		public class Handler : IRequestHandler<GetAllFoodCommand, CommandResponse<List<FoodInformation>>>
		{
			private readonly IUnitOfWork _unitOfWork;
			private readonly IMapper _mapper;

			public Handler(IUnitOfWork unitOfWork, IMapper mapper)
			{
				_unitOfWork = unitOfWork;
				_mapper = mapper;
			}

			public async Task<CommandResponse<List<FoodInformation>>> Handle(GetAllFoodCommand request, CancellationToken cancellationToken)
			{
				var foods = await _unitOfWork.FoodRepository.GetAll();
				return new CommandResponse<List<FoodInformation>>
				{
					Success = true,
					Message = "List all food",
					Data = _mapper.Map<List<FoodInformation>>(foods),
				};
			}
		}
	}
}
