using MediatR;
using OnlineCaterer.Application.DTOs.FoodCategory;
using OnlineCaterer.Application.Exceptions;
using OnlineCaterer.Application.Models.Api.Request;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.FoodCategories.Commands
{
	public class UpdateFoodCategoryCommand
		: IApiBodyRequest<FoodCategoryDTO>,
		IRequest<VoidResponse>
	{
		public int Id { get; set; }

		private FoodCategoryDTO _dto = null!;
		public FoodCategoryDTO Body
		{
			get
			{
				return _dto;
			}
			set
			{
				if (value != null && value.Id == Id)
				{
					_dto = value;
				}
				else
				{
					throw new BadRequestException();
				}
			}
		}
	}
}
