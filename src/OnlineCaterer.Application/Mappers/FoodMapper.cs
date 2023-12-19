using AutoMapper;
using OnlineCaterer.Application.Features.Food.Create;
using OnlineCaterer.Application.Features.Food.Queries;
using OnlineCaterer.Application.Features.Food.Update;
using OnlineCaterer.Domain.Core;

namespace OnlineCaterer.Application.Mappers
{
	public class FoodMapper : Profile
	{
		public FoodMapper()
		{
			CreateMap<Food, FoodInformation>();
			CreateMap<Food, CreateFoodRequest>().ReverseMap();
			CreateMap<Food, UpdateFoodRequest>().ReverseMap();

		}
	}
}
