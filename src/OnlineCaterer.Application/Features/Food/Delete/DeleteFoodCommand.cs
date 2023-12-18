using MediatR;
using OnlineCaterer.Application.Contracts.Persistence;
using OnlineCaterer.Application.Exceptions;
using OnlineCaterer.Application.Models;

namespace OnlineCaterer.Application.Features.Food.Delete
{
	public class DeleteFoodCommand : IRequest<CommandResponse<DeleteFoodResponse>>
	{
		public int Id { get; set; }

		public class Handler : IRequestHandler<DeleteFoodCommand, CommandResponse<DeleteFoodResponse>>
		{
			private readonly IUnitOfWork _unitOfWork;

			public async Task<CommandResponse<DeleteFoodResponse>> Handle(DeleteFoodCommand request, CancellationToken cancellationToken)
			{
				var response = new CommandResponse<DeleteFoodResponse>();
				List<string> errors = new();
				try
				{
					Domain.Core.Food food = await _unitOfWork.FoodRepository.Get(request.Id);
					_unitOfWork.FoodRepository.Delete(food);

					response.Success = true;
					response.Message = "Delete Done and Success.";
				}
				catch (NotFoundException)
				{
					response.Success = false;
					response.Message = "";
					errors.Add("");
				}

				if (errors.Count > 0)
				{
					response.Errors = errors;
				}

				return response;
			}
		}
	}
}
