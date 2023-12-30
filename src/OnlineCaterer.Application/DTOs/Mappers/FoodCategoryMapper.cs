using AutoMapper;
using OnlineCaterer.Application.DTOs.FoodCategory;

namespace OnlineCaterer.Application.DTOs.Mappers
{
	public class FoodCategoryMapper : Profile
	{
		public FoodCategoryMapper()
		{
			CreateMap<Domain.Core.FoodCategory, FoodCategoryDTO>()
				.ReverseMap();

			CreateMap<CreateFoodCategoryDTO, Domain.Core.FoodCategory>();
		}
	}
}
