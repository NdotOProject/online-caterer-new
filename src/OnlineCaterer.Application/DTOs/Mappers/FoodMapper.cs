using AutoMapper;
using OnlineCaterer.Application.DTOs.Food;
using OnlineCaterer.Application.DTOs.FoodCategory;

namespace OnlineCaterer.Application.DTOs.Mappers
{
	public class FoodMapper : Profile
	{
		public FoodMapper()
		{
			// queries
			CreateMap<Domain.Core.Food, FoodDTO>()
				.ForMember(
					foodInfo => foodInfo.Images,
					options => options.MapFrom(
						food => food.Images.Select(img => img.Name)
					)
				);

			// create
			CreateMap<CreateFoodDTO, Domain.Core.Food>()
				.ForMember(
					food => food.Images,
					options => options.MapFrom(
						cfr => cfr.Images.ConvertAll(
							img => new Domain.Core.FoodImage
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
			CreateMap<UpdateFoodDTO, Domain.Core.Food>()
				.ForMember(
					food => food.Images,
					options => options.MapFrom(
						cfr => cfr.Images.ConvertAll(
							img => new Domain.Core.FoodImage
							{
								Name = img,
							}
						)
					)
				);
		}
	}
}
