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
			// queries
			CreateMap<Food, FoodInformation>()
				.ForMember(
					foodInfo => foodInfo.Images,
					options => options.MapFrom(
						food => food.Images.Select(img => img.Name)
					)
				);

			// create
			CreateMap<CreateFoodRequest, Food>()
				.ForMember(
					food => food.Images,
					options => options.MapFrom(
						cfr => cfr.Images.ConvertAll(
							img => new FoodImage
							{
								Name = img,
							}
						)
					)
				)
				.ForMember(
					food => food.RatingPoint,
					options => options.MapFrom(cfr => 0)
				)
				.ForMember(
					food => food.Discontinued,
					options => options.MapFrom(cfr => false)
				)
				.ForMember(
					food => food.CurrentQuantity,
					options => options.MapFrom(cfr => 0)
				);

			// update
			CreateMap<UpdateFoodRequest, Food>()
				.ForMember(
					food => food.Images,
					options => options.MapFrom(
						cfr => cfr.Images.ConvertAll(
							img => new FoodImage
							{
								Name = img,
							}
						)
					)
				);
			CreateMap<Food, UpdateFoodResponse>();
		}
	}
}
