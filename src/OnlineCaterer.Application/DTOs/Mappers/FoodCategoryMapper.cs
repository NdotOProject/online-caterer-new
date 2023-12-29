using AutoMapper;
using OnlineCaterer.Application.DTOs.FoodCategory;

namespace OnlineCaterer.Application.DTOs.Mappers
{
	public class FoodCategoryMapper : Profile
	{
		public FoodCategoryMapper()
		{
			CreateMap<CreateFoodCategoryDTO, Domain.Core.FoodCategory>();

			CreateMap<UpdateFoodCategoryDTO, Domain.Core.FoodCategory>();

			CreateMap<Domain.Core.FoodCategory, FoodCategoryDTO>();
		}
	}
}
